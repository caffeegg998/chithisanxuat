using ProductionDirectives.Models.Interfaces;
using ProductionDirectives.Models;
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
using MaterialSkin.Controls;
using System.Diagnostics;
using ProductionDirectives.Utils;
using RestSharp;
using static ProductionDirectives.Models.ProgressProgram;
using System.Text.Json;

namespace ProductionDirectives.Forms.User_Controls
{
    public partial class ChiThiSanXuat : UserControl
    {
        private readonly IChithisanxuatService _chithisanxuatService;

        private string _Id_ChiThiPheDuyet;
        private string _messageDelete;
        private bool _isDandory_Done;

        private List<string> G2Ups;
        private List<string> QA;
        private List<string> G3Ups;
        private List<string> Admin;

        public ChiThiSanXuat(IChithisanxuatService chithisanxuatService)
        {
            InitializeComponent();
            _chithisanxuatService = chithisanxuatService;

            _chithisanxuatService.ReloadDataGridView_ChiThiPheDuyet(dgvChiThiPheDuyet);

            dgvChiThiPheDuyet.CellClick += DgvChiThiPheDuyet_CellClick; 
            dgvChiThiPheDuyet_ChiTiet.MouseWheel += DgvChiThiPheDuyet_ChiTiet_MouseWheel;
            dgvChiThiPheDuyet.MouseWheel += DgvChiThiPheDuyet_MouseWheel;

            dgvChiThiPheDuyet_ChiTiet.CellEndEdit += DgvChiThiPheDuyet_ChiTiet_CellEndEdit;

            G2Ups = new List<string> { "P2", "P3", "P4", "P5", "P6", "M1", "AGM" };
            QA = new List<string> { "QA", "QA-IFC", "QA-ISO" };
            G3Ups = G2Ups.Where(item => item != "P2").ToList();
            Admin = new List<string> { "P2(Admin)", "P3(Admin)", "M1", "P5", "P6", "P4(Admin)" };

        }



        private void checkDone()
        {
            int totalStep = dgvChiThiPheDuyet_ChiTiet.Rows.Count;
            int countTrue = dgvChiThiPheDuyet_ChiTiet.Rows
                .Cast<DataGridViewRow>()
                .Count(row => Convert.ToBoolean(row.Cells["Result"].Value));
            txtStep.Text = countTrue.ToString();
            txtTotalStep.Text = totalStep.ToString();

            if (totalStep == countTrue && _isDandory_Done == false)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }


        }



        private void DgvChiThiPheDuyet_ChiTiet_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {

            int columnIndex = e.ColumnIndex;
            if (dgvChiThiPheDuyet_ChiTiet.Columns[columnIndex].Name == "Actual")
            {
                // Lấy giá trị từ ô vừa được chỉnh sửa
                DataGridViewRow row = dgvChiThiPheDuyet_ChiTiet.Rows[e.RowIndex];
                DataGridViewCell cell = dgvChiThiPheDuyet_ChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string inputValue = cell.Value?.ToString(); // Giá trị vừa nhập vào

                // Kiểm tra nếu giá trị là null hoặc rỗng
                if (string.IsNullOrEmpty(inputValue))
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.Cells["Result"].Value = false;
                }
                else
                {
                    if (_nguoiDung == null)
                    {
                        MaterialMessageBox.Show("Chưa xác nhận người thực hiện Dandory, vui lòng xác nhận!", "Thông báo!");
                        dgvChiThiPheDuyet_ChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        materialTextBox21.Focus();
                    }
                    else
                    {
                        if (row.Cells["Stage"].Value.ToString().Contains("Shift Leader") || Admin.Contains(_nguoiDung.Grade))
                        {
                            if (G3Ups.Contains(_nguoiDung.Grade) || Admin.Contains(_nguoiDung.Grade))
                            {
                                InputActual(inputValue, row, columnIndex);
                            }
                            else
                            {
                                MaterialMessageBox.Show("Hạng mục này cần phải Shift Leader G3 Up trở lên xác nhận!");
                                return;
                            }

                        }
                        else if (row.Cells["Stage"].Value.ToString().Contains("Leader") || Admin.Contains(_nguoiDung.Grade))
                        {
                            if (G2Ups.Contains(_nguoiDung.Grade))
                            {
                                InputActual(inputValue, row, columnIndex);
                            }
                            else
                            {
                                MaterialMessageBox.Show("Hạng mục này cần phải Leader G2 Up trở lên xác nhận!");
                                return;
                            }
                        }
                        else if (row.Cells["Stage"].Value.ToString().Contains("QA"))
                        {
                            if (QA.Contains(_nguoiDung.Section) && G2Ups.Contains(_nguoiDung.Grade) || Admin.Contains(_nguoiDung.Grade))
                            {
                                InputActual(inputValue, row, columnIndex);
                            }
                            else
                            {
                                MaterialMessageBox.Show("Hạng mục này cần phải QA G2 Up xác nhận!");
                                return;
                            }

                        }

                        else if (row.Cells["Stage"].Value.ToString().Contains("Super Visor"))
                        {
                            if (Admin.Contains(_nguoiDung.Grade))
                            {
                                InputActual(inputValue, row, columnIndex);
                            }
                            else
                            {
                                MaterialMessageBox.Show("Hạng mục này cần phải Super Visor G4 Up trở lên xác nhận!");
                                return;
                            }

                        }
                        else
                        {
                            InputActual(inputValue, row, columnIndex);
                        }

                    }
                }
            }
            else if (dgvChiThiPheDuyet_ChiTiet.Columns[columnIndex].Name == "RuleStandard")
            {
                DataGridViewRow row = dgvChiThiPheDuyet_ChiTiet.Rows[e.RowIndex];
                UpdateStandard(row);
            }
        }

        private async void UpdateStandard(DataGridViewRow row)
        {
            row.Cells["PICCheckId"].Value = null;
            await _chithisanxuatService.UpdateSigleChiThiPheDuyet_ChiTiet(row);
        }

        private async void InputActual(string inputValue, DataGridViewRow row, int columnIndex)
        {
            if (inputValue == row.Cells["RuleStandard"].Value.ToString())
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);
                row.Cells[columnIndex].Value = inputValue + "(OK)";
                row.Cells["PICCheckId"].Value = _nguoiDung.Id;
                row.Cells["Result"].Value = true;

            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                row.Cells[columnIndex].Value = inputValue + "(NG)";
                row.Cells["PICCheckId"].Value = _nguoiDung.Id;
                row.Cells["Result"].Value = false;


            }


            row.Cells["LastChecked"].Value = DateTime.Now;
          
            await _chithisanxuatService.UpdateSigleChiThiPheDuyet_ChiTiet(row);
            row.Cells["PICCheckName"].Value = _chithisanxuatService.GetFullNameUser_By_Id(_nguoiDung.Id);
            checkDone();
        }

        private void DgvChiThiPheDuyet_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && dgvChiThiPheDuyet.FirstDisplayedScrollingRowIndex > 0)
            {
                dgvChiThiPheDuyet.FirstDisplayedScrollingRowIndex--;
            }
            else if (e.Delta < 0)
            {
                dgvChiThiPheDuyet.FirstDisplayedScrollingRowIndex++;
            }
        }

        private void DgvChiThiPheDuyet_ChiTiet_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && dgvChiThiPheDuyet_ChiTiet.FirstDisplayedScrollingRowIndex > 0)
            {
                dgvChiThiPheDuyet_ChiTiet.FirstDisplayedScrollingRowIndex--;
            }
            else if (e.Delta < 0)
            {
                dgvChiThiPheDuyet_ChiTiet.FirstDisplayedScrollingRowIndex++;
            }
        }

        private void DgvChiThiPheDuyet_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow row = dgvChiThiPheDuyet.Rows[e.RowIndex];

                // Xử lý dữ liệu từ hàng được chọn
                // Ví dụ: hiển thị dữ liệu lên các TextBox
                string Id = row.Cells["Id"].Value.ToString(); _Id_ChiThiPheDuyet = Id;
                string lineName = row.Cells["LineName"].Value.ToString();
                string modelName = row.Cells["ModelName"].Value.ToString();
                DateTime createAt = DateTime.Parse(row.Cells["CreateAt"].Value.ToString());
                string caKip = row.Cells["Shift"].Value.ToString();
                bool isDandory_Done = Boolean.Parse(row.Cells["isDandory_Done"].Value.ToString());
                _isDandory_Done = isDandory_Done;
                //Id_Chithichitiet = Guid.Parse(Id);

                _messageDelete = $"Bạn có muốn xóa chỉ thị? \nLine: {lineName} \nModel: {modelName} \nTạo lúc: {createAt} \nCa: {caKip}";

                if (isDandory_Done)
                {
                    lbIsDandory_done.Text = "Đã Duyệt";
                    lbIsDandory_done.BackColor = Color.FromArgb(128, 255, 128);
                }
                else
                {
                    lbIsDandory_done.Text = "Chưa Duyệt";
                    lbIsDandory_done.BackColor = Color.FromArgb(255, 128, 128);

                }

                txtLine.Text = lineName;
                txtModelName.Text = modelName;
                txtCaKip.Text = caKip;
                btnSubmit.Enabled = false;

                txtDay.Text = createAt.ToString("dd-MM-yyyy");

                // Gán giá trị thời gian vào txtTime với định dạng HH:mm tt (tt cho AM/PM)
                txtTime.Text = createAt.ToString("hh:mm tt");
                //checkDone();


            }
        }

        private bool initColumne_Once = false;
        private async void materialButton1_Click(object sender, EventArgs e)
        {
            if (_Id_ChiThiPheDuyet == null)
            {
                MaterialMessageBox.Show("Hãy chọn chỉ thị trước khi tìm kiếm!", "Thông báo");
                return;
            }

            materialSwitch1.Text = "hiện cột Standard(Admin)";
            materialSwitch1.Checked = false;


            List<ChiThiPheDuyet_ChiTiet> listChiThiPheDuyet_ChiTiet = _chithisanxuatService.GetChiThiPheDuyet_ChiTiets_By_IdChiThiChiTiet(Guid.Parse(_Id_ChiThiPheDuyet));



            dgvChiThiPheDuyet_ChiTiet.DataSource = listChiThiPheDuyet_ChiTiet;

            if (!initColumne_Once)
            {
                DataGridViewTextBoxColumn picNameColumn = new DataGridViewTextBoxColumn();
                picNameColumn.HeaderText = "Người thực hiện";
                picNameColumn.Name = "PICCheckName";
                dgvChiThiPheDuyet_ChiTiet.Columns.Add(picNameColumn);
                initColumne_Once = !initColumne_Once;
            }


            // Cập nhật giá trị cho cột mới
            //Setting column
            dgvChiThiPheDuyet_ChiTiet.Columns["Id"].Visible = false;
            dgvChiThiPheDuyet_ChiTiet.Columns["Result"].Visible = false;
            dgvChiThiPheDuyet_ChiTiet.Columns["ChiThiPheDuyet"].Visible = false;
            dgvChiThiPheDuyet_ChiTiet.Columns["Id_ChiThiPheDuyet"].Visible = false;
            dgvChiThiPheDuyet_ChiTiet.Columns["PICCheckId"].Visible = false;
            dgvChiThiPheDuyet_ChiTiet.Columns["PICCheck"].Visible = false;
            dgvChiThiPheDuyet_ChiTiet.Columns["RuleStandard"].Visible = false;

            //Kích thước cột
            dgvChiThiPheDuyet_ChiTiet.Columns["LineName"].Width = 100;
            dgvChiThiPheDuyet_ChiTiet.Columns["ModelName"].Width = 140;
            dgvChiThiPheDuyet_ChiTiet.Columns["Step"].Width = 400;
            dgvChiThiPheDuyet_ChiTiet.Columns["NumberOrder"].Width = 60;
            dgvChiThiPheDuyet_ChiTiet.Columns["Stage"].Width = 110;

            dgvChiThiPheDuyet_ChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
            dgvChiThiPheDuyet_ChiTiet.ColumnHeadersDefaultCellStyle = headerStyle;

            // Tùy chọn: Điều chỉnh chiều cao của tiêu đề cột
            dgvChiThiPheDuyet_ChiTiet.ColumnHeadersHeight = 50;

            // Tùy chọn: Ngăn người dùng thay đổi kích thước tiêu đề cột
            dgvChiThiPheDuyet_ChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Tùy chọn: Cho phép sắp xếp khi click vào tiêu đề cột
            dgvChiThiPheDuyet_ChiTiet.EnableHeadersVisualStyles = false;


            //Đặt lại tên cột
            dgvChiThiPheDuyet_ChiTiet.Columns["Stage"].HeaderText = "Đầu mục";
            dgvChiThiPheDuyet_ChiTiet.Columns["NumberOrder"].HeaderText = "STT";
            dgvChiThiPheDuyet_ChiTiet.Columns["ModelName"].HeaderText = "Tên Model";
            dgvChiThiPheDuyet_ChiTiet.Columns["Actual"].HeaderText = "Thực tế";
            dgvChiThiPheDuyet_ChiTiet.Columns["LastChecked"].HeaderText = "Kiểm tra lần cuối";
            dgvChiThiPheDuyet_ChiTiet.Columns["Step"].HeaderText = "Tiêu chuẩn hoặc yêu cầu (Theo WI/Label/WS/WG)";
            ///////
            ///
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.WrapMode = DataGridViewTriState.True; // Cho phép xuống dòng
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiThiPheDuyet_ChiTiet.DefaultCellStyle = style;

            List<string> listOke = new List<string> { "Actual", "RuleStandard" };

            foreach (DataGridViewColumn dataGridViewColumn in dgvChiThiPheDuyet_ChiTiet.Columns)
            {
                if (!listOke.Contains(dataGridViewColumn.Name))
                {
                    dataGridViewColumn.ReadOnly = true;
                }

            }



            Font boldFont = new Font(dgvChiThiPheDuyet_ChiTiet.Font, FontStyle.Bold);

            //Set ReadOnly

            //Set Font
            dgvChiThiPheDuyet_ChiTiet.Columns["ModelName"].DefaultCellStyle.Font = boldFont;
            dgvChiThiPheDuyet_ChiTiet.Columns["Step"].DefaultCellStyle.Font = boldFont;

            dgvChiThiPheDuyet_ChiTiet.RowHeadersVisible = false;
            dgvChiThiPheDuyet_ChiTiet.BackgroundColor = Color.White;

            materialButton1.Enabled = true;

            foreach (DataGridViewRow row in dgvChiThiPheDuyet_ChiTiet.Rows)
            {
                if (Boolean.Parse(row.Cells["Result"].Value.ToString()))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);
                }
                else if (!Boolean.Parse(row.Cells["Result"].Value.ToString()) && row.Cells["Actual"].Value.ToString() == "")
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                }


                if (row.Cells["PICCheckId"].Value != null)
                {
                    row.Cells["PICCheckName"].Value = _chithisanxuatService.GetFullNameUser_By_Id(Guid.Parse(row.Cells["PICCheckId"].Value.ToString()));
                }
            }

            checkDone();
        }
        private bool loginInOneTextBox = false;
        private string _userCode;
        private string _password;

        private NguoiDung _nguoiDung;
        private void materialTextBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (loginInOneTextBox == true)
            {
                materialTextBox21.UseSystemPasswordChar = true;
            }
            else
            {
                materialTextBox21.UseSystemPasswordChar = false;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (loginInOneTextBox == false)
                {
                    loginInOneTextBox = true;
                    _userCode = materialTextBox21.Text;
                    materialTextBox21.PrefixSuffixText = "Password:";
                    materialTextBox21.Text = "";
                    materialTextBox21.TrailingIcon = ProductionDirectives.Properties.Resources.logout;
                }
                else
                {
                    //materialTextBox21.UseSystemPasswordChar = false;
                    _password = materialTextBox21.Text;
                    NguoiDung nguoiDung = _chithisanxuatService.GetUserBy_Code_and_Pass(_userCode, _password);
                    if (nguoiDung != null)
                    {
                        _nguoiDung = nguoiDung;
                        materialTextBox21.ReadOnly = true;
                        txtFullName.Text = _nguoiDung.First + " " + _nguoiDung.Last;

                        if (Admin.Contains(_nguoiDung.Grade))
                        {
                            materialSwitch1.Enabled = true;
                        }
                        else
                        {
                            materialSwitch1.Enabled = false;
                        }
                    }
                    else
                    {
                        MaterialMessageBox.Show("Sai mật khẩu hoặc user không tồn tại!");
                    }



                }
            }


        }

        private void materialTextBox21_TrailingIconClick(object sender, EventArgs e)
        {
            _nguoiDung = null;
            loginInOneTextBox = false;
            materialTextBox21.TrailingIcon = ProductionDirectives.Properties.Resources.user;
            materialTextBox21.PrefixSuffixText = "CVN Code:";
            materialTextBox21.UseSystemPasswordChar = false;
            materialTextBox21.ReadOnly = false;
            materialTextBox21.Text = "";
            materialSwitch1.Enabled = false;
            txtFullName.Text = "";
        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            if (_nguoiDung == null)
            {
                MaterialMessageBox.Show("Chưa xác nhận người thực hiện Dandory, vui lòng xác nhận!", "Thông báo!");
                materialTextBox21.Focus();
                return;
            }
            if (_Id_ChiThiPheDuyet == null)
            {
                MaterialMessageBox.Show("Chỉ thị phê duyệt chưa được chọn!", "Thông báo");
                return;
            }
            else
            {
                DialogResult result = MaterialMessageBox.Show(_messageDelete, "Thông báo", MessageBoxButtons.YesNo, true);
                if (result == DialogResult.Yes)
                {
                    bool resultDelete = await _chithisanxuatService.DeleteChiThiPheDuyet_By_Id(Guid.Parse(_Id_ChiThiPheDuyet));
                    if (resultDelete)
                    {

                        _chithisanxuatService.ReloadDataGridView_ChiThiPheDuyet(dgvChiThiPheDuyet);
                        MaterialMessageBox.Show("Xóa chỉ thị thành công", "Thông báo");
                    }
                    else
                    {
                        MaterialMessageBox.Show("Xóa chỉ thị thất bại", "Thông báo");
                    }
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            _chithisanxuatService.ReloadDataGridView_ChiThiPheDuyet(dgvChiThiPheDuyet);





        }

        private void ChiThiSanXuat_Load(object sender, EventArgs e)
        {
            //_chithisanxuatService.ReloadDataGridView_ChiThiPheDuyet(dgvChiThiPheDuyet);
        }

        private void btnReloadProgressProgram_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Lấy chương trình Mounter, AOI tự động!", btnReloadProgressProgram);


        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Tải lại danh sách chỉ thị!", btnRefresh);
        }

        private async Task<string> CallAPIAsync()
        {
            var client = new RestClient("http://192.168.173.96:8085");
            var request = new RestRequest($"/api/blocks/GetProgramByLine?lineName={txtLine.Text}", Method.Get);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                throw new Exception("Đã xảy ra lỗi khi gọi API: " + response.ErrorMessage);
            }
        }

        private async void btnReloadProgressProgram_Click(object sender, EventArgs e)
        {
            if (_Id_ChiThiPheDuyet == null)
            {
                MaterialMessageBox.Show("Hãy chọn chỉ thị trước khi lấy tên chương trình!", "Thông báo");
                return;
            }
            if (_nguoiDung == null)
            {
                MaterialMessageBox.Show("Chưa xác nhận người thực hiện Dandory, vui lòng xác nhận!", "Thông báo!");
                materialTextBox21.Focus();
                return;
            }
            try
            {
                btnReloadProgressProgram.Enabled = false;  // Disable button to prevent multiple clicks
                btnReloadProgressProgram.Text = "Loading...";
                dgvChiThiPheDuyet_ChiTiet.Enabled = false;
                ptLoading.Visible = true;

                string result = await CallAPIAsync();

                LineInfo lineInfo = JsonSerializer.Deserialize<LineInfo>(result);



                foreach (DataGridViewRow row in dgvChiThiPheDuyet_ChiTiet.Rows)
                {
                    string stage = row.Cells["Stage"].Value.ToString();
                    string step = row.Cells["Step"].Value.ToString();
                    int columnIndex = row.Cells["Actual"].ColumnIndex;
                    if (stage == "MOUNTER" && step.Contains("TOP") || stage == "MOUNTER" && step == "Tên chương trình")
                    {
                        var getProgram = lineInfo.Machine
                            .Where(m => m.MachineType == stage)
                            .Select(m => new
                            {
                                MachineName = m.MachineName,
                                TopProgramName = m.CurrentProgram
                                    .Where(p => p.SideName == "TOP" || p.SideName == "Unknown")
                                    .Select(p => p.ProgramName)
                                    .FirstOrDefault()
                            })
                            .FirstOrDefault();
                        string currentProgramName = getProgram != null ? getProgram.TopProgramName : "Không lấy được";

                        InputActual(currentProgramName, row, columnIndex);

                    }
                    if (stage == "MOUNTER" && step.Contains("BOT") || stage == "MOUNTER" && step == "Tên chương trình")
                    {
                        var getProgram = lineInfo.Machine
                                 .Where(m => m.MachineType == stage)
                                 .Select(m => new
                                 {
                                     MachineName = m.MachineName,
                                     TopProgramName = m.CurrentProgram
                                         .Where(p => p.SideName == "BOT" || p.SideName == "Unknown")
                                         .Select(p => p.ProgramName)
                                         .FirstOrDefault()
                                 })
                                 .FirstOrDefault();
                        string currentProgramName = getProgram != null ? getProgram.TopProgramName : "Không lấy được";

                        InputActual(currentProgramName, row, columnIndex);
                    }

                    if (stage == "AOI" && step.Contains("TOP"))
                    {
                        var getProgram = lineInfo.Machine
                            .Where(m => m.MachineType == stage)
                            .Select(m => new
                            {
                                MachineName = m.MachineName,
                                TopProgramName = m.CurrentProgram
                                    .Where(p => p.SideName == "TOP")
                                    .Select(p => p.ProgramName)
                                    .FirstOrDefault()
                            })
                            .FirstOrDefault();
                        string currentProgramName = getProgram != null ? getProgram.TopProgramName : "Không lấy được";

                        InputActual(currentProgramName, row, columnIndex);

                    }
                    else if (stage == "AOI" && step.Contains("BOT") || stage == "AOI" && step == "Tên chương trình")
                    {
                        var getProgram = lineInfo.Machine
                                 .Where(m => m.MachineType == stage)
                                 .Select(m => new
                                 {
                                     MachineName = m.MachineName,
                                     TopProgramName = m.CurrentProgram
                                         .Where(p => p.SideName == "BOT" || p.SideName == "Unknown")
                                         .Select(p => p.ProgramName)
                                         .FirstOrDefault()
                                 })
                                 .FirstOrDefault();

                        string currentProgramName = getProgram != null ? getProgram.TopProgramName : "Không lấy được";

                        InputActual(currentProgramName, row, columnIndex);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btnReloadProgressProgram.Enabled = true;
                btnReloadProgressProgram.Text = "Call API";
                dgvChiThiPheDuyet_ChiTiet.Enabled = true;
                ptLoading.Visible = false;
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_nguoiDung == null)
            {
                MaterialMessageBox.Show("Chưa xác nhận người thực hiện Dandory, vui lòng xác nhận!", "Thông báo!");
                materialTextBox21.Focus();
                return;
            }
            bool result = await _chithisanxuatService.PheDuyetChiThi_By_Id(Guid.Parse(_Id_ChiThiPheDuyet));
            if (result)
            {
                MaterialMessageBox.Show("Phê duyệt chỉ thị thành công!");
                _chithisanxuatService.ReloadDataGridView_ChiThiPheDuyet(dgvChiThiPheDuyet);
            }
            else
            {
                MaterialMessageBox.Show("Phê duyệt chỉ thị thất bại!");
            }
        }

        private void dgvChiThiPheDuyet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvChiThiPheDuyet.Rows[e.RowIndex];

                // Kiểm tra cột isDandory_Done (giả sử nó là cột cuối cùng và đang ẩn)
                bool isDandoryDone = Convert.ToBoolean(row.Cells["isDandory_Done"].Value);

                // Lấy giá trị CreateAt
                DateTime createAt = Convert.ToDateTime(row.Cells["CreateAt"].Value);

                // Tính thời gian chênh lệch
                TimeSpan timeDifference = DateTime.Now - createAt;

                if (isDandoryDone)
                {
                    // Nếu isDandory_Done là true, set màu xanh
                    row.DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);
                }
                else if (timeDifference.TotalMinutes <= 30)
                {
                    // Nếu thời gian tạo trong vòng 30 phút, set màu vàng
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                }
                else
                {
                    // Nếu thời gian tạo hơn 30 phút, set màu đỏ
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                }
            }
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvChiThiPheDuyet_ChiTiet.Rows.Count > 0)
                {
                    if (materialSwitch1.Checked == true)
                    {

                        dgvChiThiPheDuyet_ChiTiet.Columns["RuleStandard"].Visible = true;
                        materialSwitch1.Text = "ẩn cột Standard(Admin)";

                    }
                    else
                    {
                        dgvChiThiPheDuyet_ChiTiet.Columns["RuleStandard"].Visible = false;
                        materialSwitch1.Text = "hiện cột Standard(Admin)";

                    }
                }
                else
                {
                    MaterialMessageBox.Show("Hãy tìm chỉ thị trước khi hiện cột Standard!", "Thông báo");
                    materialSwitch1.Checked = false;
                    return;
                }
               
            }
            catch
            {

            }
        }
    }
}
