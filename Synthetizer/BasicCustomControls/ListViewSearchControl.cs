using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicCustomControls
{

    public partial class ListViewSearchControl : UserControl
    {

        public event EventHandler OnClose;

        public ListViewSearchControl()
        {
            InitializeComponent();
            this.Visible = false;
            //this.Dock = DockStyle.Top;
        }

        private ListView _lvParent;
        public ListView ListViewParent
        {
            get { return _lvParent; }
            set { 
                _lvParent = value;
                OnListViewParentChanged();
            }
        }

        private void OnListViewParentChanged()
        {
            if (_lvParent == null) return;

       }


        public void OnDisplay()
        {
            if (_lvParent == null) return;

            this.Width = _lvParent.Width;
            this.Location = _lvParent.Location;


            //this.Top -= this.Height;
            this.Visible = true;

            //_lvParent.Height -= this.Height;
            //_lvParent.Top += this.Height;

            _foundItems.Clear();
            _foundItemIdex = 0;

            btnPrev.Enabled = false;
            btnNext.Enabled = false;

            cmbColumns.Items.Clear();

            cmbColumns.Items.Add("All");
            foreach (ColumnHeader col in _lvParent.Columns)
            {
                cmbColumns.Items.Add(col.Text);
            }
            //foreach (ListViewItem lvi in _lvParent.Items)
            //{
            //    if (!autoCompletionSource.Contains(lvi.Text))
            //        autoCompletionSource.Add(lvi.Text);
            //    foreach (ListViewItem.ListViewSubItem item in lvi.SubItems)
            //    {
            //        if (!autoCompletionSource.Contains(item.Text))
            //            autoCompletionSource.Add(item.Text);
            //    }
            //}

            //txtSearchString.AutoCompleteCustomSource = autoCompletionSource;
            cmbColumns.SelectedIndex = 0;

            this.BringToFront();
            txtSearchString.Focus();
        }

        private void txtSearchString_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            if (this.OnClose != null)
                this.OnClose.Invoke(this, null);

            this.Visible = false;
        }

        List<ListViewItem> _foundItems = new List<ListViewItem>();
        int _foundItemIdex = 0;

        private void txtSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            if (_lvParent == null) return;
            if (e.KeyCode != Keys.Enter) return;

            _foundItems.Clear();
            _foundItemIdex = 0;

            foreach (ListViewItem item in _lvParent.Items)
            {
                item.Selected = false;
            }

            btnNext.Enabled = false;
            btnPrev.Enabled = false;


            if (!string.IsNullOrWhiteSpace(txtSearchString.Text))
            {
                string searchStr = txtSearchString.Text.ToLower();

                foreach (ListViewItem lvi in _lvParent.Items)
                {
                    bool found = false;
                    
                    if (cmbColumns.Text != "All")
                    {
                        foreach (ColumnHeader col in _lvParent.Columns)
                        {
                            if (col.Text == cmbColumns.Text)
                            {
                                found = lvi.SubItems[col.DisplayIndex].Text.ToLower().Contains(searchStr);
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (!lvi.Text.Contains(searchStr))
                        {
                            found = false;
                            foreach (ListViewItem.ListViewSubItem item in lvi.SubItems)
                            {
                                if (item.Text.ToLower().Contains(searchStr))
                                {
                                    found = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (found)
                        _foundItems.Add(lvi);
                }
            }

            if (_foundItems.Count > 0)
            {
                _foundItems[0].Selected = true;
                _foundItems[0].EnsureVisible();
            }
            if (_foundItems.Count > 1)
            {
                btnNext.Enabled = true;
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_foundItems.Count > (_foundItemIdex +1))
            {
                foreach (ListViewItem item in _lvParent.Items)
                {
                    item.Selected = false;
                }

                _foundItemIdex++;
                _foundItems[_foundItemIdex].Selected = true;
                _foundItems[_foundItemIdex].EnsureVisible();
            }

            btnNext.Enabled = (_foundItems.Count > (_foundItemIdex + 1));
            btnPrev.Enabled = (_foundItemIdex > 0);

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_foundItemIdex > 0)
            {
                foreach (ListViewItem item in _lvParent.Items)
                {
                    item.Selected = false;
                }

                _foundItemIdex--;
                _foundItems[_foundItemIdex].Selected = true;
                _foundItems[_foundItemIdex].EnsureVisible();
            }

            btnNext.Enabled = (_foundItems.Count > (_foundItemIdex + 1));
            btnPrev.Enabled = (_foundItemIdex > 0);
        }
    }
}
