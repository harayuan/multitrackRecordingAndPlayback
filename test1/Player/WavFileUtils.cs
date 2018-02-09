using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace Automation.Player
{
    public static class WavFileUtils
    {
        public static void TrimWavFile(WaveFileReader reader, string outPath, TimeSpan cutFromStart, TimeSpan cutFromEnd)
        {
            using (WaveFileWriter writer = new WaveFileWriter(outPath, reader.WaveFormat))
            {
                int bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000;

                int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
                startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

                int endPos = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
                endPos = endPos - endPos % reader.WaveFormat.BlockAlign;
                //int endPos = (int)reader.Length - endPos; //time count from end

                TrimWavFile(reader, writer, startPos, endPos);
            }
        }
        private static void TrimWavFile(WaveFileReader reader, WaveFileWriter writer, int startPos, int endPos)
        {
            reader.Position = startPos;
            byte[] buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                int bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
            if(reader != null)
                reader.Dispose();
            if(writer != null)
                writer.Dispose();
        }

        public static void TrimAndMix(WaveFileReader[] input, String output, TimeSpan startTime, TimeSpan endTime, bool syncPattern)
        {
            //if syncPattern = false, trim the input files based on the TimeSpan
            for (int i = 0; i < input.Length - 1; i++) //no need to trim the last file aka record.wav
            {
                TrimWavFile(input[i], $@"auto_generate/temp{i + 1}_trim.wav", startTime, endTime);
                input[i] = new WaveFileReader(String.Format($@"auto_generate/temp{i + 1}_trim.wav"));
            }
            
            // choose the sample rate we will mix at
            var maxSampleRate = input.Max(r => r.WaveFormat.SampleRate);
            int minBitRate = input.Min(r => r.WaveFormat.BitsPerSample);
            // create the mixer sample providers, resampling if necessary
            var mixerSampleProviders = input.Select(r => r.WaveFormat.SampleRate == maxSampleRate ?
                r.ToSampleProvider() :
            new MediaFoundationResampler(r, new WaveFormat(maxSampleRate, minBitRate, r.WaveFormat.Channels)).ToSampleProvider());
            // create the mixer wave providers
            var mixerwaveProviders = mixerSampleProviders.Select(r => r.ToWaveProvider());
            var waveProvider = new MultiplexingWaveProvider(mixerwaveProviders, input.Count() * 2);
            
            WaveFileWriter.CreateWaveFile(output, waveProvider);
            
            foreach (var i in input)
            {
                i.Dispose();
            }
        }

        public static void MixAudio(String filename, IEnumerable<String> inputFilenames)
        {
            var inputs = inputFilenames.Select(i=>new WaveFileReader(i));
            // choose the sample rate we will mix at
            var maxSampleRate = inputs.Max(r => r.WaveFormat.SampleRate);
            int minBitRate = inputs.Min(r => r.WaveFormat.BitsPerSample);
            // create the mixer sample providers, resampling if necessary
            var mixerSampleProviders = inputs.Select(r => r.WaveFormat.SampleRate == maxSampleRate ?
                r.ToSampleProvider() :
            new MediaFoundationResampler(r, new WaveFormat(maxSampleRate, minBitRate, r.WaveFormat.Channels)).ToSampleProvider());
            // create the mixer wave providers
            var mixerWaveProviders = mixerSampleProviders.Select(r => r.ToWaveProvider16());
            int channelNum = inputs.Sum(i => i.WaveFormat.Channels);
            
            var waveProvider = new MultiplexingWaveProvider(mixerWaveProviders, channelNum);

            WaveFileWriter.CreateWaveFile(filename, waveProvider);

            foreach (var i in inputs)
            {
                i.Dispose();
            }
        }

        public static void Concatenate(string outputFile, IEnumerable<string> sourceFiles)
        {
            byte[] buffer = new byte[1024];
            WaveFileWriter waveFileWriter = null;

            try
            {
                var readers = sourceFiles.Select(s => new WaveFileReader(s));
                var maxSampleRate = readers.Max(r => r.WaveFormat.SampleRate);
                int minBitRate = readers.Min(r => r.WaveFormat.BitsPerSample);

                foreach (WaveFileReader reader in readers)
                {
                    var reSampler = new MediaFoundationResampler(reader, new WaveFormat(maxSampleRate, minBitRate, 2));
                    if (waveFileWriter == null)
                    {
                        // first time in create new Writer
                        waveFileWriter = new WaveFileWriter(outputFile, reSampler.WaveFormat);
                    }
                    else
                    {
                        if (!reSampler.WaveFormat.Equals(waveFileWriter.WaveFormat))
                        {
                            throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                        }
                    }

                    int read;
                    while ((read = reSampler.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        waveFileWriter.Write(buffer, 0, read);
                    }
                }
            }
            finally
            {
                if (waveFileWriter != null)
                {
                    waveFileWriter.Dispose();
                }
            }
        }

        public static List<float[]> Separate(WaveFileReader reader)
        {
            var output = new List<float[]>();
            var buffer = new byte[2 * reader.WaveFormat.SampleRate * reader.WaveFormat.Channels];
            var writers = new WaveFileWriter[reader.WaveFormat.Channels];
            for (int n = 0; n < writers.Length; n++)
            {
                var format = new WaveFormat(reader.WaveFormat.SampleRate, 16, 1);
                writers[n] = new WaveFileWriter(String.Format("channel{0}.wav", n + 1), format);
            }
            int bytesRead;
            while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                int offset = 0;
                while (offset < bytesRead)
                {
                    for (int n = 0; n < writers.Length; n++)
                    {
                        // write one sample
                        writers[n].Write(buffer, offset, 2);
                        offset += 2;
                    }
                }
            }
            for (int n = 0; n < writers.Length; n++)
            {
                writers[n].Dispose();
            }
            reader.Dispose();
            return output;
        }
    }
}
