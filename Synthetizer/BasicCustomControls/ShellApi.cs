using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace BasicCustomControls
{
    public class ShellApi
    {
        // Win32 Shell API

        private const uint SHGFI_ICON = 0x000000100;
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
        private const uint SHGFI_OPENICON = 0x000000002;
        private const uint SHGFI_SMALLICON = 0x000000001;
        private const uint SHGFI_LARGEICON = 0x000000000;
        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        private const uint FILE_ATTRIBUTE_FILE = 0x00000100;

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };


        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DestroyIcon(IntPtr hIcon);


        public static Icon GetFolderIcon(string folder)
        {
            try
            {
                SHFILEINFO shinfoSmall = new SHFILEINFO();
                
                IntPtr hImgSmall = SHGetFileInfo(folder, FILE_ATTRIBUTE_DIRECTORY, ref shinfoSmall, (uint)Marshal.SizeOf(shinfoSmall), SHGFI_ICON | SHGFI_SMALLICON);
                Icon smallIcon = Icon.FromHandle(shinfoSmall.hIcon);

                return smallIcon;
            }
            catch (Exception) { }

            return null;
        }

        public static Icon GetFileIcon(string folder)
        {
            try
            {
                SHFILEINFO shinfoSmall = new SHFILEINFO();

                IntPtr hImgSmall = SHGetFileInfo(folder, FILE_ATTRIBUTE_FILE, ref shinfoSmall, (uint)Marshal.SizeOf(shinfoSmall), SHGFI_ICON | SHGFI_SMALLICON);
                Icon smallIcon = Icon.FromHandle(shinfoSmall.hIcon);
                return smallIcon;
            }
            catch (Exception) { }

            return null;
        }

    }
}
