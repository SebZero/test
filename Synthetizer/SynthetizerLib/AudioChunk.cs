using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthetizerLib
{
    [Serializable]
    public class AudioChunk
    {
        List<Oscillator> _oscillators = new List<Oscillator>();
        public List<Oscillator> Oscillators { get { return _oscillators; } private set { _oscillators = value; } }

        private short[] _renderedData = null;

        public AudioChunk()
        {

        }


        public short[] GetData()
        {
            //if (_renderedData == null)
            //{
            //    RenderData();
            //}
            RenderData();

            return _renderedData;
        }

        public void AddOscillator(WaveType type, int durationMs, double frequency, int amplitude, int channelCount)
        {
            _oscillators.Add(new Oscillator(type, durationMs, frequency, amplitude, channelCount));
        }

        public void RenderData()
        {
            List<Oscillator> oscList = new List<Oscillator>();

            int dataLenght = 0;
            foreach (Oscillator item in _oscillators)
            {
                if (item.Enable)
                {
                    oscList.Add(item);

                    if (item.Data.Length > dataLenght)
                        dataLenght = item.Data.Length;
                }
            }

            _renderedData = new short[dataLenght];

            for (int i = 0; i < dataLenght; i++)
            {
                int avg = 0;
                int itemCnt = 0;
                foreach (Oscillator item in oscList)
                {
                    if (i < item.Data.Length)
                    {
                        avg += item.Data[i];
                        itemCnt++;
                    }
                }

                avg /= itemCnt;

                _renderedData[i] = (short)avg;
            }

        }
    }
}
