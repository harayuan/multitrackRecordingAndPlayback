using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using NAudio.Utils;

namespace Automation.Player
{
    /// <summary>
    /// Allows any number of inputs to be patched to outputs
    /// Uses could include swapping left and right channels, turning mono into stereo,
    /// feeding different input sources to different soundcard outputs etc
    /// </summary>
    public class MyWaveProvider : WaveStream, IWaveProvider
    {
        public WaveFormat waveFormat;
        /// <summary>
        /// The number of input channels. Note that this is not the same as the number of input wave providers. If you pass in
        /// one stereo and one mono input provider, the number of input channels is three.
        /// </summary>
        public int OutputChannelCount { get; private set; }
        /// <summary>
        /// The number of output channels, as specified in the constructor.
        /// </summary>
        public int InputChannelCount { get; private set; }

        private readonly List<int> mappings;
        private readonly int bytesPerSample;

        List<List<IWaveProvider>> inputSets;
        private int nowPlaying;
        private List<IWaveProvider> inputs;

        public event EventHandler<PlaybackChangedEventArgs> PlaybackChanged;

        /// <summary>
        /// Creates a multiplexing wave provider, allowing re-patching of input channels to different
        /// output channels
        /// </summary>
        /// <param name="inputs">Input wave providers for different channels. Must all be of the same format, but can have any number of channels</param>
        /// <param name="numberOfOutputChannels">Desired number of output channels.</param>
        public MyWaveProvider(List<List<IWaveProvider>> inputSets, int numberOfOutputChannels)
        {
            this.OutputChannelCount = numberOfOutputChannels;
            this.inputSets = inputSets;

            if (this.inputSets.Count == 0)
            {
                throw new ArgumentException("You must provide at least one set of input");
            }
            if (numberOfOutputChannels < 1)
            {
                throw new ArgumentException("You must provide at least one output");
            }
            
            foreach (var set in inputSets)
            {
                //count the input channel number
                int inCh = 0;
                InputChannelCount = 0;
                foreach (var input in set)
                {
                    //set the first format as waveProvider's format
                    if (this.waveFormat == null)
                    {
                        if (input.WaveFormat.Encoding == WaveFormatEncoding.Pcm)
                        {
                            this.waveFormat = new WaveFormat(input.WaveFormat.SampleRate, input.WaveFormat.BitsPerSample, OutputChannelCount);
                        }
                        else if (input.WaveFormat.Encoding == WaveFormatEncoding.IeeeFloat)
                        {
                            this.waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(input.WaveFormat.SampleRate, OutputChannelCount);
                        }
                        else
                        {
                            throw new ArgumentException("Only PCM and 32 bit float are supported");
                        }
                    }
                    else
                    {
                        if (input.WaveFormat.BitsPerSample != this.waveFormat.BitsPerSample)
                        {
                            throw new ArgumentException("All inputs must have the same bit depth");
                        }
                        if (input.WaveFormat.SampleRate != this.waveFormat.SampleRate)
                        {
                            throw new ArgumentException("All inputs must have the same sample rate");
                        }
                    }
                    inCh += input.WaveFormat.Channels;
                }
                //set the first input channel count
                if (InputChannelCount == 0)
                {
                    InputChannelCount = inCh;
                }
                else if (inCh != InputChannelCount)
                    throw new ArgumentException("All data sets must have the same channel count");
            }
            this.bytesPerSample = this.waveFormat.BitsPerSample / 8;

            mappings = new List<int>();
            for (int n = 0; n < OutputChannelCount; n++)
            {
                mappings.Add(n % InputChannelCount);
            }

            //set the first set as default
            this.inputs = inputSets[0];
            nowPlaying = 0;
        }

        /// <summary>
        /// persistent temporary buffer to prevent creating work for garbage collector
        /// </summary>
        private byte[] inputBuffer;
        /// <summary>
        /// Reads data from this WaveProvider
        /// </summary>
        /// <param name="buffer">Buffer to be filled with sample data</param>
        /// <param name="offset">Offset to write to within buffer, usually 0</param>
        /// <param name="count">Number of bytes required</param>
        /// <returns>Number of bytes read</returns>
        public override int  Read(byte[] buffer, int offset, int count)
        {
            int outputBytesPerFrame = bytesPerSample * OutputChannelCount;
            int sampleFramesRequested = count / outputBytesPerFrame;
            int inputOffset = 0;
            int sampleFramesRead = 0;
            
            // now we must read from all inputs, even if we don't need their data, so they stay in sync
            for (int i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];// if speech stops, set the competing and noise streams to stop
                if (i == 0 && inputs[0].GetType() == typeof(SpeechStream))
                {
                    if (((SpeechStream)inputs[0]).isStopped())
                    {
                        foreach(InterferenceStream stream in inputs.OfType<InterferenceStream>())
                        {
                            stream.Stop();
                        }
                        foreach (NoiseStream stream in inputs.OfType<NoiseStream>())
                        {
                            stream.Stop();
                        }
                        foreach (SilenceStream stream in inputs.OfType<SilenceStream>())
                        {
                            stream.Stop();
                        }
                        //if playing set is not the last one, switch to the next set
                        if (nowPlaying != inputSets.Count - 1)
                        {
                            this.nowPlaying += 1;
                            this.inputs = inputSets[nowPlaying];
                            RaisePlaybackChanged(nowPlaying);
                        }
                    }
                }

                int inputBytesPerFrame = bytesPerSample * input.WaveFormat.Channels;
                int bytesRequired = sampleFramesRequested * inputBytesPerFrame;
                this.inputBuffer = BufferHelpers.Ensure(this.inputBuffer, bytesRequired);
                int bytesRead = input.Read(inputBuffer, 0, bytesRequired);
                sampleFramesRead = Math.Max(sampleFramesRead, bytesRead / inputBytesPerFrame);                

                for (int n = 0; n < input.WaveFormat.Channels; n++)
                {
                    int inputIndex = inputOffset + n;
                    for (int outputIndex = 0; outputIndex < OutputChannelCount; outputIndex++)
                    {
                        if (mappings[outputIndex] == inputIndex)
                        {
                            int inputBufferOffset = n * bytesPerSample;
                            int outputBufferOffset = offset + outputIndex * bytesPerSample;
                            int sample = 0;
                            while (sample < sampleFramesRequested && inputBufferOffset < bytesRead)
                            {
                                Array.Copy(inputBuffer, inputBufferOffset, buffer, outputBufferOffset, bytesPerSample);
                                outputBufferOffset += outputBytesPerFrame;
                                inputBufferOffset += inputBytesPerFrame;
                                sample++;
                            }

                            // clear the end
                            while (sample < sampleFramesRequested)
                            {
                                Array.Clear(buffer, outputBufferOffset, bytesPerSample);
                                outputBufferOffset += outputBytesPerFrame;
                                sample++;
                            }
                        }
                    }
                }
                inputOffset += input.WaveFormat.Channels;
            }
            return sampleFramesRead * outputBytesPerFrame;
        }


        /// <summary>
        /// Connects a specified input channel to an output channel
        /// </summary>
        /// <param name="inputChannel">Input Channel index (zero based). Must be less than InputChannelCount</param>
        /// <param name="outputChannel">Output Channel index (zero based). Must be less than OutputChannelCount</param>
        public void ConnectInputToOutput(int inputChannel, int outputChannel)
        {
            if (inputChannel < 0 || inputChannel >= InputChannelCount)
            {
                throw new ArgumentException($"Invalid input channel {inputChannel}, {InputChannelCount}");
            }
            if (outputChannel < 0 || outputChannel >= OutputChannelCount)
            {
                throw new ArgumentException($"Invalid output channel {outputChannel}, {OutputChannelCount}");
            }
            mappings[outputChannel] = inputChannel;
        }

        public override WaveFormat WaveFormat
        {
            get
            {
                return waveFormat;
            }
        }

        public override long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void RaisePlaybackChanged(int nowPlaying)
        {
            var handler = PlaybackChanged;
            if (handler != null)
            {
                var a = new EventArgs();
                handler(this, new PlaybackChangedEventArgs(nowPlaying));
            }
        } 

    }

    public class PlaybackChangedEventArgs: EventArgs
    {
        private readonly int nowPlaying;

        /// <summary>
        /// Initializes a new instance of PlaybackChangedEventArgs
        /// </summary>
        /// <param name="exception">An exception to report (null if no exception)</param>
        public PlaybackChangedEventArgs(int nowPlaying)
        {
            this.nowPlaying = nowPlaying;
        }

        public int NowPlaying { get { return nowPlaying; } }
    }
}
