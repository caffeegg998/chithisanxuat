using ProductionDirectives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Services.Interfaces
{
    public interface IChithisanxuatService
    {
        void ReloadDataGridView_ChiThiMau(DataGridView dataGridView);

        List<ChiThi_Template> GetChiThi_TemplateByLine(string lineName);

        Guid CreateChiThiMau(ChiThiMau chiThiMau);

        void ImportChiThiMau_ChiTiet(List<ChiThiMau_ChiTiet> listchithimau_ChiTiet);

        void ImportChiThiTemplate(List<ChiThi_Template> listChithi_Temp);

    }
}
