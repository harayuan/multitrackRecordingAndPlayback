using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Compute
{
    /// <summary>
    /// Defining Structure for Complex Data type  N=R+Ii
    /// </summary>
    public struct COMPLEX
    {
        public float real, imag;
        public COMPLEX(float x, float y)
        {
            real = x;
            imag = y;
        }
        public float Magnitude()
        {
            return ((float)Math.Sqrt(real * real + imag * imag));
        }
        public float Phase()
        {
            return ((float)Math.Atan(imag / real));
        }
        public void Conjugate()
        {
            imag = -imag;
        }
        public void Multiply(COMPLEX Input)
        {
            var temp_r = real;
            var temp_i = imag;
            real = temp_r * Input.real - temp_i * Input.imag;
            imag = temp_r * Input.imag + temp_i * Input.real;
        }
    }
}
