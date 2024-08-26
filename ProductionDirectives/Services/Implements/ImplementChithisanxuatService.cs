using ProductionDirectives.Models;
using ProductionDirectives.Repository.Interfaces;
using ProductionDirectives.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Services.Implements
{
    public class ImplementChithisanxuatService : IChithisanxuatService
    {
        private readonly IChiThiSanXuat _chiThiSanXuat;

        public ImplementChithisanxuatService(IChiThiSanXuat chiThiSanXuat) { 
            _chiThiSanXuat = chiThiSanXuat;
        }

        public Guid CreateChiThiMau(ChiThiMau chiThiMau)
        {
            Guid guid =_chiThiSanXuat.CreateChiThiMau(chiThiMau);
            return guid;
        }

        public List<ChiThi_Template> GetChiThi_TemplateByLine(string lineName)
        {
            return _chiThiSanXuat.GetChiThi_TemplateByLine(lineName);
        }

        public void ImportChiThiMau_ChiTiet(List<ChiThiMau_ChiTiet> listchithimau_ChiTiet)
        {
            _chiThiSanXuat.ImportChiThiMau_ChiTiet(listchithimau_ChiTiet);
        }

        public void ImportChiThiTemplate(List<ChiThi_Template> listChithi_Temp)
        {
            _chiThiSanXuat.ImportChiThiTemplate(listChithi_Temp);
        }

        public void ReloadDataGridView_ChiThiMau(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.DataSource = null;

            List<ChiThiMau> chiThiMaus =  _chiThiSanXuat.GetListChiThiMau();
            dataGridView.DataSource = chiThiMaus;
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["TotalStage"].Visible = false;
            dataGridView.Columns["TotalStep"].Visible = true;
            dataGridView.Columns["ChiTiets"].Visible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.RowHeadersVisible = false;


        }
    }
}
