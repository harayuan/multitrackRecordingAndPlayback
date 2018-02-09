using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Runtime.InteropServices;

using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace Automation.Compute
{
    class FindMatch
    {
        /*
        [DllImport("XCorrLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float cross(float[] x, float[] y, int len);
        [DllImport("XCorrLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int main(float[] x, int lenx, float[] y, int leny);
        */
        public float[] spSample;
        public List<float[]> floatSamples;

        public FindMatch(String spName, String sourceName)
        {
            var sourceReader = new WaveFileReader(@"input_audio/test_source2.wav");          
            var spReader = new WaveFileReader(@"sync_pattern/sweep_tone.wav");
            if (sourceReader.WaveFormat.SampleRate != spReader.WaveFormat.SampleRate)
                throw new ArgumentNullException("Two wav files must have the same sample rate");

            var floatLists = ReadChannel(sourceReader.ToSampleProvider(), new List<int>(new int[] { 0 }));
            this.floatSamples = floatLists.Select(f => f.ToArray()).ToList();

            var spLists = ReadChannel(spReader.ToSampleProvider(), new List<int>(new int[] { 0 }));
            this.spSample = spLists[0].ToArray();
            
            //var t1 = new float[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 1, 2, 1, 2, 0 };
            //var t2 = new float[] { 0, 0, 7, 8, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var t1 = floatSamples[0];
            var t2 = spSample;
            //test/////////////////////////////////////
            //xcorr = XCorr(t1, t2);

            float[] xcorr = {0f};
            try
            {
                MyXCORR.MatlabXCORR x = new MyXCORR.MatlabXCORR();
                MWNumericArray m1 = t1;
                MWNumericArray m2 = t2;
                MWArray result = x.XCORR(m1, m2);
                xcorr = (float[])((MWNumericArray)result).ToVector(MWArrayComponent.Real);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            var maxVal = 0f;
            var maxPos = -1;
            for(int i = 0; i < xcorr.Length; i++)
            {
                if (xcorr[i] > maxVal)
                {
                    maxPos = i;
                    maxVal = xcorr[i];
                }
                if (xcorr[i] > 2000)
                    Console.Out.WriteLine($"position>2000: {i}");
            }
            Console.Out.WriteLine($"maxPos: {maxPos}, maxVal: {maxVal}");
            // the nth sample
            maxPos = maxPos - t1.Length + 1;
            var matchTime = (float)maxPos / sourceReader.WaveFormat.SampleRate;
            Console.Out.WriteLine($"maxPos: {maxPos }");
            Console.Out.WriteLine($"matchTime: {matchTime }");
            MessageBox.Show($"matchTime: {matchTime}");

            /*
            var w = System.IO.File.AppendText(@"writeSample.txt");
            w.WriteLine(floatSamples[0].Length);
            foreach (var i in floatSamples[0])
            {
                w.WriteLine(String.Format("{0:0.000000}", i));
            }
            w.Dispose();
            w = System.IO.File.AppendText(@"writeSP.txt");
            w.WriteLine(spSample.Length);
            foreach (var i in spSample)
            {
                w.WriteLine(String.Format("{0:0.000000}", i));
            }
            w.Dispose();
            Console.Out.WriteLine("finishing output file");
            */
            sourceReader.Dispose();
            spReader.Dispose();
        }

        public List<List<float>> ReadChannel(ISampleProvider sampleProvider, List<int>channels)
        {
            int bytesPerSample = sampleProvider.WaveFormat.BitsPerSample / 8;
            //var buffer = new byte[2 * sampleProvider.WaveFormat.SampleRate * sampleProvider.WaveFormat.Channels];
            var buffer = new float[2 * sampleProvider.WaveFormat.Channels];

            var outSamples = new List<List<float>>();
            for (int n = 0; n < channels.Count; n++)
                outSamples.Add(new List<float>());

            // in case of running out memory, we can only read the whole file and capture single channel once a time
            int samplesRead;
            while ((samplesRead = sampleProvider.Read(buffer, 0, buffer.Length)) > 0)
            {
                int offset = 0;
                while (offset < samplesRead)
                {
                    int outCnt = 0;
                    for (int n = 0; n < sampleProvider.WaveFormat.Channels; n++)
                    {
                        if (channels.Contains(n))
                        {
                            var sample = buffer[offset + n];
                            outSamples[outCnt].Add(sample);
                            outCnt++;
                        }
                    }
                    offset += sampleProvider.WaveFormat.Channels;
                }
            }
            return outSamples;
        }

        /// <summary>
        /// Perform Cross Correlation of two float array
        /// </summary>
        /// <param name="input1">sample</param>
        /// <param name="input2">sync pattern</param>
        public float[] XCorr(float[] input1, float[] input2)
        {
            if (input1.Length < input2.Length)
            {
                throw new ArgumentNullException("the first input must longer than the second input");

            }
            int maxlag = input1.Length - 1;
            int nextpow2 = (int)Math.Log((double)2* input1.Length -1, 2) + 1;
            int padLength = (int)Math.Pow(2, nextpow2);

            //pad the end of the array
            var input1_pad = input1.Concat(Enumerable.Repeat(0f, padLength - input1.Length)).ToArray();
            var input2_pad = input2.Concat(Enumerable.Repeat(0f, padLength - input2.Length)).ToArray();
            
            COMPLEX[] input1_c = input1_pad.Select(input => new COMPLEX(input, 0f)).ToArray();
            COMPLEX[] input2_c = input2_pad.Select(input => new COMPLEX(input, 0f)).ToArray();
            FourierTransform.ForwardFFT(input1_c);
            FourierTransform.ForwardFFT(input2_c);
            
            /*write xcorr to textfile*/
            var w = System.IO.File.AppendText(@"result.txt");
            for (int i = 1; i <= input2_c.Length; i++)
            {
                w.WriteLine($"{i}: {input2_c[i - 1].real} + {input2_c[i - 1].imag}i");
            }
            w.Dispose();

            for (int i = 0; i < padLength; i++)
            {
                input2_c[i].Conjugate();
                input1_c[i].Multiply(input2_c[i]);
            }

            FourierTransform.InverseFFT(input1_c);

            //test
            //var real = input1_c.Select(c => c.Magnitude()).ToArray();
            var real = input1_c.Select(c => c.real).ToArray();
            
            var neg_c = new float[maxlag];
            var pos_c = new float[maxlag+1];
            Array.Copy(real, padLength - maxlag, neg_c, 0, maxlag);
            Array.Copy(real, 0, pos_c, 0, maxlag+1);
            var output = neg_c.Concat(pos_c).ToArray();

            return output;
        }

        /*
        /// <summary>
		/// One dimensional Fast Fourier Transform.
		/// </summary>
		/// 
		/// <param name="data">Data to transform.</param>
		/// <param name="direction">Transformation direction.</param>
        /// 
        /// <remarks><para><note>The method accepts <paramref name="data"/> array of 2<sup>n</sup> size
        /// only, where <b>n</b> may vary in the [1, 14] range.</note></para></remarks>
        /// 
        /// <exception cref="ArgumentException">Incorrect data length.</exception>
        /// 
        public static COMPLEX[] FFT(COMPLEX[] data, int direction)
        {
            int n = data.Length;
            //int m = Tools.Log2(n);
            int m = (int)Math.Log((double)n, 2);

            COMPLEX[] output = new COMPLEX[n];

            // compute FFT
            int tn = 1, tm;

            for (int k = 1; k <= m; k++)
            {
                COMPLEX[] rotation = GetComplexRotation(k, direction);

                tm = tn;
                tn <<= 1;

                for (int i = 0; i < tm; i++)
                {
                    COMPLEX t = rotation[i];

                    for (int even = i; even < n; even += tn)
                    {
                        int odd = even + tm;
                        COMPLEX ce = data[even];
                        COMPLEX co = data[odd];

                        float tr = co.real * t.real - co.imag * t.imag;
                        float ti = co.real * t.imag + co.imag * t.real;

                        output[even].real += tr;
                        output[even].imag += ti;

                        output[odd].real = ce.real - tr;
                        output[odd].imag = ce.imag - ti;
                    }
                }
            }
            
            if (direction == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    output[i].real /= (float)n;
                    output[i].imag /= (float)n;
                }
            }
            
            return output;
        }

        private const int maxBits = 14;
        private static COMPLEX[,][] complexRotation = new COMPLEX[maxBits, 2][];
        private static COMPLEX[] GetComplexRotation(int numberOfBits, int direction)
        {
            int directionIndex = (direction == 1) ? 0 : 1;

            // check if the array is already calculated
            if (complexRotation[numberOfBits - 1, directionIndex] == null)
            {
                int n = 1 << (numberOfBits - 1);
                double uR = 1.0;
                double uI = 0.0;
                double angle = System.Math.PI / n * (int)direction;
                double wR = System.Math.Cos(angle);
                double wI = System.Math.Sin(angle);
                double t;
                COMPLEX[] rotation = new COMPLEX[n];

                for (int i = 0; i < n; i++)
                {
                    rotation[i] = new COMPLEX((float)uR, (float)uI);
                    t = uR * wI + uI * wR;
                    uR = uR * wR - uI * wI;
                    uI = t;
                }

                complexRotation[numberOfBits - 1, directionIndex] = rotation;
            }
            return complexRotation[numberOfBits - 1, directionIndex];
        }
        */


        public float[] Compute(float[] source, float[] pattern)
        {
            var output = new float[source.Length + (pattern.Length - 1)];
            var pad_source = new float[source.Length + 2 * (pattern.Length - 1)];

            var avg1 = pattern.Average();
            var avg2 = source.Average();
            var max = 0f;
            var maxPos = 0;

            for (int i = 0; i < pad_source.Length; i++)
            {
                if (i < pattern.Length - 1 || i >= source.Length + (pattern.Length - 1))
                    pad_source[i] = 0;
                else
                    pad_source[i] = source[i - (pattern.Length - 1)];
            }

            for (int n = 0; n <= pad_source.Length - pattern.Length; n++)
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    output[n] += (pattern[i]) * (pad_source[n + i]);
                }
                if (output[n] > max)
                {
                    max = output[n];
                    maxPos = n;
                }
            }
            MessageBox.Show($"maxPos: {maxPos - (pattern.Length - 1)}, {(float)((maxPos - (pattern.Length - 1)) / 44100)}");

            return output;
        }

        public float ComputeCoeff(float[] values1, float[] values2)
        {
            if (values1.Length != values2.Length)
                throw new ArgumentException("values must be the same length");

            var avg1 = values1.Average();
            var avg2 = values2.Average();

            var sum1 = values1.Zip(values2, (x1, y1) => (x1 - avg1) * (y1 - avg2)).Sum();

            var sumSqr1 = sumSqr(values1);
            var sumSqr2 = sumSqr(values2);

            var result = (float)(sum1 / Math.Sqrt(sumSqr1 * sumSqr2));

            return result;
        }

        float sumSqr(float[] input)
        {
            float avg = input.Average();
            float output = 0;
            foreach (var i in input)
            {
                output += (i - avg) * (i - avg);
            }
            return output;
        }



    }
}
