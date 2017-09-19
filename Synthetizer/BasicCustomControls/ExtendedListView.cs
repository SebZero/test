using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace BasicCustomControls
{
    public class ExtendedListView : ListView
    {

        #region Win32 Delclaration


        private const int WM_HSCROLL = 0x0114;
        private const int WM_VSCROLL = 0x0115;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_LBUTTONUP = 0x0202;
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETGROUPINFO = (LVM_FIRST + 147);
        private const int LVGF_STATE = 4;

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr window, int message, int wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct LVGROUP
        {
            public int cbSize;
            public int mask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszHeader;
            public int cchHeader;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszFooter;
            public int cchFooter;
            public int iGroupId;
            public int stateMask;
            public int state;
            public int uAlign;
        }

        public enum GroupState : int
        {
            COLLAPSIBLE = 8,
            COLLAPSED = 1,
            EXPANDED = 0
        }


        #endregion

        public event EventHandler Scroll;

        ListViewSearchControl _searchControl =null;

        public ExtendedListView(): base()
        {
            this.SizeChanged += new EventHandler(ExtendedListView_SizeChanged);
            this.HideSelection = false;
        }

        private void ExtendedListView_SizeChanged(object sender, EventArgs e)
        {
            if (_searchControl != null)
            {
                _searchControl.Width = this.Width;
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (VirtualMode) return;

            if (this.SelectedItems.Count > 0)
            {
                base.OnMouseDoubleClick(e);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            SetWindowTheme(this.Handle, "explorer", null);
            base.OnHandleCreated(e);
        }

        public static void SetWindowTheme(IntPtr handle)
        {
            SetWindowTheme(handle, "Explorer", null);
        }

        protected override void InitLayout()
        {
            base.InitLayout();
        }

        protected void OnScroll()
        {
            if (this.Scroll != null) this.Scroll.Invoke(this, EventArgs.Empty);
        }
        private bool checkFromDoubleClick = false;

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            if (this.checkFromDoubleClick)
            {
                ice.NewValue = ice.CurrentValue;
                this.checkFromDoubleClick = false;
            }
            else
                base.OnItemCheck(ice);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Is this a double-click?
            if ((e.Button == MouseButtons.Left) && (e.Clicks > 1))
            {
                this.checkFromDoubleClick = true;
            }
            base.OnMouseDown(e);
        }


        private Control FindParentWindow()
        {
            Control parent = this.Parent;
            while (parent != null)
            {
                if (parent.GetType() == typeof(Form) || parent.GetType() == typeof(TabPage))
                {
                    return parent;
                }
                else if (parent.GetType() == typeof(SplitContainer))
                {
                    return parent.Parent;
                }
                parent = parent.Parent;
            }
            return this.Parent;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            this.checkFromDoubleClick = false;

            if (e.Control && e.KeyCode == Keys.A) SelectAllItems();
            if (e.Control && e.KeyCode == Keys.C) CopySelectedItems();
            if (e.Control && e.KeyCode == Keys.F) DispalaySearchControl();

            base.OnKeyDown(e);
        }

        virtual protected void DispalaySearchControl()
        {
            if (_searchControl == null)
            {
                _searchControl = new ListViewSearchControl();
                base.Parent.Controls.Add(_searchControl);
            }

            
            _searchControl.ListViewParent = this;
            _searchControl.OnDisplay();
        }


        virtual protected void CopySelectedItems()
        {
            if (SelectedItems == null || SelectedItems.Count < 1)
                return;

            StringBuilder sb = new StringBuilder();
            
            foreach (ListViewItem lvi in SelectedItems)
            {
                foreach (ListViewItem.ListViewSubItem item in lvi.SubItems)
                {
                    sb.Append(item.Text);
                    sb.Append('\t');
                }
                sb.Remove(sb.Length - 1, 1);
                sb.AppendLine();
            }

            Clipboard.SetText(sb.ToString());
        }

        virtual protected void SelectAllItems()
        {
            if (!this.MultiSelect) return;
            
            foreach (ListViewItem lvi in Items)
            {
                lvi.Selected = true;
            }
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            bool needRedraw = false;

            if (m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL || m.Msg == WM_MOUSEWHEEL)
            {
                this.OnScroll();
            }
            else if (m.Msg == WM_LBUTTONUP)
            {
                base.DefWndProc(ref m);
                needRedraw = true;
            }
                
            base.WndProc(ref m);

            if (needRedraw)
            {
                Application.DoEvents();
                this.Invalidate(true);
            }
        }

        // Get private member 'ID' of the ListViewGroup
        private static int GetGroupID(ListViewGroup lvGroup)
        {
            int rtnval = 0;
            Type GrpTp = lvGroup.GetType();
            if (GrpTp != null)
            {
                PropertyInfo pi = GrpTp.GetProperty("ID", BindingFlags.NonPublic |  BindingFlags.Instance);
                if (pi != null)
                {
                    object tmprtnval = pi.GetValue(lvGroup, null);
                    if (tmprtnval != null)
                    {
                        rtnval = (int)tmprtnval;
                    }
                }
            }
            return rtnval;
        }

        public void SetGroupState(ListViewGroup lvGroup, GroupState state)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                LVGROUP group = new LVGROUP();
                int size = Marshal.SizeOf(group);
                ptr = Marshal.AllocHGlobal(size);
                group.cbSize = size;
                group.state = (int)state;
                group.mask = LVGF_STATE;
                group.iGroupId = GetGroupID(lvGroup);
                Marshal.StructureToPtr(group, ptr, false);
                SendMessage(this.Handle, LVM_SETGROUPINFO, group.iGroupId, ptr);
            }
            catch (Exception) { }
            finally
            {
                if (ptr != IntPtr.Zero) Marshal.FreeHGlobal(ptr);
            }
        }

        public void SetGroupCollapse(GroupState state)
        {
            
            IntPtr ptr = IntPtr.Zero;
            try
            {
                LVGROUP group = new LVGROUP();
                int size = Marshal.SizeOf(group);
                ptr = Marshal.AllocHGlobal(size);
                for (int i = 0; i < this.Groups.Count; i++)
                {
                    try
                    {
                        group.cbSize = size;
                        group.state = (int)state;
                        group.mask = LVGF_STATE;
                        group.iGroupId = GetGroupID(this.Groups[i]);
                        Marshal.StructureToPtr(group, ptr, false);
                        SendMessage(this.Handle, LVM_SETGROUPINFO, group.iGroupId, ptr);
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }
            finally
            {
                if (ptr != IntPtr.Zero) Marshal.FreeHGlobal(ptr);
            }
        }

    }
}

