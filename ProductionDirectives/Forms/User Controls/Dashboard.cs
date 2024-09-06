using MaterialSkin.Controls;
using ProductionDirectives.Models;
using ProductionDirectives.Services.Interfaces;
using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OfficeOpenXml.ExcelErrorValue;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Color = System.Drawing.Color;
using FontStyle = System.Drawing.FontStyle;

namespace ProductionDirectives.Forms.User_Controls
{
    public partial class Dashboard : UserControl
    {
        private readonly IChithisanxuatService _chithisanxuatService;
        private List<MaterialButton> materialButtons_list;
        public Dashboard(IChithisanxuatService ichiThiSanXuat)
        {
            InitializeComponent();
            materialButtons_list = new List<MaterialButton> { materialButton1, materialButton2, materialButton3 };
            _chithisanxuatService = ichiThiSanXuat;
            _chithisanxuatService.ReloadDataGridView_ChiThiPheDuyet(dgvChiThiPheDuyet);
            dgvChiThiPheDuyet.MouseWheel += DgvChiThiPheDuyet_MouseWheel;
            dgvChiThiPheDuyet.CellFormatting += dgvChiThiPheDuyet_CellFormatting;
            dgvChiThiPheDuyet.CellClick += DgvChiThiPheDuyet_CellClick;

            dgvChiThiPheDuyet_ChiTiet.MouseWheel += DgvChiThiPheDuyet_ChiTiet_MouseWheel;
            InitChar(DateTime.Now);
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

        private bool initColumne_Once = false;
        private void DgvChiThiPheDuyet_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow roww = dgvChiThiPheDuyet.Rows[e.RowIndex];

                // Xử lý dữ liệu từ hàng được chọn
                // Ví dụ: hiển thị dữ liệu lên các TextBox
                string Id = roww.Cells["Id"].Value.ToString();
                string lineName = roww.Cells["LineName"].Value.ToString();
                string modelName = roww.Cells["ModelName"].Value.ToString();
                DateTime createAt = DateTime.Parse(roww.Cells["CreateAt"].Value.ToString());
                string caKip = roww.Cells["Shift"].Value.ToString();
                bool isDandory_Done = Boolean.Parse(roww.Cells["isDandory_Done"].Value.ToString());

                //Id_Chithichitiet = Guid.Parse(Id);



                List<ChiThiPheDuyet_ChiTiet> listChiThiPheDuyet_ChiTiet = _chithisanxuatService.GetChiThiPheDuyet_ChiTiets_By_IdChiThiChiTiet(Guid.Parse(Id));



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


            }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            _chithisanxuatService.ReloadDataGridView_ChiThiPheDuyet(dgvChiThiPheDuyet);
            InitChar(DateTime.Now);
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

        private void ScottPlotInit(List<ChartModel> chartModels, List<LengendPlot> listLengenPlots)
        {
            // Sử dụng Plot từ FormsPlot thay vì tạo mới
            ScottPlot.Plot myPlot = formsPlot1.Plot;

            // Xóa tất cả các phần tử hiện có trên biểu đồ (nếu cần)
            myPlot.Clear();
            ScottPlot.Palettes.Category10 palette = new();

            List<ScottPlot.Bar> bars = new List<ScottPlot.Bar>();
            List<Tick> tickList = new List<Tick>();
            foreach (ChartModel chartModel in chartModels)
            {
                bars.AddRange(chartModel.bars);
                tickList.Add(new Tick(chartModel.position_Group, chartModel.lineName_Group));
            }

            var barPlot = myPlot.Add.Bars(bars);
            myPlot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(tickList.ToArray());

            // Các cài đặt khác giữ nguyên như cũ

            myPlot.Legend.IsVisible = true;
            myPlot.Legend.Alignment = Alignment.UpperLeft;
            myPlot.Legend.Orientation = ScottPlot.Orientation.Horizontal;


            myPlot.Axes.Bottom.MajorTickStyle.Length = 10;
            myPlot.HideGrid();

            myPlot.Legend.ManualItems.Clear();
            foreach (LengendPlot lengend in listLengenPlots)
            {
                myPlot.Legend.ManualItems.Add(new() { LabelText = lengend.LabelText, FillColor = lengend.FillColor });
            }


            //formsPlot1.Plot.Title($"CHỈ THỊ SẢN XUẤT SMT NGÀY {DateTime.Now.ToString("dd-MM-yyyy")}");
            myPlot.XLabel("Tên Line");
            myPlot.YLabel("Số lượng chỉ thị");


            myPlot.Axes.Bottom.Label.Bold = true;
            myPlot.Axes.Bottom.Label.FontName = Fonts.Monospace;

            myPlot.Axes.Bottom.MajorTickStyle.Length = 10;
            myPlot.Axes.Bottom.MajorTickStyle.Width = 3;
            myPlot.Axes.Bottom.MajorTickStyle.Color = Colors.Magenta;
            myPlot.Axes.Bottom.MinorTickStyle.Length = 5;
            myPlot.Axes.Bottom.MinorTickStyle.Width = 0.5f;
            myPlot.Axes.Bottom.MinorTickStyle.Color = Colors.Green;
            myPlot.Axes.Bottom.FrameLineStyle.Color = Colors.Blue;
            myPlot.Axes.Bottom.FrameLineStyle.Width = 3;

            myPlot.Axes.Right.FrameLineStyle.Width = 0;
            myPlot.Axes.Right.MajorTickStyle.Hairline = true;



            foreach (var bar in barPlot.Bars)
            {
                bar.Label = bar.Value.ToString();
            }

            // customize label style
            barPlot.ValueLabelStyle.Bold = true;
            barPlot.ValueLabelStyle.FontSize = 18;

            myPlot.Axes.Margins(bottom: 0, top: .2);

            //myPlot.Font.Automatic(); // set font for each item based on its content
            int totalMax = chartModels.Max(cm => cm.total_ChiThi);
            myPlot.Axes.SetLimits(0, chartModels[chartModels.Count - 1].position_Group + 3, 0, totalMax + 3);

            AxisLimits limits = formsPlot1.Plot.Axes.GetLimits();
            ScottPlot.AxisRules.LockedVertical rule = new(formsPlot1.Plot.Axes.Left, limits.Bottom, limits.Top);
            ScottPlot.AxisRules.LockedHorizontal rule_Horizontal = new(formsPlot1.Plot.Axes.Bottom, limits.Left, limits.Right);
            formsPlot1.Plot.Axes.Rules.Clear();
            formsPlot1.Plot.Axes.Rules.Add(rule);
            formsPlot1.Plot.Axes.Rules.Add(rule_Horizontal);
            formsPlot1.Refresh();


            // Cập nhật và vẽ lại biểu đồ
            formsPlot1.Refresh();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InitChar(DateTime dateTime)
        {
            List<string> lineToInit = new List<string> { "S4", "S9", "S10", "M6", "M7", "M8" };

            var highEmphasisButton = materialButtons_list.FirstOrDefault(button => button.HighEmphasis);
            List<ChiThiPheDuyet> chiThiPheDuyets = new List<ChiThiPheDuyet>();


            int weekNumber = GetWeekNumberInMonth(dateTime);

            // Tính ngày bắt đầu và kết thúc của tuần
            DateTime startOfWeek = dateTime.AddDays(-(int)dateTime.DayOfWeek + (int)DayOfWeek.Monday);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            switch (highEmphasisButton.Text)
            {
                case "Ngày":
                    chiThiPheDuyets = _chithisanxuatService.GetListChiThiPheDuyetsByDate(dateTime);
                    formsPlot1.Plot.Title($"CHỈ THỊ SẢN XUẤT SMT NGÀY {dateTime.ToString("dd-MM-yyyy")}");
                    formsPlot1.Refresh();
                    break;
                case "Tuần":
                    chiThiPheDuyets = _chithisanxuatService.GetListChiThiPheDuyetsByDateRange(startOfWeek, endOfWeek);
                    formsPlot1.Plot.Title($"CHỈ THỊ SẢN XUẤT SMT TUẦN {weekNumber} THÁNG {startOfWeek:MM} NĂM 2024");
                    formsPlot1.Refresh();
                    break;
                case "Tháng":
                    chiThiPheDuyets = _chithisanxuatService.GetListChiThiPheDuyetsByMonth(dateTime);
                    formsPlot1.Plot.Title($"CHỈ THỊ SẢN XUẤT SMT THÁNG {startOfWeek:MM} NĂM 2024");
                    formsPlot1.Refresh();
                    break;
                default:
                    break;
            }




            ScottPlot.Palettes.Category10 palette = new();
            List<ChartModel> chartModels = new List<ChartModel>();

            List<LengendPlot> listLengenPlots = new List<LengendPlot>
            {
                new LengendPlot {LabelText = "Chưa duyệt" , FillColor = Colors.Red},
                new LengendPlot {LabelText = "Đã duyệt" , FillColor = Colors.Green},
                new LengendPlot {LabelText = "Tổng chỉ thị" , FillColor = Colors.DarkCyan}
            };

            foreach (string lineName in lineToInit)
            {
                List<ChiThiPheDuyet> chiThiPheDuyets_Filter_By_Single_Line = chiThiPheDuyets.Where(c => c.LineName == lineName).ToList();

                // Hoặc bạn có thể sử dụng cách sau để đếm cả true và false cùng lúc
                var counts = chiThiPheDuyets_Filter_By_Single_Line
                    .GroupBy(c => c.isDandory_Done)
                    .ToDictionary(g => g.Key, g => g.Count());

                int countTrue = counts.TryGetValue(true, out int trueCount) ? trueCount : 0;
                int countFalse = counts.TryGetValue(false, out int falseCount) ? falseCount : 0;
                int total = countTrue + countFalse;

                int position_Group = chartModels.Count > 0 ? chartModels[chartModels.Count - 1].position_Group + 4 : 2;


                ChartModel chartModel = new ChartModel
                {
                    lineName_Group = lineName,
                    position_Group = position_Group,
                    total_ChiThi = total,
                    bars = new List<ScottPlot.Bar>
                    {
                        new ScottPlot.Bar { Position = position_Group - 1, Value = countFalse, FillColor = listLengenPlots[0].FillColor },
                        new ScottPlot.Bar { Position = position_Group, Value = countTrue, FillColor = listLengenPlots[1].FillColor },
                        new ScottPlot.Bar { Position = position_Group + 1, Value = total, FillColor = listLengenPlots[2].FillColor }
                    }
                };
                chartModels.Add(chartModel);
            }
            ScottPlotInit(chartModels, listLengenPlots);
        }
        private void activeButton(List<MaterialButton> materialButtons, MaterialButton activeButton)
        {
            foreach (MaterialButton materialButton in materialButtons)
            {
                if (materialButton.Text == activeButton.Text)
                {
                    materialButton.HighEmphasis = true;
                }
                else
                {
                    materialButton.HighEmphasis = false;
                }
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Title($"CHỈ THỊ SẢN XUẤT SMT NGÀY {DateTime.Now.ToString("dd-MM-yyyy")}");
            formsPlot1.Refresh();
            activeButton(materialButtons_list, materialButton2);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

            activeButton(materialButtons_list, materialButton1);

            InitChar(DateTime.Now);
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Title($"CHỈ THỊ SẢN XUẤT SMT THÁNG 8 NĂM 2024");
            formsPlot1.Refresh();

            activeButton(materialButtons_list, materialButton3);
            InitChar(DateTime.Now);

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

            DateTime selectedDate = e.Start;

            var highEmphasisButton = materialButtons_list.FirstOrDefault(button => button.HighEmphasis);

            if (highEmphasisButton.Text == "Ngày")
            {
                InitChar(selectedDate);
            }
            else if (highEmphasisButton.Text == "Tuần")
            {
                // Lấy tháng và năm từ ngày được chọn
                int month = selectedDate.Month;
                int year = selectedDate.Year;

                // Tính số tuần trong tháng
                int weekNumber = GetWeekNumberInMonth(selectedDate);

                // Tính ngày bắt đầu và kết thúc của tuần
                DateTime startOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + (int)DayOfWeek.Monday);
                DateTime endOfWeek = startOfWeek.AddDays(6);

                //formsPlot1.Plot.Title($"CHỈ THỊ SẢN XUẤT SMT TUẦN {weekNumber} ngày {startOfWeek:dd} - {endOfWeek:dd} THÁNG 8 NĂM 2024");
                formsPlot1.Refresh();

                InitChar(selectedDate);
            }


        }

        private int GetWeekNumberInMonth(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Tính số tuần
            int totalDays = (lastDayOfMonth - firstDayOfMonth).Days + 1; // Tổng số ngày trong tháng
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek; // Ngày bắt đầu của tháng

            // Tính số tuần
            int weeks = (totalDays + startDayOfWeek + 6) / 7;

            // Tính tuần hiện tại
            int weekNumber = (date.Day + startDayOfWeek - 1) / 7 + 1;

            return weekNumber;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            InitChar(DateTime.Now);

        }

        private void materialButton3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Hiển thị tất cả chỉ thị sản xuất trong tháng này!", materialButton3);
        }

        private void materialButton1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Hiển thị tất cả chỉ thị sản xuất trong tuần này!", materialButton1);
        }

        private void materialButton2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Hiển thị tất cả chỉ thị sản xuất trong ngày (chọn bên dưới lịch)!", materialButton2);
        }

        private void dgvChiThiPheDuyet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class LengendPlot()
    {
        public string LabelText { get; set; }
        public ScottPlot.Color FillColor { get; set; }
    }
}
