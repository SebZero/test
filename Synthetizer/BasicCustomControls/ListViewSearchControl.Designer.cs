namespace BasicCustomControls
{
    partial class ListViewSearchControl
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
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.rdContains = new System.Windows.Forms.RadioButton();
            this.rdLike = new System.Windows.Forms.RadioButton();
            this.cmbColumns = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearchString
            // 
            this.txtSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchString.Location = new System.Drawing.Point(50, 3);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(337, 20);
            this.txtSearchString.TabIndex = 0;
            this.txtSearchString.TextChanged += new System.EventHandler(this.txtSearchString_TextChanged);
            this.txtSearchString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchString_KeyDown);
            // 
            // rdContains
            // 
            this.rdContains.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdContains.AutoSize = true;
            this.rdContains.BackColor = System.Drawing.SystemColors.Control;
            this.rdContains.Location = new System.Drawing.Point(450, 29);
            this.rdContains.Name = "rdContains";
            this.rdContains.Size = new System.Drawing.Size(66, 17);
            this.rdContains.TabIndex = 1;
            this.rdContains.TabStop = true;
            this.rdContains.Text = "Contains";
            this.rdContains.UseVisualStyleBackColor = false;
            // 
            // rdLike
            // 
            this.rdLike.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdLike.AutoSize = true;
            this.rdLike.BackColor = System.Drawing.SystemColors.Control;
            this.rdLike.Location = new System.Drawing.Point(540, 29);
            this.rdLike.Name = "rdLike";
            this.rdLike.Size = new System.Drawing.Size(45, 17);
            this.rdLike.TabIndex = 2;
            this.rdLike.TabStop = true;
            this.rdLike.Text = "Like";
            this.rdLike.UseVisualStyleBackColor = false;
            // 
            // cmbColumns
            // 
            this.cmbColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbColumns.FormattingEnabled = true;
            this.cmbColumns.Location = new System.Drawing.Point(410, 2);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(121, 21);
            this.cmbColumns.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "in";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnClose.Location = new System.Drawing.Point(620, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 15);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(570, 1);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(29, 23);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(536, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ListViewSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbColumns);
            this.Controls.Add(this.rdLike);
            this.Controls.Add(this.rdContains);
            this.Controls.Add(this.txtSearchString);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ListViewSearchControl";
            this.Size = new System.Drawing.Size(639, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchString;
        private System.Windows.Forms.RadioButton rdContains;
        private System.Windows.Forms.RadioButton rdLike;
        private System.Windows.Forms.ComboBox cmbColumns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
    }
}
