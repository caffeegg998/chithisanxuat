using MaterialSkin.Controls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ProductionDirectives.Models;
using ProductionDirectives.Models.Interfaces;
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
    public partial class TaoChiThiSanXuat : UserControl
    {
        private Timer timer;
        private readonly IChithisanxuatService _chithisanxuatService;
        private List<ChiThiMau> _listChiThiMau;
        private List<ChiThiPheDuyet_ChiTiet> _chiThiPheDuyet_ChiTiets;

        public TaoChiThiSanXuat(IChithisanxuatService chithisanxuatService)
        {
            _chithisanxuatService = chithisanxuatService;
            InitializeComponent();
            InitDayTime();
            InitLine();
            _chithisanxuatService.ReloadDataGridView_ChiThiPheDuyet(dataGridView5);
            dataGridView5.MouseWheel += DgvChiThiPheDuyet_MouseWheel;
        }

        private void DgvChiThiPheDuyet_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && dataGridView5.FirstDisplayedScrollingRowIndex > 0)
            {
                dataGridView5.FirstDisplayedScrollingRowIndex--;
            }
            else if (e.Delta < 0)
            {
                dataGridView5.FirstDisplayedScrollingRowIndex++;
            }
        }

        private async void InitDayTime()
        {
            DateTime currentDate = DateTime.Now; // Lấy DateTime hiện tại
            string formattedDate = currentDate.ToString("dd-MM-yyyy"); // Định dạng 
            txtDay.Text = formattedDate;
            txtCurrentTime.Enabled = false;
            txtDay.Enabled = false;

            timer = new Timer();
            timer.Interval = 1000; // 1 giây
            timer.Tick += Timer_Tick;
            timer.Start();


        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            txtCurrentTime.Text = now.ToString("HH:mm:ss");
        }

        public void InitLine()
        {
            List<ChiThiMau> listChiThiMau = _chithisanxuatService.GetListChiThiMau();
            _listChiThiMau = listChiThiMau;

            List<string> uniqueLineNames = _listChiThiMau
                .Select(c => c.LineName)
                .Distinct()
                .ToList();

            cbLineName.DataSource = uniqueLineNames;
            cbLineName.SelectedIndexChanged += CbLineName_SelectedIndexChanged;
        }

        private void CbLineName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            List<ChiThiMau> getModelName_By_LineName = _listChiThiMau.Where(c => c.LineName == cbLineName.Text).ToList();
            cbModelName.DataSource = getModelName_By_LineName;
            cbModelName.DisplayMember = "ModelName";
            cbModelName.ValueMember = "ModelName";
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            if (cbCaKip.Text == "")
            {
                MaterialMessageBox.Show("Bạn cần chọn Ca/ Kíp làm việc trước!");
                return;
            }
            if (_chiThiPheDuyet_ChiTiets != null)
            {
                _chiThiPheDuyet_ChiTiets.Clear();
            }
            List<ChiThiMau_ChiTiet> chiThiMau_ChiTiets = _chithisanxuatService.GetChiThiMau_ChiTiets_By_Line_And_Model_Name(cbLineName.Text, cbModelName.Text);
            List<ChiThiPheDuyet_ChiTiet> chiThiPheDuyet_ChiTiets = new List<ChiThiPheDuyet_ChiTiet>();

            foreach (ChiThiMau_ChiTiet chiThiMau_ChiTiet in chiThiMau_ChiTiets)
            {
                string lineName = chiThiMau_ChiTiet.LineName;
                string modelName = chiThiMau_ChiTiet.ModelName;
                string stage = chiThiMau_ChiTiet.Stage;
                int numberOrder = chiThiMau_ChiTiet.NumberOrder;
                string step = chiThiMau_ChiTiet.Step;
                string ruleStandard = chiThiMau_ChiTiet.RuleStandard;


                ChiThiPheDuyet_ChiTiet chiThiPheDuyet_chiTiet = new ChiThiPheDuyet_ChiTiet
                {
                    LineName = lineName,
                    ModelName = modelName,
                    Stage = stage,
                    NumberOrder = numberOrder,
                    Step = step,
                    RuleStandard = ruleStandard,
                    Actual = ""
                };
                chiThiPheDuyet_ChiTiets.Add(chiThiPheDuyet_chiTiet);

            }


            _chiThiPheDuyet_ChiTiets = chiThiPheDuyet_ChiTiets;
            dgvChiThiPheDuyet_Pending.DataSource = chiThiPheDuyet_ChiTiets;
            dgvChiThiPheDuyet_Pending.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //header style
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();

            // Thiết lập màu nền
            headerStyle.BackColor = Color.DodgerBlue;

            // Thiết lập màu chữ
            headerStyle.ForeColor = Color.White;

            // Thiết lập font chữ
            headerStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Căn giữa nội dung
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Thêm đường viền

            // Thiết lập padding

            // Áp dụng style cho tiêu đề cột
            dgvChiThiPheDuyet_Pending.ColumnHeadersDefaultCellStyle = headerStyle;

            // Tùy chọn: Điều chỉnh chiều cao của tiêu đề cột
            dgvChiThiPheDuyet_Pending.ColumnHeadersHeight = 50;

            // Tùy chọn: Ngăn người dùng thay đổi kích thước tiêu đề cột
            dgvChiThiPheDuyet_Pending.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Tùy chọn: Cho phép sắp xếp khi click vào tiêu đề cột
            dgvChiThiPheDuyet_Pending.EnableHeadersVisualStyles = false;

            ///////
            ///
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.WrapMode = DataGridViewTriState.True; // Cho phép xuống dòng
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiThiPheDuyet_Pending.DefaultCellStyle = style;


            dgvChiThiPheDuyet_Pending.ReadOnly = true;

            dgvChiThiPheDuyet_Pending.RowHeadersVisible = false;
            dgvChiThiPheDuyet_Pending.BackgroundColor = Color.White;
            dgvChiThiPheDuyet_Pending.Columns["Id"].Visible = false;
            dgvChiThiPheDuyet_Pending.Columns["Actual"].Visible = false;
            dgvChiThiPheDuyet_Pending.Columns["Id_ChiThiPheDuyet"].Visible = false;
            dgvChiThiPheDuyet_Pending.Columns["Result"].Visible = false;
            dgvChiThiPheDuyet_Pending.Columns["LastChecked"].Visible = false;
            dgvChiThiPheDuyet_Pending.Columns["PICCheck"].Visible = false;
            dgvChiThiPheDuyet_Pending.Columns["ChiThiPheDuyet"].Visible = false;

            materialButton1.Enabled = true;
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            if (MainForm._nguoiDung == null)
            {
                MaterialMessageBox.Show("Cần phải đăng nhập để tạo chỉ thị sản xuất", "Thông báo");
                return;
            }
            ChiThiPheDuyet chiThiPheDuyet = new ChiThiPheDuyet
            {
                LineName = cbLineName.Text,
                ModelName = cbModelName.Text,
                TotalStage = _chiThiPheDuyet_ChiTiets.Count,
                TotalStep = _chiThiPheDuyet_ChiTiets.Count,
                isDandory_Done = false,
                CreateAt = DateTime.Now.ToUniversalTime(),
                Shift = cbCaKip.Text,
                PICCreate = MainForm._nguoiDung.Id

            };

            Guid Id_ChiThiPheDuyet = await _chithisanxuatService.CreataChiThiPheDuyet(chiThiPheDuyet);

            foreach (ChiThiPheDuyet_ChiTiet chiThiPheDuyet_ChiTiet in _chiThiPheDuyet_ChiTiets)
            {
                chiThiPheDuyet_ChiTiet.Id_ChiThiPheDuyet = Id_ChiThiPheDuyet;
            }

            bool result = await _chithisanxuatService.CreateChiThiPheDuyet_ChiTiet(_chiThiPheDuyet_ChiTiets);

            if (result)
            {
                MaterialMessageBox.Show("Tạo chỉ thị thành công!");
                dgvChiThiPheDuyet_Pending.DataSource = null;
                _chiThiPheDuyet_ChiTiets.Clear();
                materialButton1.Enabled = false;

                _chithisanxuatService.ReloadDataGridView_ChiThiPheDuyet(dataGridView5);

            }
            else
            {
                MaterialMessageBox.Show("Tạo chỉ thị thất bại!");
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Chỉ thị mẫu");

                // Tạo header
                worksheet.Cells["A1"].Value = "LineName";
                worksheet.Cells["B1"].Value = "ModelName";
                worksheet.Cells["C1"].Value = "TotalStage";
                worksheet.Cells["D1"].Value = "TotalStep";

                // Định dạng header
                using (var range = worksheet.Cells["A1:E1"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                // Điền dữ liệu
                int row = 2;
                foreach (var chiThiMau in _listChiThiMau)
                {

                    worksheet.Cells[row, 1].Value = chiThiMau.LineName;
                    worksheet.Cells[row, 2].Value = chiThiMau.ModelName;
                    worksheet.Cells[row, 3].Value = chiThiMau.TotalStage;
                    worksheet.Cells[row, 4].Value = chiThiMau.TotalStep;

                    row++;
                }

                // Định dạng toàn bộ vùng dữ liệu
                var dataRange = worksheet.Cells[1, 1, row - 1, 4];

                // Áp dụng viền cho tất cả các ô
                dataRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                dataRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                dataRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // Auto-fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var worksheet2 = package.Workbook.Worksheets.Add("Chỉ thị mẫu chi tiết");
                worksheet2.Cells["A1"].Value = "LineName";
                worksheet2.Cells["B1"].Value = "ModelName";
                worksheet2.Cells["C1"].Value = "Stage";
                worksheet2.Cells["D1"].Value = "NumberOrder";
                worksheet2.Cells["E1"].Value = "Step";
                worksheet2.Cells["F1"].Value = "RuleStandard";

                // Định dạng header
                using (var range = worksheet2.Cells["A1:H1"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                int row_chitiet = 2;
                foreach (var chiThiMau in _listChiThiMau)
                {
                    List<ChiThiMau_ChiTiet> chiThiMau_ChiTiets = _chithisanxuatService.GetChiThiMau_ChiTietsBy_IdChiThiMau(chiThiMau.Id);
                    foreach (ChiThiMau_ChiTiet chiThiMau_ChiTiet in chiThiMau_ChiTiets)
                    {

                        worksheet2.Cells[row_chitiet, 1].Value = chiThiMau_ChiTiet.LineName;
                        worksheet2.Cells[row_chitiet, 2].Value = chiThiMau_ChiTiet.ModelName;
                        worksheet2.Cells[row_chitiet, 3].Value = chiThiMau_ChiTiet.Stage;
                        worksheet2.Cells[row_chitiet, 4].Value = chiThiMau_ChiTiet.NumberOrder;
                        worksheet2.Cells[row_chitiet, 5].Value = chiThiMau_ChiTiet.Step;
                        worksheet2.Cells[row_chitiet, 6].Value = chiThiMau_ChiTiet.RuleStandard;
                        row_chitiet++;
                    }
                }

                var dataRange2 = worksheet2.Cells[1, 1, row_chitiet - 1, 6];

                // Áp dụng viền cho tất cả các ô
                dataRange2.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                dataRange2.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                dataRange2.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                dataRange2.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                dataRange2.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                dataRange2.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // Auto-fit columns
                worksheet2.Cells[worksheet2.Dimension.Address].AutoFitColumns();

                // Lưu file
                FileInfo excelFile = new FileInfo("D:/cc.xlsx");
                package.SaveAs(excelFile);
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            List<DataTable> dataTables = new List<DataTable>();

            OpenFileDialog dialog = new OpenFileDialog();

            dialog.ShowDialog();

            string filePath = dialog.FileName;
            List<DataTable> dts = docFileChiThiMau_Template(filePath);

            ImportChiThiMau(dts[0], dts[1]);
        }

        private void ImportChiThiMau(DataTable dt_chiThiMau,DataTable dt_chiThiMau_chiTiet)
        {
            
            foreach(DataRow row in dt_chiThiMau.Rows)
            {
                string lineName = row["LineName"].ToString();
                string modelName = row["ModelName"].ToString();
                string totalStage = row["TotalStage"].ToString();
                string totalStep = row["TotalStep"].ToString();

                DataTable filterBy_Model = dt_chiThiMau_chiTiet.AsEnumerable()
                                            .Where(row => row.Field<string>("ModelName") == modelName)
                                            .CopyToDataTable();

                ChiThiMau chiThiMau = new ChiThiMau
                {
                    LineName = lineName,
                    ModelName = modelName,
                    TotalStage = Int32.Parse(totalStage),
                    TotalStep = Int32.Parse(totalStep),
                };

                Guid chiThiMau_Guid = _chithisanxuatService.CreateChiThiMau(chiThiMau);

                List<ChiThiMau_ChiTiet> chiThiMau_ChiTiets = new List<ChiThiMau_ChiTiet>();

                foreach(DataRow row_ChiThiChiTiet in filterBy_Model.Rows)
                {
                    string lineName_chiTiet = row_ChiThiChiTiet["LineName"].ToString();
                    string modelName_chiTiet = row_ChiThiChiTiet["ModelName"].ToString();
                    string stage_chiTiet = row_ChiThiChiTiet["Stage"].ToString();
                    string numberOrder_chiTiet = row_ChiThiChiTiet["NumberOrder"].ToString();
                    string step_chiTiet = row_ChiThiChiTiet["Step"].ToString();
                    string ruleStandard_chiTiet = row_ChiThiChiTiet["RuleStandard"].ToString();


                    ChiThiMau_ChiTiet chiThiMau_ChiTiet = new ChiThiMau_ChiTiet
                    {
                        LineName = lineName,
                        ModelName = modelName,
                        Stage = stage_chiTiet,
                        NumberOrder = Int32.Parse(numberOrder_chiTiet),
                        Step = step_chiTiet,
                        RuleStandard = ruleStandard_chiTiet,
                        Id_ChiThiMau = chiThiMau_Guid 
                    };
                    chiThiMau_ChiTiets.Add(chiThiMau_ChiTiet);
                }
                _chithisanxuatService.ImportChiThiMau_ChiTiet(chiThiMau_ChiTiets);
            }
        }
      

        private List<DataTable> docFileChiThiMau_Template(string filePath)
        {
            List<DataTable> dts = new List<DataTable>();
            DataTable dt_chithimau = new DataTable();
            DataTable dt_chithimau_chitiet = new DataTable();
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Chỉ thị mẫu"];

                 
                    int columnLimit = worksheet.Dimension.End.Column;
                    int headerRow = 1;
                    int columnCount = 0;
                    foreach (var headerCell in worksheet.Cells[headerRow, 1, headerRow, columnLimit])
                    {
                        columnCount++;
                        if (dt_chithimau.Columns.Contains(headerCell.Text))
                        {
                            dt_chithimau.Columns.Add($"{headerCell.Text}{columnCount}", typeof(string));
                        }
                        else
                        {
                            dt_chithimau.Columns.Add(headerCell.Text);
                        }
                    }

                    // Đọc data từ dòng thứ 4
                    for (int rowNum = headerRow + 1; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = worksheet.Cells[rowNum, 1, rowNum, columnLimit];
                        DataRow row = dt_chithimau.Rows.Add();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }

                    ExcelWorksheet worksheet2 = package.Workbook.Worksheets["Chỉ thị mẫu chi tiết"];


                    int columnLimit2 = worksheet2.Dimension.End.Column;
                    int columnCount2 = 0;
                    foreach (var headerCell in worksheet2.Cells[headerRow, 1, headerRow, columnLimit2])
                    {
                        columnCount2++;
                        if (dt_chithimau_chitiet.Columns.Contains(headerCell.Text))
                        {
                            dt_chithimau_chitiet.Columns.Add($"{headerCell.Text}{columnCount2}", typeof(string));
                        }
                        else
                        {
                            dt_chithimau_chitiet.Columns.Add(headerCell.Text);
                        }
                    }

                    // Đọc data từ dòng thứ 4
                    for (int rowNum = headerRow + 1; rowNum <= worksheet2.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = worksheet2.Cells[rowNum, 1, rowNum, columnLimit2];
                        DataRow row = dt_chithimau_chitiet.Rows.Add();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }
                }
                dts.Add(dt_chithimau);
                dts.Add(dt_chithimau_chitiet);
                return dts;
            }
            catch
            {
                return null;
            }
        }
    }
}
