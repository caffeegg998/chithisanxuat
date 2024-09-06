namespace ProductionDirectives.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tbLayOutQuanLyChiThi = new TableLayoutPanel();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialFloatingActionButton1 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            tabPage4 = new TabPage();
            imageList1 = new ImageList(components);
            materialTabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            tbLayOutQuanLyChiThi.SuspendLayout();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Controls.Add(tabPage4);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(0, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1356, 653);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.ImageKey = "dashboard.png";
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1348, 610);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dashboard";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.ImageKey = "approval.png";
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1269, 610);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Chỉ thị SMT";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tbLayOutQuanLyChiThi);
            tabPage3.ImageKey = "evaluation.png";
            tabPage3.Location = new Point(4, 39);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1348, 610);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Quản lý chỉ thị";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbLayOutQuanLyChiThi
            // 
            tbLayOutQuanLyChiThi.BackColor = Color.White;
            tbLayOutQuanLyChiThi.ColumnCount = 1;
            tbLayOutQuanLyChiThi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbLayOutQuanLyChiThi.Controls.Add(materialCard1, 0, 0);
            tbLayOutQuanLyChiThi.Dock = DockStyle.Fill;
            tbLayOutQuanLyChiThi.Location = new Point(3, 3);
            tbLayOutQuanLyChiThi.Margin = new Padding(0);
            tbLayOutQuanLyChiThi.Name = "tbLayOutQuanLyChiThi";
            tbLayOutQuanLyChiThi.RowCount = 2;
            tbLayOutQuanLyChiThi.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tbLayOutQuanLyChiThi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayOutQuanLyChiThi.Size = new Size(1342, 604);
            tbLayOutQuanLyChiThi.TabIndex = 1;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(materialLabel3);
            materialCard1.Controls.Add(materialLabel2);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Controls.Add(materialFloatingActionButton1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(2);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1338, 67);
            materialCard1.TabIndex = 0;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Cursor = Cursors.Hand;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel3.HighEmphasis = true;
            materialLabel3.Location = new Point(17, 20);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(158, 24);
            materialLabel3.TabIndex = 6;
            materialLabel3.Text = "QUẢN LÝ CHỈ THỊ";
            // 
            // materialLabel2
            // 
            materialLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            materialLabel2.AutoSize = true;
            materialLabel2.Cursor = Cursors.Hand;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            materialLabel2.HighEmphasis = true;
            materialLabel2.Location = new Point(1163, 36);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(138, 19);
            materialLabel2.TabIndex = 5;
            materialLabel2.Text = "Chưa có tài khoản?";
            materialLabel2.Click += materialLabel2_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            materialLabel1.AutoSize = true;
            materialLabel1.Cursor = Cursors.Hand;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel1.HighEmphasis = true;
            materialLabel1.Location = new Point(1163, 12);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(96, 24);
            materialLabel1.TabIndex = 4;
            materialLabel1.Text = "Đăng nhập";
            // 
            // materialFloatingActionButton1
            // 
            materialFloatingActionButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            materialFloatingActionButton1.BackgroundImageLayout = ImageLayout.Center;
            materialFloatingActionButton1.Cursor = Cursors.Hand;
            materialFloatingActionButton1.Depth = 0;
            materialFloatingActionButton1.ForeColor = Color.White;
            materialFloatingActionButton1.Icon = Properties.Resources.id_card;
            materialFloatingActionButton1.Location = new Point(1101, 5);
            materialFloatingActionButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton1.Name = "materialFloatingActionButton1";
            materialFloatingActionButton1.Size = new Size(56, 56);
            materialFloatingActionButton1.TabIndex = 3;
            materialFloatingActionButton1.Text = "dfs";
            materialFloatingActionButton1.TextImageRelation = TextImageRelation.TextAboveImage;
            materialFloatingActionButton1.UseMnemonic = false;
            materialFloatingActionButton1.UseVisualStyleBackColor = false;
            // 
            // tabPage4
            // 
            tabPage4.ImageKey = "user.png";
            tabPage4.Location = new Point(4, 39);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1269, 610);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Quản lý người dùng";
            tabPage4.UseVisualStyleBackColor = true;
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
            imageList1.Images.SetKeyName(4, "evaluation.png");
            imageList1.Images.SetKeyName(5, "approval.png");
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1359, 720);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Name = "MainForm";
            Padding = new Padding(0, 64, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            materialTabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tbLayOutQuanLyChiThi.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ImageList imageList1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TableLayoutPanel tbLayOutQuanLyChiThi;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
    }
}