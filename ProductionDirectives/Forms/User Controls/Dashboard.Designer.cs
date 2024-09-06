namespace ProductionDirectives.Forms.User_Controls
{
    partial class Dashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            materialCard3 = new MaterialSkin.Controls.MaterialCard();
            tableLayoutPanel3 = new TableLayoutPanel();
            groupBox3 = new GroupBox();
            materialButton3 = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            groupBox4 = new GroupBox();
            monthCalendar1 = new MonthCalendar();
            imageList1 = new ImageList(components);
            toolTip1 = new ToolTip(components);
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            dgvChiThiPheDuyet_ChiTiet = new DataGridView();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnRefresh = new MaterialSkin.Controls.MaterialButton();
            dgvChiThiPheDuyet = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            materialCard1.SuspendLayout();
            materialCard3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            materialCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiThiPheDuyet_ChiTiet).BeginInit();
            materialCard2.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiThiPheDuyet).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 10000;
            timer1.Tick += timer1_Tick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(materialCard3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1018, 292);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(materialCard1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 52.13523F));
            tableLayoutPanel2.Size = new Size(742, 286);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(formsPlot1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(2);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(738, 282);
            materialCard1.TabIndex = 2;
            // 
            // formsPlot1
            // 
            formsPlot1.BackColor = Color.White;
            formsPlot1.BorderStyle = BorderStyle.FixedSingle;
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(14, 14);
            formsPlot1.Margin = new Padding(2);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Padding = new Padding(2);
            formsPlot1.Size = new Size(710, 254);
            formsPlot1.TabIndex = 1;
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Controls.Add(tableLayoutPanel3);
            materialCard3.Depth = 0;
            materialCard3.Dock = DockStyle.Fill;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(753, 5);
            materialCard3.Margin = new Padding(5, 5, 5, 3);
            materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(1);
            materialCard3.Size = new Size(260, 284);
            materialCard3.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.White;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel3.Controls.Add(groupBox4, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(1, 1);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 191F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(258, 282);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(materialButton3);
            groupBox3.Controls.Add(materialButton2);
            groupBox3.Controls.Add(materialButton1);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(252, 76);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Hiển thị";
            // 
            // materialButton3
            // 
            materialButton3.AutoSize = false;
            materialButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton3.CharacterCasing = MaterialSkin.Controls.MaterialButton.CharacterCasingEnum.Normal;
            materialButton3.Cursor = Cursors.Hand;
            materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton3.Depth = 0;
            materialButton3.HighEmphasis = true;
            materialButton3.Icon = null;
            materialButton3.Location = new Point(172, 25);
            materialButton3.Margin = new Padding(4, 6, 4, 6);
            materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton3.Name = "materialButton3";
            materialButton3.NoAccentTextColor = Color.Empty;
            materialButton3.Size = new Size(68, 36);
            materialButton3.TabIndex = 2;
            materialButton3.Text = "Tháng";
            materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton3.UseAccentColor = false;
            materialButton3.UseVisualStyleBackColor = true;
            materialButton3.Click += materialButton3_Click;
            materialButton3.MouseHover += materialButton3_MouseHover;
            // 
            // materialButton2
            // 
            materialButton2.AutoSize = false;
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.CharacterCasing = MaterialSkin.Controls.MaterialButton.CharacterCasingEnum.Normal;
            materialButton2.Cursor = Cursors.Hand;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = false;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(15, 25);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(68, 36);
            materialButton2.TabIndex = 1;
            materialButton2.Text = "Ngày";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            materialButton2.MouseHover += materialButton2_MouseHover;
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.CharacterCasing = MaterialSkin.Controls.MaterialButton.CharacterCasingEnum.Normal;
            materialButton1.Cursor = Cursors.Hand;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = false;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(93, 25);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(69, 36);
            materialButton1.TabIndex = 0;
            materialButton1.Text = "Tuần";
            materialButton1.TextImageRelation = TextImageRelation.TextBeforeImage;
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            materialButton1.MouseHover += materialButton1_MouseHover;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(monthCalendar1);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(3, 85);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4);
            groupBox4.Size = new Size(252, 194);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Chọn ngày để xem:";
            // 
            // monthCalendar1
            // 
            monthCalendar1.Dock = DockStyle.Fill;
            monthCalendar1.FirstDayOfWeek = Day.Monday;
            monthCalendar1.Location = new Point(4, 20);
            monthCalendar1.Margin = new Padding(15);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.ShowWeekNumbers = true;
            monthCalendar1.TabIndex = 0;
            monthCalendar1.TrailingForeColor = SystemColors.Desktop;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "menu.png");
            imageList1.Images.SetKeyName(1, "dashboard.png");
            imageList1.Images.SetKeyName(2, "padlock.png");
            imageList1.Images.SetKeyName(3, "user.png");
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 5000;
            toolTip1.ForeColor = SystemColors.Highlight;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Ghi chú:";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 52.46479F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 47.53521F));
            tableLayoutPanel4.Size = new Size(1024, 568);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = Color.White;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 645F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(materialCard4, 0, 0);
            tableLayoutPanel5.Controls.Add(materialCard2, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(4, 302);
            tableLayoutPanel5.Margin = new Padding(4);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(1016, 262);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(dgvChiThiPheDuyet_ChiTiet);
            materialCard4.Depth = 0;
            materialCard4.Dock = DockStyle.Fill;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(649, 2);
            materialCard4.Margin = new Padding(4, 2, 4, 2);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(14);
            materialCard4.Size = new Size(363, 258);
            materialCard4.TabIndex = 6;
            // 
            // dgvChiThiPheDuyet_ChiTiet
            // 
            dgvChiThiPheDuyet_ChiTiet.BackgroundColor = Color.White;
            dgvChiThiPheDuyet_ChiTiet.BorderStyle = BorderStyle.None;
            dgvChiThiPheDuyet_ChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiThiPheDuyet_ChiTiet.Dock = DockStyle.Fill;
            dgvChiThiPheDuyet_ChiTiet.Location = new Point(14, 14);
            dgvChiThiPheDuyet_ChiTiet.Margin = new Padding(0);
            dgvChiThiPheDuyet_ChiTiet.Name = "dgvChiThiPheDuyet_ChiTiet";
            dgvChiThiPheDuyet_ChiTiet.RowTemplate.Height = 40;
            dgvChiThiPheDuyet_ChiTiet.ScrollBars = ScrollBars.None;
            dgvChiThiPheDuyet_ChiTiet.Size = new Size(335, 230);
            dgvChiThiPheDuyet_ChiTiet.TabIndex = 0;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(tableLayoutPanel6);
            materialCard2.Depth = 0;
            materialCard2.Dock = DockStyle.Fill;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(2, 2);
            materialCard2.Margin = new Padding(2, 2, 4, 2);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(639, 258);
            materialCard2.TabIndex = 5;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(tableLayoutPanel7, 0, 1);
            tableLayoutPanel6.Controls.Add(dgvChiThiPheDuyet, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(14, 14);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel6.Size = new Size(611, 230);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 4;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            tableLayoutPanel7.Controls.Add(label4, 2, 0);
            tableLayoutPanel7.Controls.Add(label3, 1, 0);
            tableLayoutPanel7.Controls.Add(label2, 0, 0);
            tableLayoutPanel7.Controls.Add(btnRefresh, 3, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(2, 191);
            tableLayoutPanel7.Margin = new Padding(2);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new Size(607, 37);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(255, 128, 128);
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(381, 0);
            label4.Name = "label4";
            label4.Size = new Size(183, 37);
            label4.TabIndex = 2;
            label4.Text = "> 30 Phút";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(255, 255, 128);
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(192, 0);
            label3.Name = "label3";
            label3.Size = new Size(183, 37);
            label3.TabIndex = 1;
            label3.Text = "< 30 Phút";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.LimeGreen;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(183, 37);
            label2.TabIndex = 0;
            label2.Text = "Đã Submit";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSize = false;
            btnRefresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRefresh.Depth = 0;
            btnRefresh.Dock = DockStyle.Fill;
            btnRefresh.HighEmphasis = true;
            btnRefresh.Icon = (Image)resources.GetObject("btnRefresh.Icon");
            btnRefresh.Location = new Point(567, 0);
            btnRefresh.Margin = new Padding(0);
            btnRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.NoAccentTextColor = Color.Empty;
            btnRefresh.Size = new Size(40, 37);
            btnRefresh.TabIndex = 3;
            btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRefresh.UseAccentColor = false;
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvChiThiPheDuyet
            // 
            dgvChiThiPheDuyet.BackgroundColor = Color.White;
            dgvChiThiPheDuyet.BorderStyle = BorderStyle.None;
            dgvChiThiPheDuyet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiThiPheDuyet.Dock = DockStyle.Fill;
            dgvChiThiPheDuyet.Location = new Point(2, 2);
            dgvChiThiPheDuyet.Margin = new Padding(2);
            dgvChiThiPheDuyet.Name = "dgvChiThiPheDuyet";
            dgvChiThiPheDuyet.ScrollBars = ScrollBars.None;
            dgvChiThiPheDuyet.Size = new Size(607, 185);
            dgvChiThiPheDuyet.TabIndex = 0;
            dgvChiThiPheDuyet.CellContentClick += dgvChiThiPheDuyet_CellContentClick;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel4);
            Name = "Dashboard";
            Size = new Size(1024, 568);
            Load += Dashboard_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            materialCard4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiThiPheDuyet_ChiTiet).EndInit();
            materialCard2.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiThiPheDuyet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox groupBox3;
        private MonthCalendar monthCalendar1;
        private GroupBox groupBox4;
        private ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private ToolTip toolTip1;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private DataGridView dgvChiThiPheDuyet;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private DataGridView dgvChiThiPheDuyet_ChiTiet;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label4;
        private Label label3;
        private Label label2;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
    }
}
