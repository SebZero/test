using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace BasicCustomControls
{
    public class ExtendedTreeView : TreeView
    {
        #region Win32 Delclaration

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);

        private const int TV_FIRST = 0x1100;
        private const int TVM_SETBKCOLOR = TV_FIRST + 29;
        private const int TVM_SETEXTENDEDSTYLE = TV_FIRST + 44;

        private const int TVS_EX_DOUBLEBUFFER = 0x0004;

        public const int WM_PRINTCLIENT = 0x0318;
        public const int PRF_CLIENT = 0x00000004;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        #endregion

        public ExtendedTreeView()
            : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            if (!IsWinVistaOrAbove()) SetStyle(ControlStyles.UserPaint, true);
            this.HideSelection = false;
        }

        private void UpdateExtendedStyles()
        {
            int Style = 0;
            if (DoubleBuffered) Style |= TVS_EX_DOUBLEBUFFER;
            if (Style != 0) SendMessage(Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)Style);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateExtendedStyles();
            if (IsWinVistaOrAbove()) SendMessage(Handle, TVM_SETBKCOLOR, IntPtr.Zero, (IntPtr)ColorTranslator.ToWin32(BackColor));
            SetWindowTheme(this.Handle, "explorer", null);

        }

        private bool IsWinVistaOrAbove()
        {
            OperatingSystem OS = Environment.OSVersion;
            return (OS.Platform == PlatformID.Win32NT) && (OS.Version.Major >= 6);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint))
            {
                Message m = new Message();
                m.HWnd = Handle;
                m.Msg = WM_PRINTCLIENT;
                m.WParam = e.Graphics.GetHdc();
                m.LParam = (IntPtr)PRF_CLIENT;
                DefWndProc(ref m);
                e.Graphics.ReleaseHdc(m.WParam);
            }
            base.OnPaint(e);
        }

    }
}
