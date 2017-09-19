using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BasicCustomControls;
using System.Runtime.InteropServices;
using SynthetizerLib;

namespace SynthetizerApp
{
    public class ToneListview : ExtendedListView
    {

        public string ListLabel { get; set; }
        ColumnHeader _colName = null;

        CheckBox _mainCheckBox = new CheckBox();
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, uint wParam, uint lParam);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private IntPtr GetHeaderControl(ListView list)
        {
            const int LVM_GETHEADER = 0x1000 + 31;
            return SendMessage(list.Handle, LVM_GETHEADER, 0, 0);
        }

        public ToneListview()
            : base()
        {
            this.DoubleBuffered = true;
            this.View = View.Details;
            this.FullRowSelect = true;
            this.CheckBoxes = true;

            this.HideSelection = true;

            _colName = this.Columns.Add("", 40);
            _mainCheckBox.Text = string.Empty;

        }

        public void InitItems()
        {
            this.Items.Clear();
            AddItems();
        }

        private void AddItems()
        {
            foreach (var item in Enum.GetNames(typeof(WaveType)))
            {
                ListViewItem lvi = new ListViewItem(item);
                lvi.Tag = Enum.Parse(typeof(WaveType), item);
                lvi.Checked = false;
                Items.Add(lvi);
            }

            _checkChanging = false;
        }
        private bool _checkChanging = true;

        public List<WaveType> GetSelectedForms()
        {
            List<WaveType> types = new List<WaveType>();

            foreach (ListViewItem item in CheckedItems)
            {
                types.Add((WaveType)item.Tag);
            }

            return types;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            _colName.Width = 110;

            _mainCheckBox.Text = string.Empty;
            _mainCheckBox.AutoSize = true;
            _mainCheckBox.Text = string.Empty;
            _mainCheckBox.Location = new System.Drawing.Point(2, 4);
            _mainCheckBox.Height = 15;

            _mainCheckBox.Width = 15;

            SetParent(_mainCheckBox.Handle, GetHeaderControl(this));
            _mainCheckBox.Checked = true;

            _mainCheckBox.CheckedChanged += _mainCheckBox_CheckedChanged;
        }

        protected override void OnItemChecked(ItemCheckedEventArgs e)
        {
            if (!_checkChanging)
                base.OnItemChecked(e);
        }


        private void _mainCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.BeginUpdate();

            _checkChanging = true;

            foreach (ListViewItem item in Items)
            {
                item.Checked = _mainCheckBox.Checked;
            }

            this.EndUpdate();

            if (this.Items.Count > 0)
                base.OnItemChecked(new ItemCheckedEventArgs(this.Items[0]));

            _checkChanging = false;
        }


    }
}
