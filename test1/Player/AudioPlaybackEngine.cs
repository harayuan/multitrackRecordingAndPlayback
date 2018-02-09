using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.Asio;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;

namespace Automation.Player
{
    public class AudioPlaybackEngine : IDisposable
    {
        public MyAsioOut asioOut { get; private set; }
        public MyWaveProvider mwProvider { get; private set; }
        public String asioWriterPath { set; get; }
        private Dictionary<String, CachedSound> soundDictionary; // use dictionary to check if cached sound exists
        private WaveFileWriter asioWriter;
        private String deviceName;
        private int[] desiredInputChannels;
        private int[] desiredOutputChannels;

        public AudioPlaybackEngine(String deviceName)
        {
            this.deviceName = deviceName;
            asioOut = null;
        }

        public void Init(IEnumerable<IEnumerable<String>> fileSets, String spFilename, List<String> inputChannelTypes, List<int> inputMappingData, List<String> outputChannelTypes, List<int> outputMappingData)
        {
            this.soundDictionary = new Dictionary<String, CachedSound>(); // use dictionary to check if cached sound exists
            var inputSets = new List<List<IWaveProvider>>(); // argument to pass  into wave provider
            //set totalOutChannelCnt to 12 in case of crackling sound
            //int totalOutChannelCnt = asioOut.DriverOutputChannelCount;
            int totalOutChannelCnt = 12;
            int speechCnt = outputChannelTypes.Sum(type => type.Contains("Speech") ? 1 : 0);
            int noiseCnt = outputChannelTypes.Sum(type => type.Contains("Noise") ? 1 : 0);
            this.desiredInputChannels = inputMappingData.ToArray();
            this.desiredOutputChannels = outputMappingData.ToArray();

            asioOut = new MyAsioOut(deviceName);

            foreach (var fileSet in fileSets)
            {
                var fileSetArr = fileSet.ToArray();
                var input = new List<IWaveProvider>();
                
                for(int i = 0; i < speechCnt; i++)
                {
                    if (fileSetArr[i] == null)
                    {
                        input.Add(new SilenceStream(new WaveFormat(44100, 16, 1)));
                    }
                    else if (i == 0)
                    {
                        var sound = GetSoundFromDictionary(fileSetArr[i]);
                        input.Add(spFilename == null ? new SpeechStream(sound) : new SpeechStream(sound, GetSoundFromDictionary(spFilename)));
                    }
                    else
                    {
                        var sound = GetSoundFromDictionary(fileSetArr[i]);
                        input.Add(spFilename == null ? new InterferenceStream(sound) : new InterferenceStream(sound, GetSoundFromDictionary(spFilename)));
                    }
                }
                for (int i = 0; i < noiseCnt; i++)
                {
                    if (fileSetArr[speechCnt] == null)
                    {
                        input.Add(new SilenceStream(new WaveFormat(44100, 16, 1)));
                    }
                    else
                    {
                        var sound = GetSoundFromDictionary(fileSetArr[speechCnt]);
                        input.Add(spFilename == null ? new NoiseStream(sound) : new NoiseStream(sound, GetSoundFromDictionary(spFilename)));
                    }
                }
                //fill the rest channels
                for (int i = 0; i < totalOutChannelCnt - speechCnt - noiseCnt; i++)
                {
                    input.Add(new SilenceStream(new WaveFormat(44100, 16, 1)));
                }

                inputSets.Add(input);
            }
            mwProvider = new MyWaveProvider(inputSets, inputSets[0].Count);
            // mapping
            for (int i = 0; i < outputMappingData.Count; i++)
            {
                mwProvider.ConnectInputToOutput(i, outputMappingData[i]);
                mwProvider.ConnectInputToOutput(outputMappingData[i], i);
            }
            //we need all inputs from the sound card
            //but just get the analog channel (1-12)
            asioOut.InitRecordAndPlayback(mwProvider, 12);
            asioOut.AudioAvailable += new EventHandler<MyAsioAudioAvailableEventArgs>(AudioAvailable);
        }

        private void AudioAvailable(object sender, MyAsioAudioAvailableEventArgs e)
        {
            if (asioWriter != null)
            {
                var floatsamples = new float[e.SamplesPerBuffer * (desiredInputChannels.Length + desiredOutputChannels.Length)];
                e.GetAsInterleavedCombinedSamples(floatsamples, desiredInputChannels, desiredOutputChannels);
                asioWriter.WriteSamples(floatsamples, 0, floatsamples.Length);
                asioWriter.Flush();
            }
        }

        public void InitWriter(int nowPlaying)
        {
            if (asioWriter != null)
                asioWriter.Dispose();
            //set the record format indentical with the waveProvider's format just for in case
            var sampleRate = mwProvider.WaveFormat.SampleRate;
            var bitsPerSample = mwProvider.WaveFormat.BitsPerSample;
            var channels = desiredInputChannels.Length + desiredOutputChannels.Length;
            WaveFormat asioWriterFormat = new WaveFormat(sampleRate, bitsPerSample, channels);
            var filename = $@"{asioWriterPath}/record{nowPlaying+1}.wav";
            asioWriter = new WaveFileWriter(filename, asioWriterFormat);
        } 

        private CachedSoundWaveProvider GetSoundFromDictionary(String filename)
        {
            CachedSound output;
            bool soundExist = soundDictionary.TryGetValue(filename, out output);
            if (!soundExist)
            {
                output = new CachedSound(filename);
                soundDictionary.Add(filename, output);
            }
            return new CachedSoundWaveProvider(output);
        }

        public void Play()
        {
            asioOut.Play();
        }

        public int inputChannelCount
        {
            get
            {
                if (asioOut == null)
                {
                    using (var tempAsioOut = new MyAsioOut(deviceName))
                    {
                        return tempAsioOut.DriverInputChannelCount;
                    }
                }
                else
                {
                    return asioOut.DriverInputChannelCount;
                }
            }
        }

        public int outputChannelCount
        {
            get
            {
                if (asioOut == null)
                {
                    using (var tempAsioOut = new MyAsioOut(deviceName))
                    {
                        return tempAsioOut.DriverOutputChannelCount;
                    }
                }
                else
                {
                    return asioOut.DriverOutputChannelCount;
                }
            }
        }

        public String[] GetInputChannelNames()
        {
            //in case of crackling sound, set the channel count to 12 (just analog)
            List<String> inputNames = new List<String>();
            if (asioOut == null)
            {
                using (var tempAsioOut = new MyAsioOut(deviceName))
                {
                    //var channelCnt =  tempAsioOut.DriverInputChannelCount;
                    var channelCnt = 12;
                    for (int i = 0; i < channelCnt; i++)
                    {
                        inputNames.Add(tempAsioOut.AsioInputChannelName(i));
                    }
                }
            }
            else
            {
                //var channelCnt =  asioOut.DriverInputChannelCount;
                var channelCnt = 12;
                for (int i = 0; i < channelCnt; i++)
                {
                    inputNames.Add(asioOut.AsioInputChannelName(i));
                }
            }            
            return inputNames.ToArray();
        }

        public String[] GetOutputChannelNames()
        {
            //in case of crackling sound, set the channel count to 12 (just analog)
            //var channelCnt =  tempAsioOut.DriverOutputChannelCount;
            List<String> outputNames = new List<String>();
            if(asioOut == null)
            {
                using (var tempAsioOut = new MyAsioOut(deviceName))
                {
                    //var channelCnt =  tempAsioOut.DriverOutputChannelCount;
                    var channelCnt = 12;
                    for (int i = 0; i < channelCnt; i++)
                    {
                        outputNames.Add(tempAsioOut.AsioOutputChannelName(i));
                    }
                }
            }
            else
            {
                //var channelCnt =  asioOut.DriverOutputChannelCount;
                var channelCnt = 12;
                for (int i = 0; i < channelCnt; i++)
                {
                    outputNames.Add(asioOut.AsioOutputChannelName(i));
                }
            }           
            return outputNames.ToArray();
        }

        public void Dispose()
        {
            if (mwProvider != null)
            {
                mwProvider.Dispose();
                mwProvider = null;
            }
            //asioOut must dispose before the asioWriter, or the program will collapse
            if (asioOut != null)
            {
                asioOut.Stop();
                asioOut.Dispose();
                asioOut = null;
            }
            if (asioWriter != null)
            {
                asioWriter.Dispose();
                asioWriter = null;
            }
        }

    }
}
