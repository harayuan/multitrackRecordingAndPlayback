using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.Asio;

namespace Automation.Player
{
    public class MyAsioAudioAvailableEventArgs : AsioAudioAvailableEventArgs
    {
        private readonly AsioSampleType inputAsioSampleType;
        private readonly AsioSampleType outputAsioSampleType;
        /// <summary>
        /// Initialises a new instance of AsioAudioAvailableEventArgs
        /// </summary>
        /// <param name="inputBuffers">Pointers to the ASIO buffers for each channel</param>
        /// <param name="outputBuffers">Pointers to the ASIO buffers for each channel</param>
        /// <param name="samplesPerBuffer">Number of samples in each buffer</param>
        /// <param name="asioSampleType">Audio format within each buffer</param>
        public MyAsioAudioAvailableEventArgs(IntPtr[] inputBuffers, IntPtr[] outputBuffers, int samplesPerBuffer, AsioSampleType inputAsioSampleType, AsioSampleType outputAsioSampleType) 
            : base(inputBuffers, outputBuffers, samplesPerBuffer, inputAsioSampleType)
        {
            this.inputAsioSampleType = inputAsioSampleType;
            this.outputAsioSampleType = outputAsioSampleType;
        }
        /// <summary>
         /// Converts all the playback audio into a buffer of 32 bit floating point samples, interleaved by channel
         /// </summary>
         /// <samples>The samples as 32 bit floating point, interleaved</samples>
        public int GetAsInterleavedOutputSamples(float[] samples)
        {
            int channels = OutputBuffers.Length;
            if (samples.Length < SamplesPerBuffer * channels) throw new ArgumentException("Buffer not big enough");
            int index = 0;
            unsafe
            {
                if (outputAsioSampleType == AsioSampleType.Int32LSB)
                {
                    for (int n = 0; n < SamplesPerBuffer; n++)
                    {
                        for (int ch = 0; ch < channels; ch++)
                        {
                            samples[index++] = *((int*)OutputBuffers[ch] + n) / (float)Int32.MaxValue;
                        }
                    }
                }
                else if (outputAsioSampleType == AsioSampleType.Int16LSB)
                {
                    for (int n = 0; n < SamplesPerBuffer; n++)
                    {
                        for (int ch = 0; ch < channels; ch++)
                        {
                            samples[index++] = *((short*)OutputBuffers[ch] + n) / (float)Int16.MaxValue;
                        }
                    }
                }
                else if (outputAsioSampleType == AsioSampleType.Int24LSB)
                {
                    for (int n = 0; n < SamplesPerBuffer; n++)
                    {
                        for (int ch = 0; ch < channels; ch++)
                        {
                            byte* pSample = ((byte*)OutputBuffers[ch] + n * 3);

                            //int sample = *pSample + *(pSample+1) << 8 + (sbyte)*(pSample+2) << 16;
                            int sample = pSample[0] | (pSample[1] << 8) | ((sbyte)pSample[2] << 16);
                            samples[index++] = sample / 8388608.0f;
                        }
                    }
                }
                else if (outputAsioSampleType == AsioSampleType.Float32LSB)
                {
                    for (int n = 0; n < SamplesPerBuffer; n++)
                    {
                        for (int ch = 0; ch < channels; ch++)
                        {
                            samples[index++] = *((float*)OutputBuffers[ch] + n);
                        }
                    }
                }
                else
                {
                    throw new NotImplementedException(String.Format("ASIO Sample Type {0} not supported", outputAsioSampleType));
                }
            }
            return SamplesPerBuffer * channels;
        }
        
        /// <summary>
        /// Converts all the record and playback audio into a buffer of 32 bit floating point samples, interleaved by channel
        /// </summary>
        /// <samples>The samples as 32 bit floating point, interleaved</samples>
        public int GetAsInterleavedCombinedSamples(float[] samples, int[] desiredInputChannels, int[] desiredOutputChannels)
        {
            int inChannels = InputBuffers.Length;
            int outChannels = OutputBuffers.Length;
            if (samples.Length < SamplesPerBuffer * (desiredInputChannels.Length + desiredOutputChannels.Length)) throw new ArgumentException("Buffer not big enough");
            int index = 0;
            unsafe
            {
                if (inputAsioSampleType != outputAsioSampleType)
                {
                    throw new ArgumentException(String.Format("Input ASIO Sample Type {0} and output ASIO Sample Type {1} are different", inputAsioSampleType, outputAsioSampleType));
                }
                else if (outputAsioSampleType == AsioSampleType.Int32LSB)
                {
                    for (int n = 0; n < SamplesPerBuffer; n++)
                    {
                        for(int cnt = 0; cnt < desiredInputChannels.Length; cnt++)
                        {
                            int ch = desiredInputChannels[cnt];
                            samples[index++] = *((int*)InputBuffers[ch] + n) / (float)Int32.MaxValue;
                        }
                        for (int cnt = 0; cnt < desiredOutputChannels.Length; cnt++)
                        {
                            int ch = desiredOutputChannels[cnt];
                            samples[index++] = *((int*)OutputBuffers[ch] + n) / (float)Int32.MaxValue;
                        }
                    }
                }
                else if (outputAsioSampleType == AsioSampleType.Int16LSB)
                {
                    for (int n = 0; n < SamplesPerBuffer; n++)
                    {
                        for (int cnt = 0; cnt < desiredInputChannels.Length; cnt++)
                        {
                            int ch = desiredInputChannels[cnt];
                            samples[index++] = *((short*)InputBuffers[ch] + n) / (float)Int16.MaxValue;
                        }
                        for (int ch = 0; ch < outChannels; ch++)
                        {
                            samples[index++] = *((short*)OutputBuffers[ch] + n) / (float)Int16.MaxValue;
                        }
                    }
                }
                else if (outputAsioSampleType == AsioSampleType.Int24LSB)
                {
                    for (int n = 0; n < SamplesPerBuffer; n++)
                    {
                        for (int cnt = 0; cnt < desiredInputChannels.Length; cnt++)
                        {
                            int ch = desiredInputChannels[cnt];
                            byte* pSample = ((byte*)InputBuffers[ch] + n * 3);
                            //int sample = *pSample + *(pSample+1) << 8 + (sbyte)*(pSample+2) << 16;
                            int sample = pSample[0] | (pSample[1] << 8) | ((sbyte)pSample[2] << 16);
                            samples[index++] = sample / 8388608.0f;
                        }
                        for (int ch = 0; ch < outChannels; ch++)
                        {
                            byte* pSample = ((byte*)OutputBuffers[ch] + n * 3);
                            //int sample = *pSample + *(pSample+1) << 8 + (sbyte)*(pSample+2) << 16;
                            int sample = pSample[0] | (pSample[1] << 8) | ((sbyte)pSample[2] << 16);
                            samples[index++] = sample / 8388608.0f;
                        }
                    }
                }
                else if (outputAsioSampleType == AsioSampleType.Float32LSB)
                {
                    for (int n = 0; n < SamplesPerBuffer; n++)
                    {
                        for (int cnt = 0; cnt < desiredInputChannels.Length; cnt++)
                        {
                            int ch = desiredInputChannels[cnt];
                            samples[index++] = *((float*)InputBuffers[ch] + n);
                        }
                        for (int ch = 0; ch < outChannels; ch++)
                        {
                            samples[index++] = *((float*)OutputBuffers[ch] + n);
                        }
                    }
                }
                else
                {
                    throw new NotImplementedException(String.Format("Input ASIO Sample Type {0} or Output ASIO Sample Type {1} not supported", inputAsioSampleType, outputAsioSampleType));
                }
            }
            return SamplesPerBuffer * (desiredInputChannels.Length + outChannels);
        }

    }
}
