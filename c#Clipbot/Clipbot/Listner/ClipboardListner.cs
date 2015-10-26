using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Jp.Co.Onestead.Win.Clipbot.Listner
{
    public delegate void ClipboardHandlerDelegate(object sender, ClipboardListnerArgs e);
    public class ClipboardListner : NativeWindow
    {
        [DllImport("user32")]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        [DllImport("user32")]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        [DllImport("user32")]
        public extern static int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        private const int WM_DRAWCLIPBOARD = 0x0308;
        private const int WM_CHANGECBCHAIN = 0x030D;
        private IntPtr next;
        public event ClipboardHandlerDelegate ClipboardHandler = null;
        public ClipboardListner(System.Windows.Forms.Form f)
        {
            f.HandleCreated += new EventHandler(OnHandleCreated);
            f.HandleDestroyed += new EventHandler(OnHandleDestroyed);
        }
        public void OnHandleCreated(object sender, EventArgs e)
        {
            AssignHandle(((System.Windows.Forms.Form)sender).Handle);
            next = SetClipboardViewer(Handle);
        }
        public void OnHandleDestroyed(object sender, EventArgs e)
        {
            bool sts = ChangeClipboardChain(Handle, next);
            ReleaseHandle();
        }
        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            switch (msg.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    if (Clipboard.ContainsText()
                            && ClipboardHandler != null)
                        ClipboardHandler(this, new ClipboardListnerArgs(Clipboard.GetText()));
                    if (next != IntPtr.Zero)
                        SendMessage(next, msg.Msg, msg.WParam, msg.LParam);
                    break;
                case WM_CHANGECBCHAIN:
                    if (msg.WParam == next)
                        next = msg.LParam;
                    if (next != IntPtr.Zero)
                        SendMessage(next, msg.Msg, msg.WParam, msg.LParam);
                    break;
                default:
                    break;
            }
        }
    }
}
