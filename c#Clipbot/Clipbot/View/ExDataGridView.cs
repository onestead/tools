using System.Drawing;
using System.Windows.Forms;
using System;

namespace Jp.Co.Onestead.Win.Clipbot.View
{
    public class ExDataGridView : DataGridView
    {
        private void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            if (!DesignMode
                    && !VerticalScrollBar.Visible)
            {
                VerticalScrollBar.Location = new Point(ClientRectangle.Width - VerticalScrollBar.Width, 0);
                VerticalScrollBar.Size = new Size(VerticalScrollBar.Width, ClientRectangle.Height);
                VerticalScrollBar.Show();
            }
        }
        public ExDataGridView()
            : base()
        {
            VerticalScrollBar.Visible = true;
            VerticalScrollBar.VisibleChanged += VerticalScrollBar_VisibleChanged;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            VerticalScrollBar_VisibleChanged(VerticalScrollBar, default(EventArgs));
        }
    }
}
