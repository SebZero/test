namespace BasicCustomControls
{
    partial class SelectFolderDialog
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnGotoParent = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSubDir = new System.Windows.Forms.TextBox();
            this.btnNewFolder = new System.Windows.Forms.Label();
            this.lvExplorer = new BasicCustomControls.ExtendedListView();
            ((System.ComponentModel.ISupportInitialize)(this.btnGotoParent)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(28, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(470, 20);
            this.txtPath.TabIndex = 2;
            this.txtPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // btnGotoParent
            // 
            this.btnGotoParent.Image = global::BasicCustomControls.Properties.Resources._112_UpArrowShort_Grey_16x16_72;
            this.btnGotoParent.Location = new System.Drawing.Point(9, 13);
            this.btnGotoParent.Name = "btnGotoParent";
            this.btnGotoParent.Size = new System.Drawing.Size(16, 16);
            this.btnGotoParent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGotoParent.TabIndex = 4;
            this.btnGotoParent.TabStop = false;
            this.btnGotoParent.Click += new System.EventHandler(this.btnGotoParent_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(342, 320);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(423, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSubDir
            // 
            this.txtSubDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSubDir.Location = new System.Drawing.Point(28, 320);
            this.txtSubDir.Name = "txtSubDir";
            this.txtSubDir.Size = new System.Drawing.Size(223, 20);
            this.txtSubDir.TabIndex = 9;
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewFolder.AutoSize = true;
            this.btnNewFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewFolder.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnNewFolder.Location = new System.Drawing.Point(257, 325);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(58, 13);
            this.btnNewFolder.TabIndex = 10;
            this.btnNewFolder.Text = "New folder";
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            this.btnNewFolder.MouseLeave += new System.EventHandler(this.btnNewFolder_MouseLeave);
            this.btnNewFolder.MouseHover += new System.EventHandler(this.btnNewFolder_MouseHover);
            // 
            // lvExplorer
            // 
            this.lvExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvExplorer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvExplorer.Location = new System.Drawing.Point(9, 40);
            this.lvExplorer.Name = "lvExplorer";
            this.lvExplorer.Size = new System.Drawing.Size(489, 258);
            this.lvExplorer.TabIndex = 3;
            this.lvExplorer.UseCompatibleStateImageBehavior = false;
            this.lvExplorer.SelectedIndexChanged += new System.EventHandler(this.lvExplorer_SelectedIndexChanged);
            // 
            // SelectFolderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(510, 355);
            this.Controls.Add(this.btnNewFolder);
            this.Controls.Add(this.txtSubDir);
            this.Controls.Add(this.lvExplorer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnGotoParent);
            this.Controls.Add(this.txtPath);
            this.Name = "SelectFolderDialog";
            this.Text = "Select folder";
            ((System.ComponentModel.ISupportInitialize)(this.btnGotoParent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private BasicCustomControls.ExtendedListView lvExplorer;
        private System.Windows.Forms.PictureBox btnGotoParent;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSubDir;
        private System.Windows.Forms.Label btnNewFolder;
    }
}

