using MaterialSkin.Controls;
using OfficeOpenXml;
using ProductionDirectives.Models;
using ProductionDirectives.Models.Interfaces;
using ProductionDirectives.Repository.Interfaces;
using ProductionDirectives.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ProductionDirectives.Forms.User_Controls
{
    public partial class QuanLyChiThi : UserControl
    {

        private DataTable allLine_Temp;
        private List<ChiThiMau_ChiTiet> chiThiMau_ChiTiets;

     

        private readonly IChithisanxuatService _chithisanxuatService;
        private readonly TaoChiThiSanXuat _taoChiThiSanXuat;

                private bool initColumne_Once = false;
        public QuanLyChiThi(IChithisanxuatService chithisanxuatService)
        {
            InitializeComponent();
            chiThiMau_ChiTiets = new List<ChiThiMau_ChiTiet>();
            dgvChiThiMau_ChiTiet.CellEndEdit += DgvChiThiMau_ChiTiet_CellEndEdit;
            _chithisanxuatService = chithisanxuatService;

            _chithisanxuatService.ReloadDataGridView_ChiThiMau(dgvListChiThiMau);

            dgvListChiThiMau.CellClick += DgvListChiThiMau_CellClick;
            btnXacNhan.Click += BtnXacNhan_Click;




            _taoChiThiSanXuat = new TaoChiThiSanXuat(_chithisanxuatService);
            _taoChiThiSanXuat.Dock = DockStyle.Fill;

            tabPage1.Controls.Add(_taoChiThiSanXuat);
            
        }

        

        private void BtnXacNhan_Click(object? sender, EventArgs e)
        {
            btnSave_Update.Enabled = true;
            btnXacNhan.Enabled = false;

        }

        private Guid Id_Chithichitiet;

        private void DgvListChiThiMau_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (editMode == false)
            {
                editMode = !editMode;
            }

            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow row = dgvListChiThiMau.Rows[e.RowIndex];

                // Xử lý dữ liệu từ hàng được chọn
                // Ví dụ: hiển thị dữ liệu lên các TextBox
                string Id = row.Cells["Id"].Value.ToString();
                string lineName = row.Cells["LineName"].Value.ToString();
                string modelName = row.Cells["ModelName"].Value.ToString();
                Id_Chithichitiet = Guid.Parse(Id);

                txtLineName.Text = lineName;
                txtModelName.Text = modelName;

                btnSave_Update.Text = "Cập nhật";
                btnSave_Update.Visible = true;
                btnSave_Update.Enabled = false;
                btnXacNhan.Enabled = true;
                btnDeleteChiThiMau.Enabled = true;


                List<ChiThiMau_ChiTiet> chiThiMau_ChiTiets = _chithisanxuatService.GetChiThiMau_ChiTietsBy_IdChiThiMau(Id_Chithichitiet);
                dgvChiThiMau_ChiTiet.DataSource = chiThiMau_ChiTiets;
                dgvChiThiMau_ChiTiet.Columns["Id"].Visible = false;
                dgvChiThiMau_ChiTiet.Columns["Id_ChiThiMau"].Visible = false;
                dgvChiThiMau_ChiTiet.Columns["ChiThiMau"].Visible = false;



                //Font size
                Font boldFont = new Font(dgvChiThiMau_ChiTiet.Font, FontStyle.Bold);

                //Set ReadOnly
                dgvChiThiMau_ChiTiet.Columns["ModelName"].ReadOnly = true;
                
                dgvChiThiMau_ChiTiet.Columns["Stage"].ReadOnly = true;
                dgvChiThiMau_ChiTiet.Columns["NumberOrder"].ReadOnly = true;
                dgvChiThiMau_ChiTiet.Columns["Step"].ReadOnly = true;

                //Set Font
                dgvChiThiMau_ChiTiet.Columns["ModelName"].DefaultCellStyle.Font = boldFont;
                dgvChiThiMau_ChiTiet.Columns["RuleStandard"].DefaultCellStyle.Font = boldFont;
                //Set AutoSizeComlumn
                dgvChiThiMau_ChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void QuanLyChiThi_Load(object sender, EventArgs e)
        {

        }

        private void materialButton7_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();

            dialog.ShowDialog();

            string filePath = dialog.FileName;
            DataTable dt = docFileChiThi_Template(filePath);

            var uniqueLineNames = dt.AsEnumerable()
                    .Select(row => row.Field<string>(1))
                    .Distinct()
                    .Where(lineName => !string.IsNullOrEmpty(lineName))
                    .OrderBy(lineName => lineName)
            .ToList();

            materialComboBox2.DataSource = uniqueLineNames;

            DataTable result = dt.AsEnumerable()
                .Where(row => row.Field<string>("LineName") == "S9").CopyToDataTable();
            allLine_Temp = dt.Clone();

            allLine_Temp = dt;
            dgvChiThi_Template.DataSource = dt;
            dgvChiThi_Template.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }
        public DataTable docFileChiThi_Template(string filePath)
        {
            DataTable dt = new DataTable();
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    // Đọc header từ dòng thứ 3
                    int columnLimit = worksheet.Dimension.End.Column;
                    int headerRow = 1;
                    int columnCount = 0;
                    foreach (var headerCell in worksheet.Cells[headerRow, 1, headerRow, columnLimit])
                    {
                        columnCount++;
                        if (dt.Columns.Contains(headerCell.Text))
                        {
                            dt.Columns.Add($"{headerCell.Text}{columnCount}", typeof(string));
                        }
                        else
                        {
                            dt.Columns.Add(headerCell.Text);
                        }
                    }

                    // Đọc data từ dòng thứ 4
                    for (int rowNum = headerRow + 1; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = worksheet.Cells[rowNum, 1, rowNum, columnLimit];
                        DataRow row = dt.Rows.Add();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        private void materialComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allLine_Temp != null)
            {
                dgvChiThi_Template.DataSource = null;

                DataTable result = allLine_Temp.AsEnumerable()
                .Where(row => row.Field<string>("LineName") == materialComboBox2.Text).CopyToDataTable();
                dgvChiThi_Template.DataSource = result;
            }

        }

        private async void materialButton8_Click(object sender, EventArgs e)
        {
            //await _chiThiSanXuat.DeleteChiThiTemplate();
            List<ChiThi_Template> chiThi_Templates = new List<ChiThi_Template>();

            foreach (DataRow row in allLine_Temp.Rows)
            {
                string lineName = row["LineName"].ToString();
                string modelName = row["ModelName"].ToString();
                string stage = row["Stage"].ToString();
                string step = row["Step"].ToString();
                int numberOrder = Int32.Parse(row["NumberOrder"].ToString());
                string ruleStandard = row["RuleStandard"].ToString();

                ChiThi_Template chiThi_Template = new ChiThi_Template
                {
                    LineName = lineName,
                    ModelName = modelName,
                    Stage = stage,
                    NumberOrder = numberOrder,
                    Step = step,
                    RuleStandard = ruleStandard
                };
                chiThi_Templates.Add(chiThi_Template);


            }

            _chithisanxuatService.ImportChiThiTemplate(chiThi_Templates);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (editMode == true)
            {
                editMode = !editMode;
            }
            chiThiMau_ChiTiets.Clear();
            txtModelName.Text = "";
            btnXacNhan.Enabled = false;
            string lineName = materialComboBox1.Text;
            txtLineName.Text = lineName;
            btnSave_Update.Text = "Lưu";
            panel2.BackColor = Color.FromArgb(255, 128, 128);
            btnSave_Update.Enabled = false;
            btnDeleteChiThiMau.Enabled = false;
            btnDeleteChiThiMau.ForeColor = Color.White;
            List<ChiThi_Template> chiThi_Templates = _chithisanxuatService.GetChiThi_TemplateByLine(lineName);


            dgvChiThiMau_ChiTiet.DataSource = chiThi_Templates;
            dgvChiThiMau_ChiTiet.Columns[0].Visible = false;
            dgvChiThiMau_ChiTiet.Columns[2].DefaultCellStyle.Format = "UpperCase";
            dgvChiThiMau_ChiTiet.Columns["RuleStandard"].DefaultCellStyle.Font = new Font(dgvChiThiMau_ChiTiet.Font, FontStyle.Bold);
            dgvChiThiMau_ChiTiet.Columns["ModelName"].DefaultCellStyle.Font = new Font(dgvChiThiMau_ChiTiet.Font, FontStyle.Bold);
            dgvChiThiMau_ChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        public void checkDone()
        {
            int total = dgvChiThiMau_ChiTiet.RowCount;
            labelTotal.Text = total.ToString();
            int step = chiThiMau_ChiTiets.Count();
            lbStep.Text = step.ToString();
            if (total == step)
            {
                panel2.BackColor = Color.FromArgb(128, 255, 128);
                //btnSave_Update.Enabled = true;
                btnXacNhan.Enabled = true;
            }
        }
        private void materialTextBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave_Update.Visible = true;
                chiThiMau_ChiTiets.Clear();
                foreach (DataGridViewRow row in dgvChiThiMau_ChiTiet.Rows)
                {
                    // Cập nhật giá trị của cell trong cột mong muốn
                    row.Cells["ModelName"].Value = txtModelName.Text;

                }
                foreach (DataGridViewRow row in dgvChiThiMau_ChiTiet.Rows)
                {
                    // Cập nhật giá trị của cell trong cột mong muốn
                    if (row.Cells["RuleStandard"].Value.ToString() != "")
                    {
                        string lineNamee = row.Cells["LineName"].Value.ToString();
                        string modelName = txtModelName.Text;
                        string stage = row.Cells["Stage"].Value.ToString();
                        string numberOrder = row.Cells["NumberOrder"].Value.ToString();
                        string step = row.Cells["Step"].Value.ToString();
                        string ruleStandard = row.Cells["RuleStandard"].Value.ToString();

                        ChiThiMau_ChiTiet chiThiMau_ChiTiet = new ChiThiMau_ChiTiet
                        {
                            LineName = lineNamee,
                            ModelName = modelName,
                            Stage = stage,
                            NumberOrder = Int32.Parse(numberOrder),
                            Step = step,
                            RuleStandard = ruleStandard
                        };
                        chiThiMau_ChiTiets.Add(chiThiMau_ChiTiet);

                        DataGridViewCell cell = row.Cells["RuleStandard"];

                        // Kiểm tra nếu ô đã có giá trị
                        if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                        {
                            // Đặt ô thành ReadOnly để ngăn chỉnh sửa
                            cell.ReadOnly = true;

                            // Thay đổi màu nền để người dùng biết rằng ô này bị vô hiệu hóa (tùy chọn)
                            cell.Style.BackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.DarkGray;
                        }
                    }
                }
                checkDone();
            }

        }



        private bool isEnterPressed = false;

        private void DgvChiThiMau_ChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChiThiMau_ChiTiet.Columns[e.ColumnIndex].Name == "RuleStandard")
            {
                // Lấy giá trị từ ô vừa được chỉnh sửa
                DataGridViewCell cell = dgvChiThiMau_ChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string inputValue = cell.Value?.ToString(); // Giá trị vừa nhập vào

                // Kiểm tra nếu giá trị là null hoặc rỗng
                if (string.IsNullOrEmpty(inputValue))
                {
                    // Thực hiện hành động mong muốn nếu giá trị rỗng
                    MessageBox.Show("Giá trị không được để trống!");
                }
                else
                {
                    string lineName = dgvChiThiMau_ChiTiet.Rows[e.RowIndex].Cells["LineName"].Value.ToString();
                    string modelName = dgvChiThiMau_ChiTiet.Rows[e.RowIndex].Cells["ModelName"].Value.ToString();
                    string stage = dgvChiThiMau_ChiTiet.Rows[e.RowIndex].Cells["Stage"].Value.ToString();
                    string numberOrder = dgvChiThiMau_ChiTiet.Rows[e.RowIndex].Cells["NumberOrder"].Value.ToString();
                    string step = dgvChiThiMau_ChiTiet.Rows[e.RowIndex].Cells["Step"].Value.ToString();
                    string ruleStandard = dgvChiThiMau_ChiTiet.Rows[e.RowIndex].Cells["RuleStandard"].Value.ToString();

                    ChiThiMau_ChiTiet chiThiMau_ChiTiet = new ChiThiMau_ChiTiet
                    {
                        LineName = lineName,
                        ModelName = modelName,
                        Stage = stage,
                        NumberOrder = Int32.Parse(numberOrder),
                        Step = step,
                        RuleStandard = ruleStandard
                    };

                    ChiThiMau_ChiTiet result = chiThiMau_ChiTiets
                            .FirstOrDefault(ct => ct.NumberOrder == Int32.Parse(numberOrder));
                    if (result != null)
                    {
                        // Đối tượng được tìm thấy
                        chiThiMau_ChiTiets.Remove(result);
                        chiThiMau_ChiTiets.Add(chiThiMau_ChiTiet);
                    }
                    else
                    {
                        // Không tìm thấy đối tượng
                        chiThiMau_ChiTiets.Add(chiThiMau_ChiTiet);
                    }


                    // Thực hiện hành động với giá trị vừa nhập vào
                    checkDone();
                }
            }
        }
        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool editMode = false;

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            if (editMode == false)
            {
                List<ChiThiMau_ChiTiet> soft = chiThiMau_ChiTiets.OrderBy(ct => ct.NumberOrder).ToList();

                string lineName = txtLineName.Text;
                string modelName = txtModelName.Text;
                int totalStage = soft.Count();
                int totalStep = soft.Count();

                ChiThiMau chiThiMau = new ChiThiMau
                {
                    LineName = lineName,
                    ModelName = modelName,
                    TotalStage = totalStage,
                    TotalStep = totalStep,
                };

                Guid chiThiMau_Guid = _chithisanxuatService.CreateChiThiMau(chiThiMau);

                foreach (ChiThiMau_ChiTiet chiThiMau_ChiTiet in soft)
                {
                    chiThiMau_ChiTiet.Id_ChiThiMau = chiThiMau_Guid;
                }

                _chithisanxuatService.ImportChiThiMau_ChiTiet(soft);
                _chithisanxuatService.ReloadDataGridView_ChiThiMau(dgvListChiThiMau);

                dgvChiThiMau_ChiTiet.DataSource = null;
                txtLineName.Text = "";
                txtModelName.Text = "";
                btnSave_Update.Visible = false;

                _taoChiThiSanXuat.InitLine();
            }
            else if (editMode == true)
            {
                List<ChiThiMau_ChiTiet> chiThiMau_ChiTiets_Update = new List<ChiThiMau_ChiTiet>();

                foreach(DataGridViewRow row in dgvChiThiMau_ChiTiet.Rows)
                {
                    string id = row.Cells["Id"].Value.ToString();
                    string lineName = row.Cells["LineName"].Value.ToString();
                    string modelName = row.Cells["ModelName"].Value.ToString();
                    string stage = row.Cells["Stage"].Value.ToString();
                    string numberOrder = row.Cells["NumberOrder"].Value.ToString();
                    string step = row.Cells["Step"].Value.ToString();
                    string ruleStandard = row.Cells["RuleStandard"].Value.ToString();
                    string idChiThiMau = row.Cells["Id_ChiThiMau"].Value.ToString();

                    ChiThiMau_ChiTiet chiThiMau_ChiTiet = new ChiThiMau_ChiTiet
                    {
                        Id = Guid.Parse(id),
                        LineName = lineName,
                        ModelName = modelName,
                        Stage = stage,
                        NumberOrder = Int32.Parse(numberOrder),
                        Step = step,
                        RuleStandard = ruleStandard,
                        Id_ChiThiMau = Guid.Parse(idChiThiMau)
                    };
                    chiThiMau_ChiTiets_Update.Add(chiThiMau_ChiTiet);


                }
                bool result = await _chithisanxuatService.UpdateChiThiMauChiTiet(chiThiMau_ChiTiets_Update);

                if (result)
                {
                    MessageBox.Show("Update thành công");
                }

                MessageBox.Show("Test Cập nhật");
            }
        }

        private async void btnDeleteChiThiMau_Click(object sender, EventArgs e)
        {
            bool result = await _chithisanxuatService.DeleteChiThiMauById(Id_Chithichitiet);
            if (result)
            {

                MaterialMessageBox.Show("Xóa chỉ thị thành công!");

                _chithisanxuatService.ReloadDataGridView_ChiThiMau(dgvListChiThiMau);

                dgvChiThiMau_ChiTiet.DataSource = null;
                txtLineName.Text = "";
                txtModelName.Text = "";

                btnSave_Update.Visible = false;
                btnXacNhan.Enabled = false;
                btnDeleteChiThiMau.Enabled = false;
            }
            
        }
    }
}
