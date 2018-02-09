using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Automation.Player
{
    public class SilenceStream : IWaveProvider
    {
        private bool Stopped;
        /// <summary>
        /// Creates a new silence producing wave provider
        /// </summary>
        /// <param name="wf">Desired WaveFormat (should be PCM / IEE float</param>
        public SilenceStream(WaveFormat wf)
        {
            WaveFormat = wf;
            this.Stopped = false;
        }

        /// <summary>
        /// Read silence from into the buffer
        /// </summary>
        public int Read(byte[] buffer, int offset, int count)
        {
            if (!Stopped)
            {
                var end = offset + count;
                for (var pos = offset; pos < end; pos++)
                {
                    buffer[pos] = 0;
                }
                return count;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// WaveFormat of this silence producing wave provider
        /// </summary>
        public WaveFormat WaveFormat { get; private set; }

        public void Stop()
        {
            this.Stopped = true;
        }
    }
}
