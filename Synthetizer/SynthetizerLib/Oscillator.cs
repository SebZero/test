using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SynthetizerLib
{
    [Serializable]
    public enum WaveType
    {
        Sine,
        Square,
        Noise,
        Sawtooth,
        Silent,
        Triangle,
        Bass,
        Test
    }

    [Serializable]
    public class Oscillator
    {
        public WaveType Type { get; set; }

        private bool _rendered = false;

        private int _duration;

        private short[] _data;

        [XmlIgnore]
        public short[] Data
        {
            get 
            {
                if (!_rendered)
                    _data = Render();
                return _data; 
            }
        }

        public int Duration
        {
            get { return _duration; }
            set 
            { 
                _duration = value;
                OnChange();
            }
        }

        private double _frequency;
        public double Frequency
        {
            get { return _frequency; }
            set 
            { 
                _frequency = value;
                OnChange();
            }
        }

        private void OnChange()
        {
            _rendered = false;
        }

        private int _amplitude;
        public int Amplitude
        {
            get { return _amplitude; }
            set 
            { 
                _amplitude = value;
                OnChange();
            }

        }


        private int _samplePerSecond;
        public int SamplePerSecond
        {
            get { return _samplePerSecond; }
            set 
            { 
                _samplePerSecond = value;
                OnChange();
            }
        }

        private int _channelCount;
        public int ChannelCount
        {
            get { return _channelCount; }
            set 
            { 
                _channelCount = value;
                OnChange();
            }
        }

        public bool Enable { get; set; }

        
        private short[] GetData()
        {
            return Render();
        }

        public Oscillator(WaveType type, int durationMs, double frequency, int amplitude, int channelCount)
        {
            Type = type;
            Duration = durationMs;
            Frequency = frequency;
            Amplitude = amplitude;
            ChannelCount = channelCount;
            SamplePerSecond = 44100;
            Enable = true;
            _rendered = false;
        }

        public Oscillator()
            : this(WaveType.Sine, 1000, 100.0f, 50, 2)
        {
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2}, {3}", Type.ToString(), Duration, (int)Frequency, Amplitude);
        }

        private short[] Render()
        {
            // Creates a looping buffer based on the params given
            // Fill the buffer with whatever waveform at the specified frequency 
            double durationInSeconds = Duration / 1000.0f;

            int numSamples = Convert.ToInt32((durationInSeconds * SamplePerSecond * ChannelCount));
            short[] data = new short[numSamples];

            double angle = (Math.PI * 2 * Frequency) / (SamplePerSecond * ChannelCount);

            switch (Type)
            {
                case WaveType.Silent:
                    {
                        for (int i = 0; i < numSamples; i++)
                            // Generate a sine wave in both channels.
                            data[i] = 0;
                    }
                    break;
                case WaveType.Sine:
                    {
                        for (int i = 0; i < numSamples; i++)
                        {
                            short val = Convert.ToInt16(Amplitude * Math.Sin(angle * i));
                            data[i] = val;
                        }
                            // Generate a sine wave in both channels.
                    }
                    break;
                case WaveType.Square:
                    {
                        for (int i = 0; i < numSamples; i++)
                        {
                            // Generate a square wave in both channels.
                            if (Math.Sin(angle * i) > 0)
                                data[i] = Convert.ToInt16(Amplitude);
                            else
                                data[i] = Convert.ToInt16(-Amplitude);
                        }
                    }
                    break;
                case WaveType.Sawtooth:
                    {
                        int samplesPerPeriod = Convert.ToInt32(SamplePerSecond / (Frequency / ChannelCount));
                        short sampleStep = Convert.ToInt16((Amplitude * 2) / samplesPerPeriod);
                        short tempSample = 0;

                        int i = 0;
                        int totalSamplesWritten = 0;
                        while (totalSamplesWritten < numSamples)
                        {
                            tempSample = (short)-Amplitude;
                            for (i = 0; i < samplesPerPeriod && totalSamplesWritten < numSamples; i++)
                            {
                                tempSample += sampleStep;
                                data[totalSamplesWritten] = tempSample;

                                totalSamplesWritten++;
                            }
                        }
                    }
                    break;
                case WaveType.Noise:
                    {
                        Random rnd = new Random();
                        for (int i = 0; i < numSamples; i++)
                        {
                            data[i] = Convert.ToInt16(rnd.Next(-Amplitude, Amplitude));
                        }
                    }
                    break;
                case WaveType.Test:
                    {

                        int signifiantNumSample = numSamples - 2000;
                        int index = 0;
                        short val = 0;
                        //for (int i = 0; i < 1000; i++)
                        //{
                        //    data[index++] = val;
                        //    data[index++] = val;
                        //    val+=1;
                        //}

                        for (int i = 0; i < numSamples / (int)Frequency; i++)
                        {
                            val = Convert.ToInt16(Frequency);
                            for (int j = 0; j < ((int)Frequency); j ++)
                            {
                                data[index++] = val;
                                val += 1;
                            }
                        }
                        val = Convert.ToInt16(Frequency);
                        //val = (short)((int)(numSamples - index) / 5);
                        for (int i = index; i < (numSamples); i++)
                        {
                            data[index++] = val;
                            //if (val > 4)
                            val += 1;
                        }

                        for (int i = 0; i < numSamples; i++)
                        {
                            data[i] -= 400;
                        }
                    }

                    break;
                case WaveType.Bass:
                    {
                        int amp = (Amplitude - (Amplitude / 2));
                        int ittUp = numSamples / 20;
                        if ((ittUp % 2 != 0))
                            ittUp--;
                        int ittDown = ittUp;
                        int ittMiddle = numSamples - (3 * (ittUp + ittDown));
                        ittMiddle--;

                        short ampStep = (short)(Frequency / 20);
                        int index = 0;
                        //int index = 0;
                        //for (int j = 0; j < 3; j++)
                        //{
                        //    for (int i = 0; i < ittUp; i += 2)
                        //    {
                        //        _Data[index++] = 0;
                        //        _Data[index++] = Convert.ToInt16(amp);
                        //    }
                        //    amp += ampStep;
                        //}

                        for (int j = 0; j < 20; j++)
                        {
                            if ((j % 2) == 0)
                            {
                                short val = 0;
                                for (int i = 0; i < ittUp; i++, val += ampStep)
                                {
                                    data[index++] = val;
                                }
                            }
                            else
                            {
                                short val = (short)(Frequency);
                                for (int i = 0; i < ittUp; i++, val -= ampStep)
                                {
                                    data[index++] = val;
                                }
                            }

                        }

                        for (int i = index; i < numSamples; i++)
                        {
                            data[index++] = Convert.ToInt16(numSamples - index);
                        }
                        //amp = (Amplitude - (Amplitude / 2));
                        //amp += 2 * (Amplitude / 10);

                        //for (int j = 0; j < 3; j++)
                        //{
                        //    for (int i = 0; i < ittDown; i += 2)
                        //    {
                        //        _Data[index++] = 0;
                        //        _Data[index++] = Convert.ToInt16(amp);
                        //    }
                        //    amp -= amp;
                        //}


                    }
                    break;

                case WaveType.Triangle:
                    {

                        int samplesPerPeriod = Convert.ToInt32(SamplePerSecond / (Frequency / ChannelCount));
                        short sampleStep = Convert.ToInt16((Amplitude * 2) / samplesPerPeriod);
                        short tempSample = 0;

                        int totalSamplesWritten = 0;

                        while (totalSamplesWritten < numSamples)
                        {
                            tempSample = (short)-Amplitude;

                            for (int i = 0; i < samplesPerPeriod && totalSamplesWritten < numSamples; i++)
                            {
                                if (Math.Abs(tempSample) > Amplitude)
                                    sampleStep = (short)-sampleStep;

                                tempSample += sampleStep;
                                data[totalSamplesWritten] = tempSample;

                                totalSamplesWritten++;
                            }
                        }
                    }
                    break;
            }

            _rendered = true;
            return data;
        }
    }
}
