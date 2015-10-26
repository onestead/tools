namespace Jp.Co.Onestead.Win.Clipbot.View
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new Jp.Co.Onestead.Win.Clipbot.View.ExDataGridView();
            this.BoardText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.bPinn = new System.Windows.Forms.CheckBox();
            this.bSwitch = new System.Windows.Forms.CheckBox();
            this.bFormClose = new System.Windows.Forms.Button();
            this.bGridRowRemove = new System.Windows.Forms.Button();
            this.bGridRowUp = new System.Windows.Forms.Button();
            this.bGridRowDown = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(28, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(252, 254);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BoardText});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(255, 234);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValueNeeded);
            this.dataGridView1.MouseLeave += new System.EventHandler(this.dataGridView1_MouseLeave);
            // 
            // BoardText
            // 
            this.BoardText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BoardText.DataPropertyName = "BoardText";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.BoardText.DefaultCellStyle = dataGridViewCellStyle1;
            this.BoardText.HeaderText = "テキスト";
            this.BoardText.Name = "BoardText";
            this.BoardText.ReadOnly = true;
            this.BoardText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BoardText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BoardText.ToolTipText = "クリップボードへ転送されたテキストです。";
            this.BoardText.Width = 255;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.MouseLeave += new System.EventHandler(this.dataGridView1_MouseLeave);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.DarkOrange;
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(284, 262);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.TabStop = false;
            this.splitContainer1.MouseHover += new System.EventHandler(this.splitContainer1_MouseHover);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.splitContainer2.Panel1.Controls.Add(this.bPinn);
            this.splitContainer2.Panel1.Controls.Add(this.bSwitch);
            this.splitContainer2.Panel1.Controls.Add(this.bFormClose);
            this.splitContainer2.Panel1.Controls.Add(this.bGridRowRemove);
            this.splitContainer2.Panel1.Controls.Add(this.bGridRowUp);
            this.splitContainer2.Panel1.Controls.Add(this.bGridRowDown);
            this.splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(255, 262);
            this.splitContainer2.SplitterDistance = 27;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 7;
            this.splitContainer2.TabStop = false;
            // 
            // bPinn
            // 
            this.bPinn.Appearance = System.Windows.Forms.Appearance.Button;
            this.bPinn.BackColor = System.Drawing.Color.DarkOrange;
            this.bPinn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bPinn.FlatAppearance.BorderSize = 0;
            this.bPinn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPinn.Image = ((System.Drawing.Image)(resources.GetObject("bPinn.Image")));
            this.bPinn.Location = new System.Drawing.Point(145, 3);
            this.bPinn.Margin = new System.Windows.Forms.Padding(0);
            this.bPinn.Name = "bPinn";
            this.bPinn.Size = new System.Drawing.Size(31, 23);
            this.bPinn.TabIndex = 8;
            this.bPinn.UseVisualStyleBackColor = false;
            // 
            // bSwitch
            // 
            this.bSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.bSwitch.BackColor = System.Drawing.Color.DarkOrange;
            this.bSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bSwitch.FlatAppearance.BorderSize = 0;
            this.bSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSwitch.Image = ((System.Drawing.Image)(resources.GetObject("bSwitch.Image")));
            this.bSwitch.Location = new System.Drawing.Point(105, 3);
            this.bSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.bSwitch.Name = "bSwitch";
            this.bSwitch.Size = new System.Drawing.Size(31, 23);
            this.bSwitch.TabIndex = 7;
            this.bSwitch.UseVisualStyleBackColor = false;
            // 
            // bFormClose
            // 
            this.bFormClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bFormClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bFormClose.FlatAppearance.BorderSize = 0;
            this.bFormClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFormClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bFormClose.Image = ((System.Drawing.Image)(resources.GetObject("bFormClose.Image")));
            this.bFormClose.Location = new System.Drawing.Point(220, 3);
            this.bFormClose.Margin = new System.Windows.Forms.Padding(0);
            this.bFormClose.Name = "bFormClose";
            this.bFormClose.Size = new System.Drawing.Size(31, 23);
            this.bFormClose.TabIndex = 2;
            this.bFormClose.UseVisualStyleBackColor = true;
            this.bFormClose.Click += new System.EventHandler(this.bFormClose_Click);
            // 
            // bGridRowRemove
            // 
            this.bGridRowRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bGridRowRemove.FlatAppearance.BorderSize = 0;
            this.bGridRowRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGridRowRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bGridRowRemove.Image = ((System.Drawing.Image)(resources.GetObject("bGridRowRemove.Image")));
            this.bGridRowRemove.Location = new System.Drawing.Point(66, 3);
            this.bGridRowRemove.Margin = new System.Windows.Forms.Padding(0);
            this.bGridRowRemove.Name = "bGridRowRemove";
            this.bGridRowRemove.Size = new System.Drawing.Size(31, 23);
            this.bGridRowRemove.TabIndex = 3;
            this.bGridRowRemove.UseVisualStyleBackColor = true;
            this.bGridRowRemove.Click += new System.EventHandler(this.bGridRowRemove_Click);
            // 
            // bGridRowUp
            // 
            this.bGridRowUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bGridRowUp.FlatAppearance.BorderSize = 0;
            this.bGridRowUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGridRowUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bGridRowUp.Image = ((System.Drawing.Image)(resources.GetObject("bGridRowUp.Image")));
            this.bGridRowUp.Location = new System.Drawing.Point(4, 3);
            this.bGridRowUp.Margin = new System.Windows.Forms.Padding(0);
            this.bGridRowUp.Name = "bGridRowUp";
            this.bGridRowUp.Size = new System.Drawing.Size(31, 23);
            this.bGridRowUp.TabIndex = 4;
            this.bGridRowUp.UseVisualStyleBackColor = true;
            this.bGridRowUp.Click += new System.EventHandler(this.bGridRowUp_Click);
            // 
            // bGridRowDown
            // 
            this.bGridRowDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bGridRowDown.FlatAppearance.BorderSize = 0;
            this.bGridRowDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGridRowDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bGridRowDown.Image = ((System.Drawing.Image)(resources.GetObject("bGridRowDown.Image")));
            this.bGridRowDown.Location = new System.Drawing.Point(35, 3);
            this.bGridRowDown.Margin = new System.Windows.Forms.Padding(0);
            this.bGridRowDown.Name = "bGridRowDown";
            this.bGridRowDown.Size = new System.Drawing.Size(31, 23);
            this.bGridRowDown.TabIndex = 5;
            this.bGridRowDown.UseVisualStyleBackColor = true;
            this.bGridRowDown.Click += new System.EventHandler(this.bGridRowDown_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 262);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "media_controls_dark_pause.png");
            this.imageList1.Images.SetKeyName(1, "media_controls_dark_play.png");
            // 
            // timer1
            // 
            this.timer1.AutoReset = false;
            this.timer1.Enabled = true;
            this.timer1.Interval = 500D;
            this.timer1.SynchronizingObject = this;
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmMain";
            this.Opacity = 0.6D;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "クリップボード履歴管理アプリ【メイン画面】";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private ExDataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bGridRowDown;
        private System.Windows.Forms.Button bGridRowUp;
        private System.Windows.Forms.Button bGridRowRemove;
        private System.Windows.Forms.Button bFormClose;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox bSwitch;
        private System.Timers.Timer timer1;
        private System.Windows.Forms.CheckBox bPinn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardText;
    }
}

