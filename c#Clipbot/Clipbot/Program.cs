using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Jp.Co.Onestead.Win.Clipbot
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(Application_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new Jp.Co.Onestead.Win.Clipbot.View.MainForm());
        }
        private static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowErrorMessageBox(e.ExceptionObject as Exception);
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowErrorMessageBox(e.Exception);
        }
        private static void ShowErrorMessageBox(Exception e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                while (e != null)
                {
                    sb.Append(e.StackTrace);
                    e = e.InnerException;
                }
                if (sb.Length > 0)
                    MessageBox.Show(sb.ToString());
            }
            catch { }
        }
    }
}
