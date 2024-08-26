using MaterialSkin.Controls;
using OfficeOpenXml;
using ProductionDirectives.Models;
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

namespace ProductionDirectives.Forms.User_Controls
{
    public partial class QuanLyChiThi : UserControl
    {

        private DataTable allLine_Temp;
        private List<ChiThiMau_ChiTiet> chiThiMau_ChiTiets;

        private readonly IChithisanxuatService _chithisanxuatService;
        public QuanLyChiThi( IChithisanxuatService chithisanxuatService)
        {
            InitializeComponent();
            chiThiMau_ChiTiets = new List<ChiThiMau_ChiTiet>();
            dgvChiThiMau_ChiTiet.CellEndEdit += DgvChiThiMau_ChiTiet_CellEndEdit;
            _chithisanxuatService = chithisanxuatService;

            _chithisanxuatService.ReloadDataGridView_ChiThiMau(dgvListChiThiMau);
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
            chiThiMau_ChiTiets.Clear();
            string lineName = materialComboBox1.Text;
            materialTextBox21.Text = lineName;
            materialButton3.Text = "Lưu chỉ thị";
            List<ChiThi_Template> chiThi_Templates = _chithisanxuatService.GetChiThi_TemplateByLine(lineName);


            dgvChiThiMau_ChiTiet.DataSource = chiThi_Templates;
            dgvChiThiMau_ChiTiet.Columns[0].Visible = false;
            dgvChiThiMau_ChiTiet.Columns[2].DefaultCellStyle.Format = "UpperCase";
            dgvChiThiMau_ChiTiet.Columns["RuleStandard"].DefaultCellStyle.Font = new Font(dgvChiThiMau_ChiTiet.Font, FontStyle.Bold);
            dgvChiThiMau_ChiTiet.Columns[2].DefaultCellStyle.Format = "UpperCase";
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
                materialButton3.Enabled = true;
            }
        }
        private void materialTextBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                materialButton3.Visible = true;
                foreach (DataGridViewRow row in dgvChiThiMau_ChiTiet.Rows)
                {
                    // Cập nhật giá trị của cell trong cột mong muốn
                    row.Cells["ModelName"].Value = materialTextBox22.Text;

                }
                foreach (DataGridViewRow row in dgvChiThiMau_ChiTiet.Rows)
                {
                    // Cập nhật giá trị của cell trong cột mong muốn
                    if (row.Cells["RuleStandard"].Value.ToString() != "")
                    {
                        string lineNamee = row.Cells["LineName"].Value.ToString();
                        string modelName = materialTextBox22.Text;
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

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            List<ChiThiMau_ChiTiet> soft = chiThiMau_ChiTiets.OrderBy(ct => ct.NumberOrder).ToList();

            string lineName = materialTextBox21.Text;
            string modelName = materialTextBox22.Text;
            int totalStage = soft.Count();
            int totalStep = soft.Count();

            ChiThiMau chiThiMau = new ChiThiMau{
                LineName = lineName,
                ModelName = modelName,
                TotalStage = totalStage,
                TotalStep = totalStep,
            };

            Guid chiThiMau_Guid = _chithisanxuatService.CreateChiThiMau(chiThiMau);

            foreach(ChiThiMau_ChiTiet chiThiMau_ChiTiet in soft)
            {
               chiThiMau_ChiTiet.Id_ChiThiMau = chiThiMau_Guid;
            }

            _chithisanxuatService.ImportChiThiMau_ChiTiet(soft);
        }
    }
}
