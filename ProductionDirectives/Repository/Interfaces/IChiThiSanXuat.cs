using ProductionDirectives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Repository.Interfaces
{
    public interface IChiThiSanXuat
    {
        void ImportChiThiTemplate(List<ChiThi_Template> listChiThi_Template);
        Task DeleteChiThiTemplate();

        List<ChiThi_Template> GetChiThi_TemplateByLine(string lineName);

        Guid CreateChiThiMau(ChiThiMau chiThiMau);

        void ImportChiThiMau_ChiTiet(List<ChiThiMau_ChiTiet> chiThiMau_ChiTiet);

        List<ChiThiMau> GetListChiThiMau();
    }
}
