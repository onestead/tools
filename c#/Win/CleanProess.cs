using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Jp.Co.Onestead.Win
{
    public static class CleanProess
    {
        [DllImport("user32", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32", EntryPoint = "EnumWindows")]
        private static extern int EnumWindows(EnumerateWindowsCallback lpEnumFunc, IntPtr lParam);
        [DllImport("user32", EntryPoint = "GetWindowThreadProcessId")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref uint procId);
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32", EntryPoint = "IsWindowVisible")]
        private static extern int IsWindowVisible(IntPtr hWnd);


        private delegate int EnumerateWindowsCallback(IntPtr hWnd, int lParam);
        private const int WM_DESTROY = 0x0002;
        private const int WM_QUIT = 0x0012;
        private const int WM_CLOSE = 0x0010;
        private const int WM_SHOWWINDOW = 0x0018;
        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x0080;
        private const int WS_VISIBLE = 0x10000000;

        public static int CleanProcess(bool isQuit, string lpClassName, string lpWindowName)
        {
            int count = 0;
            if (string.IsNullOrEmpty(lpWindowName))
                return count;
            IntPtr hWnd = FindWindow(null, lpWindowName);
            if (hWnd != IntPtr.Zero)
            {
                count++;
                if (isQuit)
                {
                    SendMessage(hWnd, WM_SHOWWINDOW, IntPtr.Zero, IntPtr.Zero);
                    SendMessage(hWnd, WM_QUIT, IntPtr.Zero, IntPtr.Zero);
                }
            }
            return count;
        }

        public static int CleanProcess(bool isQuit, string processName)
        {
            int count = 0;
            if (string.IsNullOrEmpty(processName))
                return count;
            System.Diagnostics.Process[] lcProcessList = System.Diagnostics.Process.GetProcessesByName(processName);

            for (int k = 0; k < lcProcessList.Length; k++)
            {
                count++;
                if (!isQuit)
                    continue;
                System.Diagnostics.Process lcProcess = lcProcessList[k];
                if (lcProcess.MainWindowHandle != IntPtr.Zero)
                {
                    lcProcess.Kill();
                }
                else
                {
                    List<IntPtr> hWndList = new List<IntPtr>();
                    EnumWindows(
                        delegate(IntPtr hWnd, int lParam)
                        {
                            uint procId = 0;
                            uint result = GetWindowThreadProcessId(hWnd, ref procId);
                            if (procId == lcProcess.Id)
                                hWndList.Add(hWnd);
                            return 1;
                        }
                        , IntPtr.Zero
                    );
                    foreach (IntPtr hWnd in hWndList)
                    {
                        int style = GetWindowLong(hWnd, GWL_STYLE);
                        int styleEx = GetWindowLong(hWnd, GWL_EXSTYLE);
                        if (style > 0)
                        {
                            lcProcess.Kill();
                        }
                    }
                }
            }
            return count;
        }
    }
}
