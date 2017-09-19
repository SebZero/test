using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;


namespace BasicCustomControls
{
    public partial class SelectFolderDialog : Form
    {

        ImageList _smallImgList = new ImageList();
        ImageList _largeImgList = new ImageList();

        ImageList _imgTree = new ImageList();

        public DirectoryInfo SelectedDirectory { get; set; }
        public string StartPath { get; set; }
        public bool ShouldExists { get; set; }

        public SelectFolderDialog()
        {
            InitializeComponent();
            _smallImgList.ColorDepth = ColorDepth.Depth32Bit;
            _largeImgList.ColorDepth = ColorDepth.Depth32Bit;
            _imgTree.ColorDepth = ColorDepth.Depth32Bit;

            _smallImgList.ImageSize = new Size(16, 16);
            _largeImgList.ImageSize = new Size(32, 32);
            _imgTree.ImageSize = new Size(16, 16);

            lvExplorer.View = View.List;

            lvExplorer.MouseDoubleClick += new MouseEventHandler(lvExplorer_MouseDoubleClick);
            lvExplorer.MouseDown += new MouseEventHandler(lvExplorer_MouseDown);

            this.lvExplorer.AfterLabelEdit += lvExplorer_AfterLabelEdit;
            this.Shown += new EventHandler(Form1_Shown);
        }

        private void lvExplorer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (_curPath != null)
            {
                if (string.IsNullOrWhiteSpace(e.Label))
                {
                    lvExplorer.LabelEdit = false;
                    lvExplorer.Items.RemoveAt(e.Item);
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(Path.Combine(_curPath.FullName, e.Label));
                lvExplorer.LabelEdit = false;
                string iconId = di.FullName;
                FolderItem item = new FolderItem(di, iconId);

                if (!_smallImgList.Images.ContainsKey(iconId))
                {
                    Icon smallIcon = ShellApi.GetFolderIcon(di.FullName);
                    _smallImgList.Images.Add(iconId, smallIcon);
                }

                lvExplorer.Items[e.Item].ImageKey = iconId;

                lvExplorer.Items[e.Item].Tag = item;
                txtSubDir.Text = e.Label;
            }
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            lvExplorer.SmallImageList = _smallImgList;
            lvExplorer.LargeImageList = _largeImgList;
   
            //extendedTreeView1.ImageList = _imgTree;
            //extendedTreeView1.StateImageList = _imgTree;
            txtPath.Text = StartPath;
            //LoadSpecialFolders();
            if (string.IsNullOrWhiteSpace(StartPath))
            {
                ListFolders(null);
            }
            else
            {
                _curPath = new DirectoryInfo(StartPath);
                ListFolders(_curPath);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        List<string> _history = new List<string>();
        DirectoryInfo _curPath = null;

        private class FolderItem
        {
            public DirectoryInfo Directory { get; set; }
            public string IconKey { get; set; }

            public FolderItem(DirectoryInfo dir, string iconKey)
            {
                this.Directory = dir;
                this.IconKey = iconKey;
            }
        }

        private class FileItem
        {
            public FileInfo File { get; set; }
            public string IconKey { get; set; }

            public FileItem(FileInfo file, string iconKey)
            {
                this.File = file;
                this.IconKey = iconKey;
            }
        }

        private void LoadDrives()
        {
            TreeNode drivesNodes = new TreeNode("Drives");

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                string iconId = drive.RootDirectory.FullName;
                FolderItem item = new FolderItem(drive.RootDirectory, iconId);

                if (!_imgTree.Images.ContainsKey(iconId))
                {
                    Icon smallIcon = ShellApi.GetFolderIcon(drive.RootDirectory.FullName);

                    _imgTree.Images.Add(iconId, smallIcon);
                }

                string name = (string.IsNullOrWhiteSpace(drive.VolumeLabel) ? drive.Name : drive.VolumeLabel);
                if (drive.DriveType == DriveType.Removable)
                    name += " (Removable)";

                TreeNode node = drivesNodes.Nodes.Add(name);
                node.Tag = item;
                node.ImageKey = iconId;
                node.SelectedImageKey = iconId;
            }

            //if (drivesNodes.Nodes.Count > 0)
            //{
            //    drivesNodes.ImageKey = drivesNodes.Nodes[drivesNodes.Nodes.Count - 1].ImageKey;
            //    drivesNodes.SelectedImageKey = drivesNodes.Nodes[drivesNodes.Nodes.Count - 1].ImageKey;

            //    extendedTreeView1.Nodes.Add(drivesNodes);
            //    drivesNodes.Expand();
            //}
        }


        private void LoadMyComputer()
        {

            //try
            //{
            //    string computerDir = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            //    DirectoryInfo dir = new DirectoryInfo(computerDir);

            //    Icon smallIcon = ShellApi.GetFolderIcon(computerDir);

            //    _imgTree.Images.Add(dir.FullName, smallIcon);

            //    TreeNode userFolderNode = new TreeNode(dir.Name);

            //    userFolderNode.ImageKey = dir.FullName;
            //    userFolderNode.SelectedImageKey = dir.FullName;

            //    foreach (DirectoryInfo file in dir.GetDirectories())
            //    {
            //        string iconId = file.FullName;
            //        FolderItem item = new FolderItem(file, iconId);

            //        if (!_imgTree.Images.ContainsKey(iconId))
            //        {
            //            smallIcon = ShellApi.GetFolderIcon(file.FullName);

            //            _imgTree.Images.Add(iconId, smallIcon);
            //        }

            //        string name = file.Name;

            //        TreeNode node = userFolderNode.Nodes.Add(name);
            //        node.Tag = item;
            //        node.ImageKey = iconId;
            //        node.SelectedImageKey = iconId;
                    
            //    }

            //    if (userFolderNode.Nodes.Count > 0)
            //    {

            //        extendedTreeView1.Nodes.Add(userFolderNode);
            //        userFolderNode.Expand();
            //    }

            //}
            //catch (Exception)
            //{
                
            //}
        }

        private void LoadSpecialFolders()
        {
            LoadDrives();
            //LoadMyComputer();
        }

        private bool _default = false;

        private void ListFolders(DirectoryInfo rootDir)
        {
            btnNewFolder.Visible = false;

            _smallImgList.Images.Clear();

            lvExplorer.BeginUpdate();
            
            lvExplorer.Items.Clear();


            if (rootDir == null)
            {

                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    string iconId = drive.RootDirectory.FullName;
                    FolderItem item = new FolderItem(drive.RootDirectory, iconId);

                    if (!_smallImgList.Images.ContainsKey(iconId))
                    {
                        Icon smallIcon = ShellApi.GetFolderIcon(drive.RootDirectory.FullName);
                        _smallImgList.Images.Add(iconId, smallIcon);
                    }

                    string name = drive.RootDirectory.Name;

                    if (drive.DriveType != DriveType.Network)
                    {
                        try
                        {
                            name = (string.IsNullOrWhiteSpace(drive.VolumeLabel) ? name : drive.VolumeLabel + " (" + name + ")");
                        }
                        catch (Exception) { }
                    }

                    if (drive.DriveType == DriveType.Removable)
                        name += " (Removable)";

                    ListViewItem lvi = lvExplorer.Items.Add(name, iconId);
                    lvi.Tag = item;
                }
            }
            else
            {

                try
                {
                    string defaultIconId = System.IO.Path.GetTempPath();
                    Icon defaultIcon = ShellApi.GetFolderIcon(defaultIconId);

                    if (!_smallImgList.Images.ContainsKey(defaultIconId))
                    {
                        _smallImgList.Images.Add(defaultIconId, defaultIcon);
                    }
                    
                    DirectoryInfo[] dirs = rootDir.GetDirectories();
                    int dirCount = dirs.Length;

                    foreach (DirectoryInfo dir in dirs)
                    {
                        if (dir.Name == "System Volume Information")
                            continue;

                        string iconId = dir.FullName;
                        FolderItem item = new FolderItem(dir, iconId);
                        if (dirCount < 1000)
                        {
                            if (!_smallImgList.Images.ContainsKey(iconId))
                            {
                                Icon smallIcon = ShellApi.GetFolderIcon(dir.FullName);
                                if (smallIcon != null && smallIcon.Handle != IntPtr.Zero)
                                {
                                    _smallImgList.Images.Add(iconId, smallIcon);
                                }
                                else
                                {
                                    iconId = defaultIconId;
                                }

                            }
                        }
                        else
                            iconId = defaultIconId;

                        ListViewItem lvi = lvExplorer.Items.Add(dir.Name, iconId);
                        lvi.Tag = item;
                    }

                    _default = true;
                    txtSubDir.Text = rootDir.Name;
                    btnNewFolder.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            lvExplorer.EndUpdate();
        }


        private void lvExplorer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvExplorer.SelectedItems.Count == 1)
            {
                this.Cursor = Cursors.WaitCursor;
                _curPath = ((FolderItem)lvExplorer.SelectedItems[0].Tag).Directory;
                txtPath.Text = _curPath.FullName;
                txtSubDir.Text = string.Empty;
                ListFolders(_curPath);
                this.Cursor = Cursors.Default;
            }
        }

        private void lvExplorer_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.XButton1)
            {
                this.Cursor = Cursors.WaitCursor;

                if (_curPath != null)
                {
                    ListFolders(_curPath.Parent);
                    _curPath = _curPath.Parent;
                }
                else
                    ListFolders(null);

                if (_curPath == null)
                    txtPath.Text = "";
                else
                    txtPath.Text = _curPath.FullName;

                this.Cursor = Cursors.Default;
            }

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Cursor = Cursors.WaitCursor;

                if (string.IsNullOrWhiteSpace(txtPath.Text))
                {
                    _curPath = null;
                    ListFolders(_curPath);
                }
                else
                {
                    DirectoryInfo dir = new DirectoryInfo(txtPath.Text);
                    if (dir.Exists)
                    {
                        _curPath = dir;
                        ListFolders(_curPath);
                    }
                    else
                        MessageBox.Show("Directory not found.");
                }

                this.Cursor = Cursors.Default;

            }
        }

        private void extendedTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtSubDir.Text) && !_default)
            {
                MessageBox.Show("Please select a directory!", "Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                if (_default)
                {
                    if (_curPath == null)
                    {
                        MessageBox.Show("Please select a directory!", "Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    this.SelectedDirectory = _curPath;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                string newDir = string.Empty;
                if (_curPath == null)
                {
                    DirectoryInfo dirInfo = ((FolderItem)lvExplorer.SelectedItems[0].Tag).Directory;
                    newDir = dirInfo.FullName;
                }
                else
                    newDir = Path.Combine(_curPath.FullName, txtSubDir.Text.Trim());

                if (ShouldExists)
                {
                    if (!Directory.Exists(newDir))
                    {
                        MessageBox.Show("Directory does not exists!", "Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this.SelectedDirectory = new DirectoryInfo(newDir);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnGotoParent_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (_curPath != null)
            {
                ListFolders(_curPath.Parent);
                _curPath = _curPath.Parent;
            }
            else
                ListFolders(null);

            if (_curPath == null)
                txtPath.Text = "";
            else
                txtPath.Text = _curPath.FullName;

            this.Cursor = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void lvExplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvExplorer.SelectedItems.Count == 1)
            {
                txtSubDir.Text = lvExplorer.SelectedItems[0].Text;
                _default = false;
            }
            else
            {
                _default = true;
                if (_curPath == null)
                    txtSubDir.Text = "";
                else
                    txtSubDir.Text = _curPath.Name;
            }
                
        }


        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            if (_curPath != null)
            {
                ListViewItem lvi = lvExplorer.Items.Add("New Folder");
               // DirectoryInfo di = Directory.CreateDirectory();
                string iconId = Path.Combine(_curPath.FullName, "New Folder");
                //FolderItem item = new FolderItem(di, iconId);

                if (!_smallImgList.Images.ContainsKey(iconId))
                {
                    Icon smallIcon = ShellApi.GetFolderIcon(System.IO.Path.GetTempPath());
                    _smallImgList.Images.Add(iconId, smallIcon);
                }
                //lvi.Tag = item;
                lvi.ImageKey = iconId;
                lvExplorer.LabelEdit = true;
                lvi.BeginEdit();
            }
        }

        private void btnNewFolder_MouseHover(object sender, EventArgs e)
        {
            btnNewFolder.Font = new Font(btnNewFolder.Font, FontStyle.Underline);
        }

        private void btnNewFolder_MouseLeave(object sender, EventArgs e)
        {
            btnNewFolder.Font = new Font(btnNewFolder.Font, FontStyle.Regular);
        }





    }
}
