using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Jp.Co.Onestead.Win.Clipbot.Listner;
using Jp.Co.Onestead.Win.Clipbot.Xsd;

namespace Jp.Co.Onestead.Win.Clipbot.View
{
    partial class MainForm : System.Windows.Forms.Form
    {
        private enum GridColumns : int { BoardText = 0, }
        private const int X1 = 5;
        private const int Y1 = 0;
        private const int X2 = 280;
        private const int Y2 = 0;
        private const double OPACITY0 = 0.0d;
        private const double OPACITY1 = 0.5d;
        private const double OPACITY2 = 1.0d;
        private const string XML_CLIPS = "crips.xml";
        private readonly XmlSerializer __serializer = new XmlSerializer(typeof(Xsd.Clips.BoardDataTable));
        private readonly Rectangle __rectangle = Rectangle.Empty;
        private readonly ClipboardListner __clipboard = null;
            
        private static void UpDownOrDelete(bool? isUp, DataGridView dataGridView1)
        {
            Clips.BoardDataTable clips = null;
            if (dataGridView1 == null
                    || dataGridView1.SelectedCells == null
                    || dataGridView1.SelectedCells.Count < 1
                    || (clips = dataGridView1.DataSource as Clips.BoardDataTable) == null)
                return;
            dataGridView1.SuspendLayout();
            Dictionary<int, int> idxs = new Dictionary<int, int>();
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                idxs.Add(dataGridView1.SelectedCells[i].RowIndex, -1);
            List<int> rows = new List<int>();
            foreach (int id in idxs.Keys)
                rows.Add(id);
            for (int i = rows.Count - 1; i >= 0; i--)
                if (rows[i] < 0
                        || rows[i] >= dataGridView1.RowCount)
                    return;
            rows.Sort();
            if (isUp == null)
            {
                for (int i = rows.Count - 1; i >= 0; i--)
                    clips.Rows.RemoveAt(rows[i]);
            }
            else
            {
                int diff = rows[rows.Count - 1] - rows[0];
                int plus = 1;
                int temp = 0;
                for (int i = 1; i < rows.Count; i++)
                {
                    if (Math.Abs(rows[i - 1] - rows[i]) == 1)
                    {
                        temp++;
                        if (i != rows.Count - 1)
                            continue;
                    }
                    if (plus < temp)
                        plus = temp;
                    temp = 0;
                }
                diff += plus;
                for (int i = 0; i < rows.Count; i++)
                    idxs[rows[i]] = rows[i] + (isUp == true ? -diff : diff);
                for (int i = 0; i < rows.Count; i++)
                    if (idxs[rows[i]] < 0
                            || idxs[rows[i]] >= dataGridView1.RowCount)
                        return;
                List<Clips.BoardRow> boards = new List<Clips.BoardRow>();
                for (int i = rows.Count - 1; i >= 0; i--)
                {
                    Clips.BoardRow board = clips.NewBoardRow();
                    board.ItemArray = clips[rows[i]].ItemArray;
                    boards.Add(board);
                    clips.Rows.RemoveAt(rows[i]);
                }
                for (int i = 0; i < boards.Count; i++)
                    clips.Rows.InsertAt(boards[boards.Count - i - 1], idxs[rows[i]]);
                for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                    dataGridView1.SelectedCells[i--].Selected = false;
                for (int i = 0; i < rows.Count; i++)
                    dataGridView1[(int)GridColumns.BoardText, idxs[rows[i]]].Selected = true;
            }
            dataGridView1.Invalidate();
            dataGridView1.ResumeLayout();
        }

        public MainForm()
        {
            __rectangle = Screen.GetWorkingArea(this);
            __clipboard = new ClipboardListner(this);
            __clipboard.ClipboardHandler += fomr1_ClipBoardChanged;
            InitializeComponent();
            Location = new Point(Point.Empty.X, Y1);
            Size = new Size(X1, __rectangle.Height - Y1);
            bSwitch.Checked = true;
            dataGridView1.DataSource = new Clips.BoardDataTable();
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            timer1.Elapsed += timer1_Elapsed;
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (MousePosition.X <= X1)
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel2Collapsed = true;
                Location = new Point(Point.Empty.X, Y2);
                Size = new Size(X2, __rectangle.Height - Y2);
                Opacity = OPACITY2;
                TopMost = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Clips.BoardDataTable clips = dataGridView1.DataSource as Clips.BoardDataTable;
            if (clips == null)
                return;
            if (File.Exists(XML_CLIPS))
            {
                using (XmlTextReader reader = new XmlTextReader(XML_CLIPS))
                {
                    if (__serializer.CanDeserialize(reader))
                        clips = __serializer.Deserialize(reader) as Clips.BoardDataTable;
                    reader.Close();
                };
                dataGridView1.DataSource = clips;
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clips.BoardDataTable clips = dataGridView1.DataSource as Clips.BoardDataTable;
            if (clips != null)
            {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                using (XmlTextWriter writer = new XmlTextWriter(XML_CLIPS, Encoding.UTF8))
                {
                    __serializer.Serialize(writer, clips);
                    writer.Close();
                };
            }
        }
        private void splitContainer1_MouseHover(object sender,EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }
        private void bGridRowUp_Click(object sender, EventArgs e)
        {
            UpDownOrDelete(true, dataGridView1);
        }
        private void bGridRowDown_Click(object sender, EventArgs e)
        {
            UpDownOrDelete(false, dataGridView1);
        }
        private void bGridRowRemove_Click(object sender, EventArgs e)
        {
            UpDownOrDelete(null, dataGridView1);
        }
        private void bFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void fomr1_ClipBoardChanged(object sender, ClipboardListnerArgs e)
        {
            Clips.BoardDataTable clips = dataGridView1.DataSource as Clips.BoardDataTable;
            if (clips != null)
            {
                string text = (e.Text ?? string.Empty).Trim();
                if (clips != null
                        && !string.IsNullOrEmpty(text))
                {
                    Clips.BoardRow row = clips.NewBoardRow();
                    row.BoardText = text;
                    bool exists = false;
                    for (int i = 0; i < clips.Count; i++)
                    {
                        if (clips[i].BoardText == row.BoardText)
                        {
                            if (i > 0)
                            {
                                clips.Rows.RemoveAt(i);
                                clips.Rows.InsertAt(row, 0);
                            }
                            exists = true;
                            dataGridView1.CurrentCell = dataGridView1[(int)GridColumns.BoardText, 0];
                        }
                    }
                    if (!exists
                            && !bSwitch.Checked)
                    {
                        clips.Rows.InsertAt(row, 0);
                        dataGridView1.CurrentCell = dataGridView1[(int)GridColumns.BoardText, 0];
                    }
                    dataGridView1.Invalidate();
                }
            }
        }
        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            Clips.BoardDataTable clips = dataGridView1.DataSource as Clips.BoardDataTable;
            if (clips == null)
                return;
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = clips[e.RowIndex].BoardText;
                    break;
                default:
                    break;
            }
        }
        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            if (bPinn.Checked)
                return;
            Point point = PointToClient(System.Windows.Forms.Cursor.Position);
            if (point.IsEmpty
                    || point.X >= Size.Width
                    || point.X < 0
                    || point.Y >= Size.Height
                    || point.Y < 0)
            {
                Location = new Point(Point.Empty.X, Y1);
                Size = new Size(X1, __rectangle.Height - Y1);
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel2Collapsed = false;
                Opacity = OPACITY1;
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null
                    || e.ColumnIndex < 0
                    || e.ColumnIndex >= dataGridView1.RowCount
                    || e.RowIndex < 0
                    || e.RowIndex >= dataGridView1.RowCount)
                return;
            Clipboard.SetText(Convert.ToString(dataGridView1[e.ColumnIndex, e.RowIndex].Value));
        }
    }
}
