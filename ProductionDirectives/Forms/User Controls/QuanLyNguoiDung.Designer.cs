namespace ProductionDirectives.Forms.User_Controls
{
    partial class QuanLyNguoiDung
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tableLayoutPanel9 = new TableLayoutPanel();
            materialCard7 = new MaterialSkin.Controls.MaterialCard();
            groupBox13 = new GroupBox();
            dgvChiThi_Template = new DataGridView();
            materialCard8 = new MaterialSkin.Controls.MaterialCard();
            materialButton8 = new MaterialSkin.Controls.MaterialButton();
            materialButton7 = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel9.SuspendLayout();
            materialCard7.SuspendLayout();
            groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiThi_Template).BeginInit();
            materialCard8.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.BackColor = Color.White;
            tableLayoutPanel9.ColumnCount = 1;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Controls.Add(materialCard7, 0, 1);
            tableLayoutPanel9.Controls.Add(materialCard8, 0, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(0, 0);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Size = new Size(1058, 609);
            tableLayoutPanel9.TabIndex = 3;
            // 
            // materialCard7
            // 
            materialCard7.BackColor = Color.FromArgb(255, 255, 255);
            materialCard7.Controls.Add(groupBox13);
            materialCard7.Depth = 0;
            materialCard7.Dock = DockStyle.Fill;
            materialCard7.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard7.Location = new Point(2, 67);
            materialCard7.Margin = new Padding(2);
            materialCard7.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard7.Name = "materialCard7";
            materialCard7.Padding = new Padding(3);
            materialCard7.Size = new Size(1054, 540);
            materialCard7.TabIndex = 1;
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(dgvChiThi_Template);
            groupBox13.Dock = DockStyle.Fill;
            groupBox13.Location = new Point(3, 3);
            groupBox13.Name = "groupBox13";
            groupBox13.Size = new Size(1048, 534);
            groupBox13.TabIndex = 0;
            groupBox13.TabStop = false;
            groupBox13.Text = "Chi tiết mẫu";
            // 
            // dgvChiThi_Template
            // 
            dgvChiThi_Template.AllowUserToAddRows = false;
            dgvChiThi_Template.AllowUserToDeleteRows = false;
            dgvChiThi_Template.BackgroundColor = Color.White;
            dgvChiThi_Template.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvChiThi_Template.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvChiThi_Template.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvChiThi_Template.DefaultCellStyle = dataGridViewCellStyle2;
            dgvChiThi_Template.Dock = DockStyle.Fill;
            dgvChiThi_Template.Location = new Point(3, 19);
            dgvChiThi_Template.Name = "dgvChiThi_Template";
            dgvChiThi_Template.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvChiThi_Template.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvChiThi_Template.RowHeadersVisible = false;
            dgvChiThi_Template.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiThi_Template.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvChiThi_Template.RowTemplate.Height = 50;
            dgvChiThi_Template.Size = new Size(1042, 512);
            dgvChiThi_Template.TabIndex = 0;
            // 
            // materialCard8
            // 
            materialCard8.BackColor = Color.FromArgb(255, 255, 255);
            materialCard8.Controls.Add(materialButton8);
            materialCard8.Controls.Add(materialButton7);
            materialCard8.Depth = 0;
            materialCard8.Dock = DockStyle.Fill;
            materialCard8.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard8.Location = new Point(2, 2);
            materialCard8.Margin = new Padding(2);
            materialCard8.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard8.Name = "materialCard8";
            materialCard8.Padding = new Padding(3);
            materialCard8.Size = new Size(1054, 61);
            materialCard8.TabIndex = 2;
            // 
            // materialButton8
            // 
            materialButton8.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton8.CharacterCasing = MaterialSkin.Controls.MaterialButton.CharacterCasingEnum.Normal;
            materialButton8.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton8.Depth = 0;
            materialButton8.HighEmphasis = true;
            materialButton8.Icon = null;
            materialButton8.Location = new Point(192, 15);
            materialButton8.Margin = new Padding(4, 6, 4, 6);
            materialButton8.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton8.Name = "materialButton8";
            materialButton8.NoAccentTextColor = Color.Empty;
            materialButton8.Size = new Size(172, 36);
            materialButton8.TabIndex = 2;
            materialButton8.Text = "Nhập vào Database";
            materialButton8.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton8.UseAccentColor = false;
            materialButton8.UseVisualStyleBackColor = true;
            materialButton8.Click += materialButton8_Click;
            // 
            // materialButton7
            // 
            materialButton7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton7.CharacterCasing = MaterialSkin.Controls.MaterialButton.CharacterCasingEnum.Normal;
            materialButton7.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton7.Depth = 0;
            materialButton7.HighEmphasis = true;
            materialButton7.Icon = null;
            materialButton7.Location = new Point(18, 15);
            materialButton7.Margin = new Padding(4, 6, 4, 6);
            materialButton7.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton7.Name = "materialButton7";
            materialButton7.NoAccentTextColor = Color.Empty;
            materialButton7.Size = new Size(150, 36);
            materialButton7.TabIndex = 0;
            materialButton7.Text = "Nhập file Excels";
            materialButton7.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton7.UseAccentColor = false;
            materialButton7.UseVisualStyleBackColor = true;
            materialButton7.Click += materialButton7_Click;
            // 
            // QuanLyNguoiDung
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel9);
            Name = "QuanLyNguoiDung";
            Size = new Size(1058, 609);
            tableLayoutPanel9.ResumeLayout(false);
            materialCard7.ResumeLayout(false);
            groupBox13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiThi_Template).EndInit();
            materialCard8.ResumeLayout(false);
            materialCard8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel9;
        private MaterialSkin.Controls.MaterialCard materialCard7;
        private GroupBox groupBox13;
        private DataGridView dgvChiThi_Template;
        private MaterialSkin.Controls.MaterialCard materialCard8;
        private MaterialSkin.Controls.MaterialButton materialButton8;
        private MaterialSkin.Controls.MaterialButton materialButton7;
    }
}
