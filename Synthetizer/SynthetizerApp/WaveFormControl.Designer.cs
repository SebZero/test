namespace SynthetizerApp
{
    partial class WaveFormControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.tbDuration = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.numAmplitude = new System.Windows.Forms.NumericUpDown();
            this.tbAmplitude = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numFrequency = new System.Windows.Forms.NumericUpDown();
            this.tbFrequency = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAmplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Duration";
            // 
            // numDuration
            // 
            this.numDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numDuration.Location = new System.Drawing.Point(413, 156);
            this.numDuration.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(68, 20);
            this.numDuration.TabIndex = 19;
            this.numDuration.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tbDuration
            // 
            this.tbDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDuration.AutoSize = false;
            this.tbDuration.Location = new System.Drawing.Point(3, 177);
            this.tbDuration.Maximum = 5000;
            this.tbDuration.Minimum = 1;
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Size = new System.Drawing.Size(487, 23);
            this.tbDuration.TabIndex = 18;
            this.tbDuration.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbDuration.Value = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Amplitude";
            // 
            // numAmplitude
            // 
            this.numAmplitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAmplitude.Location = new System.Drawing.Point(413, 103);
            this.numAmplitude.Maximum = new decimal(new int[] {
            32500,
            0,
            0,
            0});
            this.numAmplitude.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAmplitude.Name = "numAmplitude";
            this.numAmplitude.Size = new System.Drawing.Size(68, 20);
            this.numAmplitude.TabIndex = 16;
            this.numAmplitude.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // tbAmplitude
            // 
            this.tbAmplitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAmplitude.AutoSize = false;
            this.tbAmplitude.Location = new System.Drawing.Point(3, 124);
            this.tbAmplitude.Maximum = 32500;
            this.tbAmplitude.Minimum = 100;
            this.tbAmplitude.Name = "tbAmplitude";
            this.tbAmplitude.Size = new System.Drawing.Size(487, 23);
            this.tbAmplitude.TabIndex = 15;
            this.tbAmplitude.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAmplitude.Value = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Frequency";
            // 
            // numFrequency
            // 
            this.numFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numFrequency.Location = new System.Drawing.Point(413, 50);
            this.numFrequency.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numFrequency.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFrequency.Name = "numFrequency";
            this.numFrequency.Size = new System.Drawing.Size(68, 20);
            this.numFrequency.TabIndex = 13;
            this.numFrequency.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tbFrequency
            // 
            this.tbFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFrequency.AutoSize = false;
            this.tbFrequency.Location = new System.Drawing.Point(3, 69);
            this.tbFrequency.Maximum = 5000;
            this.tbFrequency.Minimum = 10;
            this.tbFrequency.Name = "tbFrequency";
            this.tbFrequency.Size = new System.Drawing.Size(487, 23);
            this.tbFrequency.TabIndex = 12;
            this.tbFrequency.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbFrequency.Value = 10;
            // 
            // WaveFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.tbDuration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numAmplitude);
            this.Controls.Add(this.tbAmplitude);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numFrequency);
            this.Controls.Add(this.tbFrequency);
            this.Name = "WaveFormControl";
            this.Size = new System.Drawing.Size(493, 233);
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAmplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.TrackBar tbDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAmplitude;
        private System.Windows.Forms.TrackBar tbAmplitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFrequency;
        private System.Windows.Forms.TrackBar tbFrequency;
    }
}
