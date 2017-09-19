using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicCustomControls;
using System.IO;
using SynthetizerLib;
using System.Media;
using System.Xml.Serialization;

namespace SynthetizerApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            lvWaveForms.InitItems();

            btnAddOscListToChunk.Enabled = false;
            btnTestFullChunk.Enabled = false;

            chunkTree.AfterSelect += chunkTree_AfterSelect;
        }


        private void chunkTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AudioChunk chunk = GetSelectedChunk();
            btnAddOscListToChunk.Enabled = (chunk != null);
            btnTestFullChunk.Enabled = (chunk != null);

            if (e.Node.Level == 2)
            {
                waveFormSelected.SetForm((Oscillator)e.Node.Tag);
            }
        }

        private void WriteNote(WaveStreamWriter streamWriter, string name, int durationBefore, int duration, int amplitude)
        {
            Tone tone = Tones.Item(name);
            if (durationBefore > 0)
                streamWriter.WriteSilenceChunk(durationBefore);

            streamWriter.WriteChunk(SampleHelper.MakeBassChunk2(duration, tone.Frequency, amplitude, 2));
            //streamWriter.WriteOscillator(new Oscillator(WaveType.Sine, duration, tone.Frequency, amplitude, 2));
        }

        SoundPlayer _player = new SoundPlayer();

        private void PlayStream(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            _player.Stream = stream;
            _player.Load();
            _player.PlaySync();
        }

        private void btnTestForm_Click(object sender, EventArgs e)
        {

            using (MemoryStream stream = new MemoryStream())
            {
                WaveStreamWriter streamWriter = new WaveStreamWriter(stream);

                //   streamWriter.WriteSilenceChunk(5);

                int freq = (int)waveFormControl.Frequency;
                int duration = (int)waveFormControl.Duration;
                int amp = (int)waveFormControl.Amplitude;

                List<Tone> tones = new List<Tone>();

                tones.Add(Tones.Item("Do3"));
                tones.Add(Tones.Item("Ré3"));
                tones.Add(Tones.Item("Mi3"));
                tones.Add(Tones.Item("Fa3"));
                tones.Add(Tones.Item("Sol3"));
                tones.Add(Tones.Item("La3"));
                tones.Add(Tones.Item("Si3"));
                tones.Add(Tones.Item("Do4"));

                //foreach (var item in tones)
                //{
                ////streamWriter.WriteOscillator(new Oscillator(WaveType.Sine, (int)numDuration.Value, item.Frequency, (int)numAmplitude.Value, 2));
                //streamWriter.WriteChunk(SampleHelper.MakeChordChunk(duration, freq, amp, 2));
                ////streamWriter.WriteChunk(SampleHelper.MakeChordChunk(duration, freq, -amp, 2));
                //streamWriter.WriteSilenceChunk(10);
                //}


                //foreach (var item in Tones.ToneList())
                //{
                //      streamWriter.WriteOscillator(new Oscillator(WaveType.Sine, 200, item.Frequency, item.Amplitude, 2));
                //      streamWriter.WriteSilenceChunk(100);

                //}
                List<WaveType> types = lvWaveForms.GetSelectedForms();
                AudioChunk chunk = new AudioChunk();

                foreach (var item in types)
                {
                    chunk.AddOscillator(item, duration, freq, amp, 2);

                    //chunk.AddOscillator(item, duration, freq, -amp, 2);
                }
                ////chunk.AddOscillator(WaveType.Noise, duration, 40, 2000, 2);
                ////chunk.AddOscillator(WaveType.Noise, duration, 20, 1000, 2);

                ////for (int i = 0; i < 15; i++)
                ////{
                ////    chunk.AddOscillator(WaveType.Square, duration, freq - i, amp - (i * 200), 2);
                ////    chunk.AddOscillator(WaveType.Sawtooth, duration, freq - i, amp - (i * 200), 2);
                ////    //chunk.AddOscillator(WaveType.Sine, duration, freq -i, amp - (i * 100), 2);
                ////}

                if (chunk.Oscillators.Count > 0)
                {
                    streamWriter.WriteChunk(chunk);
                    streamWriter.WriteChunk(chunk);
                    streamWriter.WriteChunk(chunk);
                }

                streamWriter.Close();

                PlayStream(stream);
            }


        }


        private void btnDraftTest_Click(object sender, EventArgs e)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                WaveStreamWriter streamWriter = new WaveStreamWriter(stream);

                streamWriter.WriteSilenceChunk(50);

                int freq = (int)waveFormControl.Frequency;
                int duration = (int)waveFormControl.Duration;
                int amp = (int)waveFormControl.Amplitude;

                List<Tone> tones = new List<Tone>();

                tones.Add(Tones.Item("Do3"));
                tones.Add(Tones.Item("Ré3"));
                tones.Add(Tones.Item("Mi3"));
                tones.Add(Tones.Item("Fa3"));
                tones.Add(Tones.Item("Sol3"));
                tones.Add(Tones.Item("La3"));
                tones.Add(Tones.Item("Si3"));
                tones.Add(Tones.Item("Do4"));

                WriteNote(streamWriter, "Ré3", 75, 300, amp);
                WriteNote(streamWriter, "Sol3", 75, 300, amp);
                WriteNote(streamWriter, "La3", 75, 300, amp);
                WriteNote(streamWriter, "Si3", 100, 300, amp);
                WriteNote(streamWriter, "La3", 125, 300, amp);
                WriteNote(streamWriter, "Sol3", 125, 750, amp);

                WriteNote(streamWriter, "Sol3", 325, 150, amp);
                WriteNote(streamWriter, "Sol3", 60, 150, amp);
                WriteNote(streamWriter, "Sol3", 60, 250, amp);

                WriteNote(streamWriter, "La3", 125, 300, amp);

                WriteNote(streamWriter, "Si3", 125, 350, amp);
                WriteNote(streamWriter, "La3", 125, 650, amp);

                //WriteNote(streamWriter, "La3", 50, 150, amp);
                //WriteNote(streamWriter, "La3", 50, 150, amp);
                //WriteNote(streamWriter, "La3", 50, 150, amp);

                //WriteNote(streamWriter, "Si3", 100, 250, amp);
                //WriteNote(streamWriter, "Do3", 100, 150, amp);
                //WriteNote(streamWriter, "Si3", 100, 200, amp);
                //WriteNote(streamWriter, "La3", 100, 300, amp);

                //WriteNote(streamWriter, "La3", 100, 150, amp);
                //WriteNote(streamWriter, "La3", 100, 150, amp);
                //WriteNote(streamWriter, "La3", 100, 150, amp);

                //WriteNote(streamWriter, "Si3", 100, 300, amp);
                //WriteNote(streamWriter, "La3", 100, 250, amp);
                //WriteNote(streamWriter, "Sol3", 100, 400, amp);
                //WriteNote(streamWriter, "La3", 100, 200, amp);

                streamWriter.Close();

                PlayStream(stream);
            }

        }

        private AudioChunk GetSelectedChunk()
        {
            AudioChunk chunk = null;

            if (chunkTree.SelectedNode != null)
            {
                TreeNode node = chunkTree.SelectedNode;

                if (node.Level == 1)
                    chunk = (AudioChunk)node.Tag;
            }

            return chunk;
        }

        private void btnAddOscListToChunk_Click(object sender, EventArgs e)
        {
            AudioChunk chunk = GetSelectedChunk();

            if (chunk == null)
                return;

            int freq = (int)waveFormControl.Frequency;
            int duration = (int)waveFormControl.Duration;
            int amp = (int)waveFormControl.Amplitude;

            List<WaveType> types = lvWaveForms.GetSelectedForms();

            foreach (var item in types)
            {
                chunk.AddOscillator(item, duration, freq, amp, 2);

                //chunk.AddOscillator(item, duration, freq, -amp, 2);
            }

            chunkTree.RemoveChunk(chunk);
            chunkTree.AddChunk(chunk);
        }

        private void btnTestFullChunk_Click(object sender, EventArgs e)
        {
            AudioChunk chunk = GetSelectedChunk();

            if (chunk == null)
                return;

            using (MemoryStream stream = new MemoryStream())
            {
                WaveStreamWriter streamWriter = new WaveStreamWriter(stream);

                if (chunk.Oscillators.Count > 0)
                    streamWriter.WriteChunk(chunk);

                streamWriter.Close();

                PlayStream(stream);
            }
        }


        private void btnSaveChunkWave_Click(object sender, EventArgs e)
        {
            AudioChunk chunk = GetSelectedChunk();

            if (chunk != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.Filter = "wave files (*.wav)|*.wav|All files (*.*)|*.*";
                dlg.RestoreDirectory = true;
                dlg.FileName = "chunk";
                dlg.DefaultExt = ".wav";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write))
                    {
                        WaveStreamWriter streamWriter = new WaveStreamWriter(stream);

                        if (chunk.Oscillators.Count > 0)
                            streamWriter.WriteChunk(chunk);

                        streamWriter.Close();
                    }
                }
            }
        }

        private void btnSaveChunk_Click(object sender, EventArgs e)
        {
            AudioChunk chunk = GetSelectedChunk();

            if (chunk != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                dlg.RestoreDirectory = true;
                dlg.FileName = "chunk";
                dlg.DefaultExt = ".xml";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(AudioChunk));
                        serializer.Serialize(stream, chunk);
                    }
                }
            }
        }

        private void btnLoadChunk_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            dlg.FileName = "chunk";
            dlg.DefaultExt = ".xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AudioChunk));
                    AudioChunk chunk = (AudioChunk)serializer.Deserialize(stream);

                    chunkTree.AddChunk(chunk);
                }
            }

        }

        private void btnNewChunk_Click(object sender, EventArgs e)
        {
            AudioChunk chunk = new AudioChunk();

            chunkTree.AddChunk(chunk);
        }


    }
}
