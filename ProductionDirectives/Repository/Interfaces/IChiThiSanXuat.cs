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

        List<ChiThiMau_ChiTiet> GetChiThiMau_ChiTietsBy_IdChiThiMau(Guid Id_ChiThiMau);

        Task<bool> DeleteChiThiMauById(Guid Id_ChiThiMau);

        Task<bool> UpdateChiThiMauChiTiet(List<ChiThiMau_ChiTiet> listChiThiMau_ChiTiets);

        List<ChiThiMau_ChiTiet> GetChiThiMau_ChiTiets_By_Line_And_Model_Name(string lineName,string modelName);

        Task<Guid> CreataChiThiPheDuyet(ChiThiPheDuyet chiThiPheDuyet);

        Task<bool> CreateChiThiPheDuyet_ChiTiet(List<ChiThiPheDuyet_ChiTiet> chiThiPheDuyet_ChiTiets);

        ChiThiPheDuyet ChiThiPheDuyet_CheckExist(string lineName, string modelName);

        List<ChiThiPheDuyet> GetListChiThiPheDuyets();

        List<ChiThiPheDuyet_ChiTiet> GetChiThiPheDuyet_ChiTiets_By_IdChiThiChiTiet(Guid Id_ChiThiChiTiet);
        Task<bool> DeleteChiThiPheDuyet_By_Id(Guid Id_ChiThiPheDuyet);

        Task<bool> UpdateSigleChiThiPheDuyet_ChiTiet_By_Id(ChiThiPheDuyet_ChiTiet chiThiPheDuyet_ChiTiet);

        Task<bool> ImportListUser(List<NguoiDung> nguoiDungs);

        NguoiDung GetUserBy_Code_and_Pass(string code,string password);

        string GetFullNameUser_By_Id(Guid Id_User);

        Task<bool> PheDuyetChiThi_By_Id(Guid Id);

        List<ChiThiPheDuyet> GetListChiThiPheDuyetsByDate(DateTime date);

        List<ChiThiPheDuyet> GetListChiThiPheDuyetsByDateRange(DateTime startDate, DateTime endDate);

        List<ChiThiPheDuyet> GetListChiThiPheDuyetsByMonth(DateTime date);
    }
}
