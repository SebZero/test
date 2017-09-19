namespace SynthetizerApp
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Play list");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Play list");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Play list");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Play list");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Play list");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Play list");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Play list");
            this.btnTestForm = new System.Windows.Forms.Button();
            this.btnDraftTest = new System.Windows.Forms.Button();
            this.btnAddOscListToChunk = new System.Windows.Forms.Button();
            this.btnTestFullChunk = new System.Windows.Forms.Button();
            this.btnSaveChunk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadChunk = new System.Windows.Forms.Button();
            this.btnSaveChunkWave = new System.Windows.Forms.Button();
            this.chunkTree = new SynthetizerApp.CustomControls.AudioChunkTreeView();
            this.waveFormSelected = new SynthetizerApp.WaveFormControl();
            this.waveFormControl = new SynthetizerApp.WaveFormControl();
            this.lvWaveForms = new SynthetizerApp.WaveFormListview();
            this.audioChunkTreeView1 = new SynthetizerApp.CustomControls.AudioChunkTreeView();
            this.audioChunkTreeView2 = new SynthetizerApp.CustomControls.AudioChunkTreeView();
            this.btnNewChunk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestForm
            // 
            this.btnTestForm.Location = new System.Drawing.Point(337, 202);
            this.btnTestForm.Name = "btnTestForm";
            this.btnTestForm.Size = new System.Drawing.Size(120, 23);
            this.btnTestForm.TabIndex = 1;
            this.btnTestForm.Text = "Test";
            this.btnTestForm.UseVisualStyleBackColor = true;
            this.btnTestForm.Click += new System.EventHandler(this.btnTestForm_Click);
            // 
            // btnDraftTest
            // 
            this.btnDraftTest.Location = new System.Drawing.Point(528, 202);
            this.btnDraftTest.Name = "btnDraftTest";
            this.btnDraftTest.Size = new System.Drawing.Size(75, 23);
            this.btnDraftTest.TabIndex = 14;
            this.btnDraftTest.Text = "Draft test";
            this.btnDraftTest.UseVisualStyleBackColor = true;
            this.btnDraftTest.Click += new System.EventHandler(this.btnDraftTest_Click);
            // 
            // btnAddOscListToChunk
            // 
            this.btnAddOscListToChunk.Location = new System.Drawing.Point(185, 202);
            this.btnAddOscListToChunk.Name = "btnAddOscListToChunk";
            this.btnAddOscListToChunk.Size = new System.Drawing.Size(120, 23);
            this.btnAddOscListToChunk.TabIndex = 17;
            this.btnAddOscListToChunk.Text = "Add";
            this.btnAddOscListToChunk.UseVisualStyleBackColor = true;
            this.btnAddOscListToChunk.Click += new System.EventHandler(this.btnAddOscListToChunk_Click);
            // 
            // btnTestFullChunk
            // 
            this.btnTestFullChunk.Location = new System.Drawing.Point(138, 257);
            this.btnTestFullChunk.Name = "btnTestFullChunk";
            this.btnTestFullChunk.Size = new System.Drawing.Size(120, 23);
            this.btnTestFullChunk.TabIndex = 18;
            this.btnTestFullChunk.Text = "Test full chunk";
            this.btnTestFullChunk.UseVisualStyleBackColor = true;
            this.btnTestFullChunk.Click += new System.EventHandler(this.btnTestFullChunk_Click);
            // 
            // btnSaveChunk
            // 
            this.btnSaveChunk.Location = new System.Drawing.Point(405, 257);
            this.btnSaveChunk.Name = "btnSaveChunk";
            this.btnSaveChunk.Size = new System.Drawing.Size(120, 23);
            this.btnSaveChunk.TabIndex = 20;
            this.btnSaveChunk.Text = "Save chunk...";
            this.btnSaveChunk.UseVisualStyleBackColor = true;
            this.btnSaveChunk.Click += new System.EventHandler(this.btnSaveChunk_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Save chunk";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnLoadChunk
            // 
            this.btnLoadChunk.Location = new System.Drawing.Point(264, 257);
            this.btnLoadChunk.Name = "btnLoadChunk";
            this.btnLoadChunk.Size = new System.Drawing.Size(135, 23);
            this.btnLoadChunk.TabIndex = 22;
            this.btnLoadChunk.Text = "Load chunk...";
            this.btnLoadChunk.UseVisualStyleBackColor = true;
            this.btnLoadChunk.Click += new System.EventHandler(this.btnLoadChunk_Click);
            // 
            // btnSaveChunkWave
            // 
            this.btnSaveChunkWave.Location = new System.Drawing.Point(528, 257);
            this.btnSaveChunkWave.Name = "btnSaveChunkWave";
            this.btnSaveChunkWave.Size = new System.Drawing.Size(120, 23);
            this.btnSaveChunkWave.TabIndex = 23;
            this.btnSaveChunkWave.Text = "Save chunk wave...";
            this.btnSaveChunkWave.UseVisualStyleBackColor = true;
            this.btnSaveChunkWave.Click += new System.EventHandler(this.btnSaveChunkWave_Click);
            // 
            // chunkTree
            // 
            this.chunkTree.CheckBoxes = true;
            this.chunkTree.HideSelection = false;
            this.chunkTree.Location = new System.Drawing.Point(12, 286);
            this.chunkTree.Name = "chunkTree";
            this.chunkTree.Size = new System.Drawing.Size(272, 263);
            this.chunkTree.TabIndex = 21;
            // 
            // waveFormSelected
            // 
            this.waveFormSelected.AllowChangeDuration = true;
            this.waveFormSelected.Amplitude = 15000;
            this.waveFormSelected.Duration = 1000;
            this.waveFormSelected.Frequency = 440;
            this.waveFormSelected.Location = new System.Drawing.Point(290, 286);
            this.waveFormSelected.Name = "waveFormSelected";
            this.waveFormSelected.Size = new System.Drawing.Size(403, 214);
            this.waveFormSelected.TabIndex = 19;
            // 
            // waveFormControl
            // 
            this.waveFormControl.AllowChangeDuration = true;
            this.waveFormControl.Amplitude = 15000;
            this.waveFormControl.Duration = 1000;
            this.waveFormControl.Frequency = 440;
            this.waveFormControl.Location = new System.Drawing.Point(131, -18);
            this.waveFormControl.Name = "waveFormControl";
            this.waveFormControl.Size = new System.Drawing.Size(472, 214);
            this.waveFormControl.TabIndex = 15;
            // 
            // lvWaveForms
            // 
            this.lvWaveForms.CheckBoxes = true;
            this.lvWaveForms.FullRowSelect = true;
            this.lvWaveForms.ListLabel = null;
            this.lvWaveForms.Location = new System.Drawing.Point(4, 9);
            this.lvWaveForms.Name = "lvWaveForms";
            this.lvWaveForms.Size = new System.Drawing.Size(121, 201);
            this.lvWaveForms.TabIndex = 8;
            this.lvWaveForms.UseCompatibleStateImageBehavior = false;
            this.lvWaveForms.View = System.Windows.Forms.View.Details;
            // 
            // audioChunkTreeView1
            // 
            this.audioChunkTreeView1.CheckBoxes = true;
            this.audioChunkTreeView1.HideSelection = false;
            this.audioChunkTreeView1.LineColor = System.Drawing.Color.Empty;
            this.audioChunkTreeView1.Location = new System.Drawing.Point(0, 0);
            this.audioChunkTreeView1.Name = "audioChunkTreeView1";
            treeNode15.Checked = true;
            treeNode15.Name = "";
            treeNode15.Text = "Play list";
            treeNode16.Checked = true;
            treeNode16.Name = "";
            treeNode16.Text = "Play list";
            treeNode17.Checked = true;
            treeNode17.Name = "";
            treeNode17.Text = "Play list";
            treeNode18.Checked = true;
            treeNode18.Name = "";
            treeNode18.Text = "Play list";
            this.audioChunkTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            this.audioChunkTreeView1.Size = new System.Drawing.Size(121, 97);
            this.audioChunkTreeView1.TabIndex = 0;
            // 
            // audioChunkTreeView2
            // 
            this.audioChunkTreeView2.CheckBoxes = true;
            this.audioChunkTreeView2.HideSelection = false;
            this.audioChunkTreeView2.LineColor = System.Drawing.Color.Empty;
            this.audioChunkTreeView2.Location = new System.Drawing.Point(0, 0);
            this.audioChunkTreeView2.Name = "audioChunkTreeView2";
            treeNode19.Checked = true;
            treeNode19.Name = "";
            treeNode19.Text = "Play list";
            treeNode20.Checked = true;
            treeNode20.Name = "";
            treeNode20.Text = "Play list";
            treeNode21.Checked = true;
            treeNode21.Name = "";
            treeNode21.Text = "Play list";
            this.audioChunkTreeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            this.audioChunkTreeView2.Size = new System.Drawing.Size(121, 97);
            this.audioChunkTreeView2.TabIndex = 0;
            // 
            // btnNewChunk
            // 
            this.btnNewChunk.Location = new System.Drawing.Point(12, 257);
            this.btnNewChunk.Name = "btnNewChunk";
            this.btnNewChunk.Size = new System.Drawing.Size(120, 23);
            this.btnNewChunk.TabIndex = 24;
            this.btnNewChunk.Text = "New chunk";
            this.btnNewChunk.UseVisualStyleBackColor = true;
            this.btnNewChunk.Click += new System.EventHandler(this.btnNewChunk_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 564);
            this.Controls.Add(this.btnNewChunk);
            this.Controls.Add(this.btnSaveChunkWave);
            this.Controls.Add(this.btnLoadChunk);
            this.Controls.Add(this.chunkTree);
            this.Controls.Add(this.btnSaveChunk);
            this.Controls.Add(this.waveFormSelected);
            this.Controls.Add(this.btnTestFullChunk);
            this.Controls.Add(this.btnAddOscListToChunk);
            this.Controls.Add(this.waveFormControl);
            this.Controls.Add(this.btnDraftTest);
            this.Controls.Add(this.lvWaveForms);
            this.Controls.Add(this.btnTestForm);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestForm;
        private WaveFormListview lvWaveForms;
        private System.Windows.Forms.Button btnDraftTest;
        private WaveFormControl waveFormControl;
        private CustomControls.AudioChunkTreeView audioChunkTreeView1;
        private CustomControls.AudioChunkTreeView audioChunkTreeView2;
        private System.Windows.Forms.Button btnAddOscListToChunk;
        private System.Windows.Forms.Button btnTestFullChunk;
        private WaveFormControl waveFormSelected;
        private System.Windows.Forms.Button btnSaveChunk;
        private System.Windows.Forms.Button button1;
        private CustomControls.AudioChunkTreeView chunkTree;
        private System.Windows.Forms.Button btnLoadChunk;
        private System.Windows.Forms.Button btnSaveChunkWave;
        private System.Windows.Forms.Button btnNewChunk;

    }
}

