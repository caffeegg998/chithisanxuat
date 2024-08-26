using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using ProductionDirectives.DbContexts;
using ProductionDirectives.Models;
using ProductionDirectives.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Repository.Implements
{
    
    public class ImplementChiThiSanXuat : IChiThiSanXuat
    {
        private readonly ProductionDirectivesDbContext _dbContext;

        public ImplementChiThiSanXuat(ProductionDirectivesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid CreateChiThiMau(ChiThiMau chiThiMau)
        {
            _dbContext.Add(chiThiMau);
            _dbContext.SaveChanges();
            return chiThiMau.Id;

        }

        public async Task DeleteChiThiTemplate()
        {
            try
            {
                _dbContext.ChiThi_Templates.ExecuteDelete();
              
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<ChiThi_Template> GetChiThi_TemplateByLine(string lineName)
        {

            List<ChiThi_Template> chiThi_Template_By_Line = _dbContext.ChiThi_Templates
                .Where(row => row.LineName == lineName)
                .Select(row => new ChiThi_Template
                {
                   LineName = row.LineName,
                   ModelName = row.ModelName,
                   Step = row.Step,
                   Stage = row.Stage,
                   NumberOrder = row.NumberOrder,
                   RuleStandard = row.RuleStandard
                })
                .ToList();
            return chiThi_Template_By_Line;
        }

        public List<ChiThiMau> GetListChiThiMau()
        {
            return _dbContext.ChiThiMaus.ToList();
        }

        public void ImportChiThiMau_ChiTiet(List<ChiThiMau_ChiTiet> chiThiMau_ChiTiet)
        {
            try
            {
                _dbContext.ChiThiMau_ChiTiets.AddRange(chiThiMau_ChiTiet);
                _dbContext.SaveChanges();
            }catch (Exception ex)
            {

            }
            
        }

        public void ImportChiThiTemplate(List<ChiThi_Template> listChiThi_Template)
        {
            _dbContext.ChiThi_Templates.AddRange(listChiThi_Template);
            _dbContext.SaveChanges();
        }
    }
}
