using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BasicCustomControls;
using SynthetizerLib;

namespace SynthetizerApp.CustomControls
{
    public class AudioChunkTreeView : ExtendedTreeView
    {
        TreeNode _rootNode = null;

        public AudioChunkTreeView()
            : base()
        {
            this.CheckBoxes = true;

            if (DesignMode)
                return;

            this.AfterCheck += AudioChunkTreeView_AfterCheck;
        }

        void AudioChunkTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 2)
            {
                Oscillator osc = e.Node.Tag as Oscillator;
                osc.Enable = e.Node.Checked;
            }
        }

        private bool _init = false;
        private void Init()
        {
            if (_init)
                return;

            _init = true;
            _rootNode = new TreeNode("Play list");

            _rootNode.Checked = true;
            _rootNode.Tag = _audioChunks;

            this.Nodes.Add(_rootNode);
        }

        private List<AudioChunk> _audioChunks = new List<AudioChunk>();


        public List<AudioChunk> GetAudioChunks()
        {
            return _audioChunks;
        }

        public void SetAudioChunks(List<AudioChunk> chunks)
        {
            Init();
            _audioChunks = chunks;
            OnAudioChunkListChanged();
        }

        private void OnAudioChunkListChanged()
        {
            if (_audioChunks == null)
                _audioChunks = new List<AudioChunk>();

            FillTree();
        }

        public void RemoveChunk(AudioChunk chunk)
        {
            Init();
            if (_audioChunks.Contains(chunk))
                _audioChunks.Remove(chunk);

            TreeNode nodeToRemove = null;

            foreach (TreeNode item in _rootNode.Nodes)
            {
                if (item.Tag is AudioChunk)
                {
                    AudioChunk chunkItem = item.Tag as AudioChunk;
                    if (chunk == chunkItem)
                    {
                        nodeToRemove = item;
                        break;
                    }
                }
            }

            if (nodeToRemove != null)
                _rootNode.Nodes.Remove(nodeToRemove);
        }


        public void AddChunk(AudioChunk chunk)
        {
            Init();
            if (chunk == null)
                return;

            _audioChunks.Add(chunk);

            TreeNode chunkNode = new TreeNode("Chunk " + (_audioChunks.Count).ToString());

            chunkNode.Checked = true;
            chunkNode.Tag = chunk;

            foreach (var osc in chunk.Oscillators)
            {
                TreeNode oscNode = new TreeNode(osc.ToString());

                oscNode.Checked = true;
                oscNode.Tag = osc;

                chunkNode.Nodes.Add(oscNode);
            }

            
            _rootNode.Nodes.Add(chunkNode);
            chunkNode.ExpandAll();
            SelectedNode = chunkNode;
            TopNode = chunkNode;
        }

        private void FillTree()
        {
            try
            {
                this.BeginUpdate();

                _rootNode.Nodes.Clear();

                int chunkIndex = 0;

                _rootNode.Checked = true;
                _rootNode.Tag = _audioChunks;

                foreach (var chunk in _audioChunks)
                {
                    TreeNode chunkNode = new TreeNode("Chunk " + (chunkIndex + 1).ToString());

                    chunkNode.Checked = true;
                    chunkNode.Tag = chunk;

                    _rootNode.Nodes.Add(chunkNode);

                    foreach (var osc in chunk.Oscillators)
                    {
                        TreeNode oscNode = new TreeNode(osc.ToString());

                        oscNode.Checked = true;
                        oscNode.Tag = osc;

                        chunkNode.Nodes.Add(oscNode);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.EndUpdate();
        }



    }
}
