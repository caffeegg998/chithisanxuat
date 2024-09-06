using ProductionDirectives.Models;
using ProductionDirectives.Models.Interfaces;
using ProductionDirectives.Repository.Interfaces;
using ProductionDirectives.Services.Interfaces;
using ScottPlot.Hatches;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Boolean = System.Boolean;

namespace ProductionDirectives.Services.Implements
{
    public class ImplementChithisanxuatService : IChithisanxuatService
    {
        private readonly IChiThiSanXuat _chiThiSanXuat;

        public ImplementChithisanxuatService(IChiThiSanXuat chiThiSanXuat) { 
            _chiThiSanXuat = chiThiSanXuat;
        }

        public ChiThiPheDuyet ChiThiPheDuyet_CheckExist(string lineName, string modelName)
        {
            return _chiThiSanXuat.ChiThiPheDuyet_CheckExist(lineName, modelName);
        }

        public async Task<Guid> CreataChiThiPheDuyet(ChiThiPheDuyet chiThiPheDuyet)
        {
            Guid id =  await _chiThiSanXuat.CreataChiThiPheDuyet(chiThiPheDuyet);
            return id;
        }

        public Guid CreateChiThiMau(ChiThiMau chiThiMau)
        {
            Guid guid =_chiThiSanXuat.CreateChiThiMau(chiThiMau);
            return guid;
        }

        public async Task<bool> CreateChiThiPheDuyet_ChiTiet(List<ChiThiPheDuyet_ChiTiet> chiThiPheDuyet_ChiTiets)
        {
            return await _chiThiSanXuat.CreateChiThiPheDuyet_ChiTiet(chiThiPheDuyet_ChiTiets);
        }

        public async Task<bool> DeleteChiThiMauById(Guid Id_ChiThiMau)
        {
            
            return await _chiThiSanXuat.DeleteChiThiMauById(Id_ChiThiMau);
        }

        public async Task<bool> DeleteChiThiPheDuyet_By_Id(Guid Id_ChiThiPheDuyet)
        {
            return await _chiThiSanXuat.DeleteChiThiPheDuyet_By_Id(Id_ChiThiPheDuyet);
        }

        public List<ChiThiMau_ChiTiet> GetChiThiMau_ChiTietsBy_IdChiThiMau(Guid guid)
        {
            List<ChiThiMau_ChiTiet> sapxeptheothutu = _chiThiSanXuat.GetChiThiMau_ChiTietsBy_IdChiThiMau(guid).OrderBy(c => c.NumberOrder).ToList();
            return sapxeptheothutu;
        }

        public List<ChiThiMau_ChiTiet> GetChiThiMau_ChiTiets_By_Line_And_Model_Name(string lineName, string modelName)
        {
            List <ChiThiMau_ChiTiet> chiThiMau_ChiTiets = _chiThiSanXuat.GetChiThiMau_ChiTiets_By_Line_And_Model_Name(lineName, modelName);

            return chiThiMau_ChiTiets.OrderBy(s => s.NumberOrder).ToList();
        }

        public List<ChiThiPheDuyet_ChiTiet> GetChiThiPheDuyet_ChiTiets_By_IdChiThiChiTiet(Guid Id_ChiThiChiTiet)
        {
            List<ChiThiPheDuyet_ChiTiet> sapxeptheothutu = _chiThiSanXuat.GetChiThiPheDuyet_ChiTiets_By_IdChiThiChiTiet(Id_ChiThiChiTiet).OrderBy(c => c.NumberOrder).ToList();
            return sapxeptheothutu;
        }

        public List<ChiThi_Template> GetChiThi_TemplateByLine(string lineName)
        {
            return _chiThiSanXuat.GetChiThi_TemplateByLine(lineName);
        }

        public string GetFullNameUser_By_Id(Guid Id_User)
        {
            return _chiThiSanXuat.GetFullNameUser_By_Id(Id_User);
        }

        public List<ChiThiMau> GetListChiThiMau()
        {
            return _chiThiSanXuat.GetListChiThiMau();
        }

        public List<ChiThiPheDuyet> GetListChiThiPheDuyets()
        {
            return _chiThiSanXuat.GetListChiThiPheDuyets();

        }

        public List<ChiThiPheDuyet> GetListChiThiPheDuyetsByDate(DateTime date)
        {
            return _chiThiSanXuat.GetListChiThiPheDuyetsByDate(date);
        }

        public List<ChiThiPheDuyet> GetListChiThiPheDuyetsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _chiThiSanXuat.GetListChiThiPheDuyetsByDateRange(startDate.ToUniversalTime(), endDate.ToUniversalTime());
        }

        public List<ChiThiPheDuyet> GetListChiThiPheDuyetsByMonth(DateTime date)
        {
            return _chiThiSanXuat.GetListChiThiPheDuyetsByMonth(date);
        }

        public NguoiDung GetUserBy_Code_and_Pass(string code, string password)
        {
            return _chiThiSanXuat.GetUserBy_Code_and_Pass(code, password);
        }

        public void ImportChiThiMau_ChiTiet(List<ChiThiMau_ChiTiet> listchithimau_ChiTiet)
        {
            _chiThiSanXuat.ImportChiThiMau_ChiTiet(listchithimau_ChiTiet);
        }

        public void ImportChiThiTemplate(List<ChiThi_Template> listChithi_Temp)
        {
            _chiThiSanXuat.ImportChiThiTemplate(listChithi_Temp);
        }

        public Task<bool> ImportListUser(List<NguoiDung> nguoiDungs)
        {
            return _chiThiSanXuat.ImportListUser(nguoiDungs);
        }

        public async Task<bool> PheDuyetChiThi_By_Id(Guid Id)
        {
            return await _chiThiSanXuat.PheDuyetChiThi_By_Id(Id);
        }

        public void ReloadDataGridView_ChiThiMau(DataGridView dataGridView)
        {
           
            dataGridView.DataSource = null;

            List<ChiThiMau> chiThiMaus =  _chiThiSanXuat.GetListChiThiMau();
            dataGridView.DataSource = chiThiMaus;
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["TotalStage"].Visible = false;
            dataGridView.Columns["TotalStep"].Visible = true;
            dataGridView.Columns["ChiTiets"].Visible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView.ReadOnly = true;


        }

        public void ReloadDataGridView_ChiThiPheDuyet(DataGridView dataGridView)
        {
            dataGridView.DataSource = null;

            List<ChiThiPheDuyet> chiThiMaus = _chiThiSanXuat.GetListChiThiPheDuyets();

           

            dataGridView.DataSource = chiThiMaus;
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["TotalStage"].Visible = false;
            dataGridView.Columns["TotalStep"].Visible = false;
            dataGridView.Columns["isDandory_Done"].Visible = false;
            dataGridView.Columns["PICCreate"].Visible = false;
            dataGridView.Columns["ChiThiPheDuyet_ChiTiets"].Visible = false;
            dataGridView.Columns["PICCreateNguoiDung"].Visible = false;

            //Column width
            dataGridView.Columns["LineName"].HeaderText = "Line";
            dataGridView.Columns["LineName"].Width = 40;
            dataGridView.Columns["Shift"].Width = 60;


            DataGridViewTextBoxColumn picNameColumn = new DataGridViewTextBoxColumn();
            picNameColumn.HeaderText = "Người tạo";
            picNameColumn.Name = "PICCreate_Name";

            if (dataGridView.Columns["PICCreate_Name"] != null)
            {
                // Nếu cột đã tồn tại, xóa nó
                dataGridView.Columns.Remove(dataGridView.Columns["PICCreate_Name"]);
            }

            // Thêm cột mới (hoặc thêm lại sau khi đã xóa)
            dataGridView.Columns.Add(picNameColumn);

            //Header 
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();

            // Thiết lập màu nền
            headerStyle.BackColor = Color.DodgerBlue;

            // Thiết lập màu chữ
            headerStyle.ForeColor = Color.White;

            // Thiết lập font chữ
            headerStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Căn giữa nội dung
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;

            ///Cell
            ///
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.WrapMode = DataGridViewTriState.True; // Cho phép xuống dòng
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.DefaultCellStyle = style;

            dataGridView.Columns["CreateAt"].Width = 120;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Font boldFont = new Font(dataGridView.Font, FontStyle.Bold);


            //Set Font
            dataGridView.Columns["ModelName"].DefaultCellStyle.Font = boldFont;


            foreach (DataGridViewRow row in dataGridView.Rows)
            {

                if (row.Cells["PICCreate"].Value != null)
                {
                    row.Cells["PICCreate_Name"].Value = _chiThiSanXuat.GetFullNameUser_By_Id(Guid.Parse(row.Cells["PICCreate"].Value.ToString()));
                }
            }

            dataGridView.ReadOnly = true;
            dataGridView.Refresh();
        }

        public async Task<bool> UpdateChiThiMauChiTiet(List<ChiThiMau_ChiTiet> chiThiMau_ChiTiets)
        {
            return await _chiThiSanXuat.UpdateChiThiMauChiTiet(chiThiMau_ChiTiets);
        }

        public async Task<bool> UpdateSigleChiThiPheDuyet_ChiTiet(DataGridViewRow dgvRow_ChiThiPheDuyet_ChiTiet)
        {
            string Id = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["Id"].Value.ToString();
            string LineName = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["LineName"].Value.ToString();
            string ModelName = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["ModelName"].Value.ToString();
            string Stage = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["Stage"].Value.ToString();
            string NumberOrder = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["NumberOrder"].Value.ToString();
            string Step = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["Step"].Value.ToString(); 
            string RuleStandard = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["RuleStandard"].Value.ToString();
            string Actual = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["Actual"].Value.ToString();
            string Result = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["Result"].Value.ToString();
            string LastChecked = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["LastChecked"].Value.ToString();
            string PICCheckId = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["PICCheckId"].Value?.ToString() ?? string.Empty;
            string Id_ChiThiPheDuyet = dgvRow_ChiThiPheDuyet_ChiTiet.Cells["Id_ChiThiPheDuyet"].Value.ToString();

            ChiThiPheDuyet_ChiTiet chiThiPheDuyet_ChiTiet = new ChiThiPheDuyet_ChiTiet
            {
                Id = Guid.Parse(Id),
                LineName = LineName,
                ModelName = ModelName,
                Stage = Stage,
                NumberOrder = Int16.Parse(NumberOrder),
                Step = Step,
                RuleStandard = RuleStandard,
                Actual = Actual,
                Result = Boolean.Parse(Result),
                LastChecked = DateTime.Parse(LastChecked).ToUniversalTime(),
                PICCheckId = Guid.TryParse(PICCheckId, out Guid picCheckIdGuid) ? picCheckIdGuid : null,
                Id_ChiThiPheDuyet = Guid.TryParse(Id_ChiThiPheDuyet, out Guid idChiThiPheDuyetGuid) ? idChiThiPheDuyetGuid : Guid.Empty
            };
            return await _chiThiSanXuat.UpdateSigleChiThiPheDuyet_ChiTiet_By_Id(chiThiPheDuyet_ChiTiet);
        }
    }
}
