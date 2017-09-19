using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthetizerLib
{
    public static class SampleHelper
    {

        public static AudioChunk MakeChordChunk(int duration, int frequency, int amplitude, int channelCount = 2)
        {
            AudioChunk chunk = new AudioChunk();

            chunk.AddOscillator(WaveType.Sine, duration, frequency, amplitude, channelCount);
            chunk.AddOscillator(WaveType.Square, duration, frequency, amplitude, channelCount);
            //chunk.AddOscillator(WaveType.Sawtooth, duration, frequency, amplitude, channelCount);

            return chunk;
        }

        public static Oscillator MakeSilenceOscillator(int duration)
        {
            return new Oscillator(WaveType.Silent, duration, 1, 1, 2);
        }

        public static List<AudioChunk> MakeUpDownEffectChunk(int startAmp, int endAmp, int ampStep, int frequency, int duration)
        {
            List<AudioChunk> chunks = new List<AudioChunk>();

            for (int amp = startAmp; amp > (ampStep * 2); amp -= ampStep)
            {
                chunks.Add(MakeChordChunk(duration / (startAmp / ampStep), frequency, amp));
            }

            for (int amp = (ampStep * 2); amp < startAmp; amp += ampStep)
            {
                chunks.Add(MakeChordChunk(duration / (startAmp / ampStep), frequency, amp));
            }

            for (int amp = startAmp; amp > ampStep; amp -= ampStep)
            {
                chunks.Add(MakeChordChunk(duration / (startAmp / ampStep), frequency, amp));
            }

            return chunks;
        }

        public static AudioChunk MakeBassChunk(int duration, int frequency, int amplitude, int channelCount = 2)
        {
            AudioChunk chunk = new AudioChunk();

            chunk.AddOscillator(WaveType.Triangle, duration, frequency, amplitude, channelCount);
            //chunk.AddOscillator(WaveType.Sawtooth, duration, frequency, amplitude, channelCount);
            //chunk.AddOscillator(WaveType.Square, duration, frequency + 50, amplitude / 2, channelCount);
            //chunk.AddOscillator(WaveType.Sawtooth, duration, frequency + 50, amplitude / 2, channelCount);
            //chunk.AddOscillator(WaveType.Square, duration, 5, amplitude , channelCount);
            //chunk.AddOscillator(WaveType.Sawtooth, duration, 5, amplitude, channelCount);
            //chunk.AddOscillator(WaveType.Square, duration, 20, amplitude / 3, channelCount);
            //chunk.AddOscillator(WaveType.Sawtooth, duration, 20, amplitude / 3, channelCount);


            return chunk;
        }


        public static AudioChunk MakeBassChunk2(int duration, int frequency, int amplitude, int channelCount = 2)
        {
            AudioChunk chunk = new AudioChunk();

            chunk.AddOscillator(WaveType.Sine, duration, frequency, amplitude, channelCount);
            //chunk.AddOscillator(WaveType.Sawtooth, duration, frequency, amplitude /3, channelCount);
            //chunk.AddOscillator(WaveType.Square, duration, frequency, amplitude / 3, channelCount);
            //chunk.AddOscillator(WaveType.Square, duration, frequency /2, -amplitude, channelCount);


            return chunk;
        }
    }
}
