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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            tableLayoutPanel3 = new TableLayoutPanel();
            groupBox5 = new GroupBox();
            groupBox3 = new GroupBox();
            monthCalendar1 = new MonthCalendar();
            groupBox4 = new GroupBox();
            imageList1 = new ImageList(components);
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1024, 568);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel2.Controls.Add(groupBox2, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 48.9323845F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 51.0676155F));
            tableLayoutPanel2.Size = new Size(768, 562);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 278);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(20, 5, 15, 5);
            groupBox1.Size = new Size(762, 281);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(20, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(727, 255);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(formsPlot1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(762, 269);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // formsPlot1
            // 
            formsPlot1.BackColor = Color.White;
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(3, 19);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(756, 247);
            formsPlot1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.White;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(groupBox5, 0, 2);
            tableLayoutPanel3.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel3.Controls.Add(groupBox4, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(777, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 192F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(244, 562);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // groupBox5
            // 
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(3, 380);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(238, 179);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "groupBox5";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(monthCalendar1);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(238, 186);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // monthCalendar1
            // 
            monthCalendar1.Dock = DockStyle.Fill;
            monthCalendar1.Location = new Point(3, 19);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(3, 195);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(238, 179);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "groupBox4";
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
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Dashboard";
            Size = new Size(1024, 568);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox groupBox5;
        private GroupBox groupBox3;
        private MonthCalendar monthCalendar1;
        private GroupBox groupBox4;
        private ImageList imageList1;
    }
}
