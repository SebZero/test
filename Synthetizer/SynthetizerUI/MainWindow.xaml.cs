using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio;

using NAudio.Wave;
using SynthetizerLib;
using System.IO;
using System.Media;

namespace SynthetizerUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private Device device;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper helper =
    new WindowInteropHelper(Application.Current.MainWindow);
            //device.SetCooperativeLevel(helper.Handle, CooperativeLevel.Normal);

            //waveFormat = new Microsoft.DirectX.DirectSound.WaveFormat();
            //waveFormat.SamplesPerSecond = 44100;
            //waveFormat.Channels = 2;
            //waveFormat.FormatTag = WaveFormatTag.Pcm;
            //waveFormat.BitsPerSample = 16;
            //waveFormat.BlockAlign = 4;
            //waveFormat.AverageBytesPerSecond = 176400;

            //bufferDesc = new BufferDescription(waveFormat);
            //bufferDesc.DeferLocation = true;
            //bufferDesc.BufferBytes = Convert.ToInt32(
            //    bufferDurationSeconds * waveFormat.AverageBytesPerSecond / waveFormat.Channels);

        }
        private void OscToFile(string fileName, Oscillator osc)
        {
            WaveFormat format = new WaveFormat(44100, 16, 2);

            WaveFileWriter ww = new WaveFileWriter(fileName, format);

            using (MemoryStream strm = new MemoryStream(osc.Data.Length * 2))
            {
                using (BinaryWriter writer = new BinaryWriter(strm))
                {
                    for (int i = 0; i < osc.Data.Length; i++)
                    {
                        writer.Write(osc.Data[i]);
                    }
                }
                byte[] bytes = strm.ToArray();
                ww.Write(bytes, 0, bytes.Length);
            }

            ww.Close();

        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream stream = new FileStream(".\\output.wav", FileMode.Create, FileAccess.Write, FileShare.None, 8 * 1024 * 1024))
            {
                WaveStreamWriter streamWriter = new WaveStreamWriter(stream);

                int duration = 100;
                int repeatGlobalCount = 10;
                int freq = 60;

                AudioChunk motorChunk = SampleHelper.MakeChordChunk(400, 30, 6000);
                Oscillator silence600 = SampleHelper.MakeSilenceOscillator(600);
                AudioChunk smallBassChunk1 = SampleHelper.MakeBassChunk(40, 80, 12000);
                Oscillator silence200 = SampleHelper.MakeSilenceOscillator(200);
                Oscillator silence100 = SampleHelper.MakeSilenceOscillator(100);
                AudioChunk smallBassChunk2 = SampleHelper.MakeBassChunk2(40, 80, 12000);


                Oscillator sine = new Oscillator(WaveType.Sine, 40, 80, 12000, 2);
                Oscillator square = new Oscillator(WaveType.Square, 40, 80, 12000, 2);
                Oscillator triangle = new Oscillator(WaveType.Triangle, 40, 80, 12000, 2);
                Oscillator sawtooth = new Oscillator(WaveType.Sawtooth, 40, 80, 12000, 2);

                streamWriter.WriteOscillator(sine);
                streamWriter.WriteOscillator(silence200);

                streamWriter.WriteOscillator(sine);
                streamWriter.WriteOscillator(silence200);
                streamWriter.WriteOscillator(silence200);

                streamWriter.WriteOscillator(square);
                streamWriter.WriteOscillator(silence200);

                streamWriter.WriteOscillator(square);
                streamWriter.WriteOscillator(silence200);
                streamWriter.WriteOscillator(silence200);

                streamWriter.WriteOscillator(triangle);
                streamWriter.WriteOscillator(silence200);

                streamWriter.WriteOscillator(triangle);
                streamWriter.WriteOscillator(silence200);
                streamWriter.WriteOscillator(silence200);


                streamWriter.WriteOscillator(sawtooth);
                streamWriter.WriteOscillator(silence200);

                streamWriter.WriteOscillator(sawtooth);
                streamWriter.WriteOscillator(silence200);
                streamWriter.WriteOscillator(silence200);




                //for (int j = 0; j < 1; j++)
                //{
                //    for (int i = 0; i < 2; i++)
                //    {
                //        for (int z = 0; z < 3; z++)
                //        {
                //            streamWriter.WriteChunk(smallBassChunk1);
                //            streamWriter.WriteOscillator(silence200);
                //        }

                //        for (int z = 0; z < 2; z++)
                //        {
                //            streamWriter.WriteChunk(smallBassChunk1);
                //            streamWriter.WriteOscillator(silence100);
                //        }
                //    }


                //    for (int i = 0; i < 4; i++)
                //    {
                //        for (int z = 0; z < 3; z++)
                //        {
                //            streamWriter.WriteChunk(smallBassChunk2);
                //            streamWriter.WriteOscillator(silence200);
                //        }

                //        for (int z = 0; z < 2; z++)
                //        {
                //            streamWriter.WriteChunk(smallBassChunk2);
                //            streamWriter.WriteOscillator(silence100);
                //        }
                //    }

                //}


                //for (int i = 0; i < 3; i++)
                //{
                //    streamWriter.WriteChunk(motorChunk);
                //    streamWriter.WriteOscillator(silence600);
                //}

                //for (int z = 0; z < 10; z++)
                //{
                //    streamWriter.WriteChunk(smallBassChunk2);
                //    streamWriter.WriteOscillator(silence200);
                //}


                //freq = 60;

                //for (int z = 0; z < 5; z++)
                //{
                //    streamWriter.WriteChunk(SampleHelper.MakeChordChunk(duration * 2, freq, 3000));
                //    streamWriter.WriteSilenceChunk(100);
                //    streamWriter.WriteChunk(SampleHelper.MakeChordChunk(duration * 2, freq, 3000));
                //    streamWriter.WriteSilenceChunk(50);
                //    streamWriter.WriteChunk(SampleHelper.MakeChordChunk(duration * 2, freq, 3000));
                //    streamWriter.WriteSilenceChunk(duration);
                //}


                //for (int j = 0; j < 2; j++)
                //{
                //    freq = 60;
                //    for (int k = 0; k < 3; k++)
                //    {
                //        //WriteSample(MakeSample(duration, 50, 300), writer);
                //        //WriteSample(MakeSilenceSample(200), writer);
                //        SequenceHelper.WriteSample(SequenceHelper.MakeSample(duration * 2, freq, 3000), writer);
                //        SequenceHelper.WriteSilenceSample(100, writer);
                //        SequenceHelper.WriteSample(SequenceHelper.MakeSample(duration * 2, freq, 3000), writer);
                //        SequenceHelper.WriteSilenceSample(50, writer);
                //        SequenceHelper.WriteSample(SequenceHelper.MakeSample(duration * 2, freq, 3000), writer);
                //        SequenceHelper.WriteSilenceSample(duration, writer);

                //    }

                //    freq = ((j % 2) != 0) ? 180 : 260;
                //    int repeatSeq = ((j % 2) == 0) ? 2 : 2;
                //    duration = ((j % 2) == 0) ? 100 : 100;

                //    SequenceHelper.WriteUpDownSample(4000, 1500, 500, freq, 1000, writer);

                //    SequenceHelper.WriteSilenceSample(duration * 2, writer);



                //    //for (int i = 0; i < repeatSeq; i++)
                //    //{
                //    //    WriteSample(MakeSample(duration * 3, 50, 300), writer);

                //    //    //if (j != (repeatGlobalCount - 1))
                //    //    //    WriteSample(MakeSample(duration, 30, 3000), writer);
                //    //}


                //}
                streamWriter.Close();

            }

            SoundPlayer player = new SoundPlayer(".\\output.wav");

            player.Load();

            player.PlaySync();

            Application.Current.MainWindow.Close();

            //OscToFile(@".\SampleSine.wav", new Oscillator(WaveType.Sine, 1000, 4000, 300, 2));
            //OscToFile(@".\SampleSawtooth.wav", new Oscillator(WaveType.Sawtooth, 1000, 4000, 300, 2));
            //OscToFile(@".\SampleSquare.wav", new Oscillator(WaveType.Square, 1000, 4000, 300, 2));
        }
    }
}
