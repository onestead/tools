using System;

namespace Jp.Co.Onestead.Win.Clipbot.Listner
{
    public class ClipboardListnerArgs : EventArgs
    {
        public string Text { get; private set; }
        public ClipboardListnerArgs(string text)
        {
            Text = text;
        }
    }
}
