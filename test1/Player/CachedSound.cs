using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Automation.Player
{
    class CachedSound
    {
        public byte[] AudioData { get; private set; }
        public WaveFormat WaveFormat { get; private set; }
        public long Length { get; private set; }


        public CachedSound(String audioFilename)
        {
            /*force all the inputs convert to mono, 16bit, 44100Hz*/
            var sampleRate = 44100;
            int bits = 16;
            int channel = 1;
            this.WaveFormat = new WaveFormat(sampleRate, bits, channel);
            using (var audioFileReader = new WaveFormatConversionStream(WaveFormat, new WaveFileReader(audioFilename)))
            {
                // TODO: could add resampling in here if required
                this.Length = audioFileReader.Length;
                var wholeFile = new List<byte>((int)(audioFileReader.Length));
                var readBuffer = new byte[audioFileReader.WaveFormat.SampleRate * audioFileReader.WaveFormat.Channels / 4]; // buffer length = 2 samples
                int bytesRead;
                while ((bytesRead = audioFileReader.Read(readBuffer, 0, readBuffer.Length)) > 0)
                {
                    wholeFile.AddRange(readBuffer.Take(bytesRead));
                }
                AudioData = wholeFile.ToArray();
            }
        }

    }
}
