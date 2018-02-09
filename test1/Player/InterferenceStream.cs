using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Automation.Player
{
    /// <summary>
    /// Stream for looping playback
    /// </summary>
    class InterferenceStream : WaveStream
    {
        private readonly CachedSoundWaveProvider sound; // speech or noise
        public int phase; // 0 = sp play, 1 = interval delay, 2 = last delay, 3 = play, 4 = stop; default is 3
        private int delayBytes; // default is 3 sec
        private int spByteLength;
        private int phasePos; // number of bytes that the phase have read

        /// <summary>
        /// Creates a new Loop stream
        /// </summary>
        /// <param name="sound">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
        /// or else we will not loop to the start again.</param>
        /// 
        public InterferenceStream(CachedSoundWaveProvider sound)
        {
            this.sound = sound;
            this.phase = 2;
            delayBytes = (int)(new TimeSpan(0, 0, 3).TotalSeconds * WaveFormat.SampleRate) * WaveFormat.BitsPerSample * WaveFormat.Channels / 8;
            phasePos = 0;
        }        

        public InterferenceStream(CachedSoundWaveProvider cachedSound, CachedSoundWaveProvider spCachedSound)
            : this (cachedSound)
        {
            this.spByteLength = (int)(spCachedSound.TotalTime.TotalSeconds * WaveFormat.SampleRate) * WaveFormat.BitsPerSample * WaveFormat.Channels / 8; ;
            this.phase = 0;
        }

        /// <summary>
        /// Return source stream's wave format
        /// </summary>
        public override WaveFormat WaveFormat
        {
            get { return sound.WaveFormat; }
        }

        /// <summary>
        /// LoopStream simply returns
        /// </summary>
        public override long Length
        {
            get { return sound.Length; }
        }

        /// <summary>
        /// LoopStream simply passes on positioning to source stream
        /// </summary>
        public override long Position
        {
            get { return sound.Position; }
            set { sound.Position = value; }
        }

        public void Stop()
        {
            this.phase = 5;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            if(phase == 0)
            {
                int bytesRequired = Math.Min(count - totalBytesRead, delayBytes - phasePos);
                for (int i = 0; i < bytesRequired; i++)
                {
                    buffer[offset + totalBytesRead + i] = 0;
                }
                phasePos += bytesRequired;
                totalBytesRead += bytesRequired;
                if (phasePos >= delayBytes) // finished playing delay
                {
                    phasePos = 0;
                    phase = 1;
                }
            }
            if(phase == 1)
            {
                int bytesRequired = Math.Min(count - totalBytesRead, spByteLength - phasePos);
                for (int i = 0; i < bytesRequired; i++)
                {
                    buffer[offset + totalBytesRead + i] = 0;
                }
                phasePos += bytesRequired;
                totalBytesRead += bytesRequired;
                if (phasePos >= spByteLength) // finished playing delay
                {
                    phasePos = 0;
                    phase = 2;
                }
            }
            if(phase == 2)
            {
                int bytesRequired = Math.Min(count - totalBytesRead, delayBytes - phasePos);
                for (int i = 0; i < bytesRequired; i++)
                {
                    buffer[offset + totalBytesRead + i] = 0;
                }
                phasePos += bytesRequired;
                totalBytesRead += bytesRequired;
                if (phasePos >= delayBytes) // finished playing delay
                {
                    phasePos = 0;
                    phase = 3;
                }
            }
            if(phase == 3)
            {
                while (totalBytesRead < count)
                {
                    int bytesRead = sound.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                    if (bytesRead == 0)
                    {
                        phase = 4;
                        break;
                    }
                    totalBytesRead += bytesRead;
                }
            }
            if (phase == 4)
            {
                for (int i = totalBytesRead; i < count - totalBytesRead; i++)
                {
                    buffer[i] = 0;
                }
                totalBytesRead += count - totalBytesRead;
                phase = 5;
            }            
            return totalBytesRead;
        }

    }
}
