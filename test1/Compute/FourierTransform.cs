using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Compute
{
    public static class FourierTransform
    {
        /// <summary>
        /// Calculate Fast Fourier Transform of Input Array
        /// </summary>
        public static void ForwardFFT(COMPLEX[] Input)
        {
            //Initializing Fourier Transform Array
            int m; //Power of 2 for current number of points
            int Length = Input.Length;

            // Calling 1D FFT Function
            m = (int)Math.Log((double)Length, 2);//Finding power of 2 for current number of points e.g. for nx=512 m=9
            FourierTransform.FFT(true, m, Input);
        }

        /// <summary>
        /// Calculate Inverse from Complex[] Fourier Array
        /// </summary>
        public static void InverseFFT(COMPLEX[] Input)
        {
            int Length = Input.Length;
            int m;
            float[] Output = new float[Length];

            m = (int)Math.Log((double)Length, 2);
            FourierTransform.FFT(false, m, Input);            
        }

        /// <summary>
        /// Perform a 1D FFT inplace given a complex 1D array
        /// </summary>
        /// <param name="dir">The direction dir, 1 for forward, -1 for reverse</param>
        /// <param name="m">The dimensions, Power of 2 for current number of points</param>
        private static void FFT(bool forward, int m, COMPLEX[] data)
        {
            int n, i, i1, j, k, i2, l, l1, l2;
            float c1, c2, tx, ty, t1, t2, u1, u2, z;

            // Calculate the number of points
            n = 1;
            for (i = 0; i < m; i++)
                n *= 2;

            // Do the bit reversal
            i2 = n >> 1;
            j = 0;
            for (i = 0; i < n - 1; i++)
            {
                if (i < j)
                {
                    tx = data[i].real;
                    ty = data[i].imag;
                    data[i].real = data[j].real;
                    data[i].imag = data[j].imag;
                    data[j].real = tx;
                    data[j].imag = ty;
                }
                k = i2;

                while (k <= j)
                {
                    j -= k;
                    k >>= 1;
                }
                j += k;
            }

            // Compute the FFT 
            c1 = -1.0f;
            c2 = 0.0f;
            l2 = 1;
            for (l = 0; l < m; l++)
            {
                l1 = l2;
                l2 <<= 1;
                u1 = 1.0f;
                u2 = 0.0f;
                for (j = 0; j < l1; j++)
                {
                    for (i = j; i < n; i += l2)
                    {
                        i1 = i + l1;
                        t1 = u1 * data[i1].real - u2 * data[i1].imag;
                        t2 = u1 * data[i1].imag + u2 * data[i1].real;
                        data[i1].real = data[i].real - t1;
                        data[i1].imag = data[i].imag - t2;
                        data[i].real += t1;
                        data[i].imag += t2;
                    }
                    z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }
                c2 = (float)Math.Sqrt((1.0f - c1) / 2.0f);
                if (forward)
                    c2 = -c2;
                c1 = (float)Math.Sqrt((1.0f + c1) / 2.0f);
            }

            // Scaling for forward transform 
            if (!forward)
            {
                for (i = 0; i < n; i++)
                {
                    data[i].real /= n;
                    data[i].imag /= n;
                }
            }
        }


    }
}
