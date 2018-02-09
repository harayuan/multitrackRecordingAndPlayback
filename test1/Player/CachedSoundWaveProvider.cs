using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Automation.Player
{
    class CachedSoundWaveProvider : IWaveProvider
    {
        public long Position;
        private readonly CachedSound cachedSound;

        public CachedSoundWaveProvider(CachedSound cachedSound)
        {
            this.Position = 0;
            this.cachedSound = cachedSound;
        }

        public virtual TimeSpan TotalTime
        {
            get
            {
                return TimeSpan.FromSeconds((double)cachedSound.Length / WaveFormat.AverageBytesPerSecond);
            }
        }
        public WaveFormat WaveFormat
        {
            get
            {
                return cachedSound.WaveFormat;
            }
        }

        public long Length
        {
            get
            {
                return cachedSound.Length;
            }
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            var availableBytes = cachedSound.AudioData.Length - Position;
            var bytesToCopy = Math.Min(availableBytes, count);
            Array.Copy(cachedSound.AudioData, Position, buffer, offset, bytesToCopy);
            Position += bytesToCopy;
            return (int)bytesToCopy;
        }
    }
}
