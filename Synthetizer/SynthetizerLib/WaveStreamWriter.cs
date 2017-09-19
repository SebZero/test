using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio;
using NAudio.Wave;

namespace SynthetizerLib
{
    public class WaveStreamWriter
    {

        private Stream _stream;

        public Stream OutputStream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        public WaveFormat Format { get; set; }

        private WaveFormat defaultFormat = new WaveFormat(44100, 16, 2);
        private BinaryWriter _writer = null;
        WaveFileWriter _waveWriter = null;

        public WaveStreamWriter(Stream outputStream, int sampleRate = 44100, int bitDepth = 16, int channelCount = 2)
        {
            Format = new WaveFormat(sampleRate, bitDepth, channelCount);
            _waveWriter = new WaveFileWriter(outputStream, Format);

            _stream = outputStream;
            _writer = new BinaryWriter(_waveWriter);
        }


        public void WriteSilenceChunk(int duration)
        {
            WriteOscillator(SampleHelper.MakeSilenceOscillator(duration));
        }

        public void WriteChunks(List<AudioChunk> chunks)
        {
            foreach (var item in chunks)
            {
                WriteChunk(item);
            }
        }

        public void WriteChunk(AudioChunk chunk)
        {
            short[] data = chunk.GetData();

            for (int i = 0; i < data.Length; i++)
            {
                _writer.Write(data[i]);
            }
        }

        public void WriteOscillator(Oscillator oscillator)
        {
            short[] data = oscillator.Data;

            for (int i = 0; i < data.Length; i++)
            {
                _writer.Write(data[i]);
            }
        }

        public void Close()
        {
            _waveWriter.Flush();
        }

    }
}
