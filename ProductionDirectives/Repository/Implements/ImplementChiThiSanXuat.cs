using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using ProductionDirectives.DbContexts;
using ProductionDirectives.Models;
using ProductionDirectives.Models.Interfaces;
using ProductionDirectives.Repository.Interfaces;
using ProductionDirectives.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        public ChiThiPheDuyet ChiThiPheDuyet_CheckExist(string lineName, string modelName)
        {
            ChiThiPheDuyet existingChiThi = _dbContext.ChiThiPheDuyets
                    .FirstOrDefault(c => c.ModelName == modelName && c.LineName == lineName);

            // Nếu bạn muốn kiểm tra xem có tồn tại không và xử lý
            if (existingChiThi != null)
            {
                MaterialMessageBox.Show($"Chỉ thị sản xuất Model: {modelName} đã tồn tại ở Line: {lineName}!");
                return null;

            }
            return existingChiThi;
        }

        public async Task<Guid> CreataChiThiPheDuyet(ChiThiPheDuyet chiThiPheDuyet)
        {
           
            _dbContext.ChiThiPheDuyets.Add(chiThiPheDuyet);
            await _dbContext.SaveChangesAsync();
            return chiThiPheDuyet.Id;


        }

        public Guid CreateChiThiMau(ChiThiMau chiThiMau)
        {
            _dbContext.Add(chiThiMau);
            _dbContext.SaveChanges();
            return chiThiMau.Id;

        }

        public async Task<bool> CreateChiThiPheDuyet_ChiTiet(List<ChiThiPheDuyet_ChiTiet> chiThiPheDuyet_ChiTiets)
        {
            try
            {
                _dbContext.ChiThiPheDuyet_ChiTiets.AddRange(chiThiPheDuyet_ChiTiets);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> DeleteChiThiMauById(Guid Id_ChiThiMau)
        {
            try
            {
                ChiThiMau chiThiMau_To_Delete = await _dbContext.ChiThiMaus.FindAsync(Id_ChiThiMau);
                _dbContext.ChiThiMaus.Remove(chiThiMau_To_Delete);
                _dbContext.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                MessageBox.Show("Xóa lỗi: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteChiThiPheDuyet_By_Id(Guid Id_ChiThiPheDuyet)
        {
            try
            {
                ChiThiPheDuyet chiThiPheDuyet = await _dbContext.ChiThiPheDuyets.FindAsync(Id_ChiThiPheDuyet);
                _dbContext.ChiThiPheDuyets.Remove(chiThiPheDuyet);
                _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa lỗi: " + ex.Message);
                return false;
            }
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

        public List<ChiThiMau_ChiTiet> GetChiThiMau_ChiTietsBy_IdChiThiMau(Guid Id_ChiThiMau)
        {
            List<ChiThiMau_ChiTiet> chiThiMau_ChiTiets = _dbContext.ChiThiMau_ChiTiets
                .Where(c => c.Id_ChiThiMau == Id_ChiThiMau)
                .AsNoTracking()
                .ToList();
            return chiThiMau_ChiTiets;
        }

        public List<ChiThiMau_ChiTiet> GetChiThiMau_ChiTiets_By_Line_And_Model_Name(string lineName, string modelName)
        {
            List<ChiThiMau_ChiTiet> chiThiMau_ChiTiets = _dbContext.ChiThiMau_ChiTiets.Where(c => c.LineName == lineName && c.ModelName == modelName).ToList();
            
            return chiThiMau_ChiTiets;
        }

        public List<ChiThiPheDuyet_ChiTiet> GetChiThiPheDuyet_ChiTiets_By_IdChiThiChiTiet(Guid Id_ChiThiChiTiet)
        {
            List<ChiThiPheDuyet_ChiTiet> chiThiPheDuyet_ChiTiets = _dbContext.ChiThiPheDuyet_ChiTiets
                .Where(c => c.Id_ChiThiPheDuyet == Id_ChiThiChiTiet)
                .Include(c => c.PICCheck)
                .AsNoTracking()
                .ToList();
            return chiThiPheDuyet_ChiTiets;
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

        public string GetFullNameUser_By_Id(Guid Id_User)
        {
            try
            {
                string fullName = _dbContext.NguoiDungs
               .Where(u => u.Id == Id_User)
               .Select(u => u.First + " " + u.Last)

               .FirstOrDefault();
                return fullName ?? "Unknown User";
            }catch (Exception ex)
            {
                return "Unknown User";
            }
        }

        public List<ChiThiMau> GetListChiThiMau()
        {
            return _dbContext.ChiThiMaus.ToList();
        }

        public List<ChiThiPheDuyet> GetListChiThiPheDuyets()
        {
            return _dbContext.ChiThiPheDuyets.AsNoTracking().OrderByDescending(c => c.CreateAt).Select(c => new ChiThiPheDuyet
            {
                Id = c.Id,
                LineName =c.LineName,
                ModelName = c.ModelName,
                CreateAt = c.CreateAt.ToLocalTime(),
                TotalStage = c.TotalStage,
                TotalStep = c.TotalStep,
                isDandory_Done = c.isDandory_Done,
                Shift = c.Shift,
                PICCreate = c.PICCreate
                // ...
            }).ToList();
           
        }

        public List<ChiThiPheDuyet> GetListChiThiPheDuyetsByDate(DateTime date)
        {
            return _dbContext.ChiThiPheDuyets
             .AsNoTracking()
             .Where(c => c.CreateAt.ToLocalTime().Date == date.Date)
             .OrderByDescending(c => c.CreateAt)
             .Select(c => new ChiThiPheDuyet
             {
                 Id = c.Id,
                 LineName = c.LineName,
                 ModelName = c.ModelName,
                 CreateAt = c.CreateAt.ToLocalTime(),
                 TotalStage = c.TotalStage,
                 TotalStep = c.TotalStep,
                 isDandory_Done = c.isDandory_Done,
                 Shift = c.Shift,
                 PICCreate = c.PICCreate
                 // Thêm các trường khác nếu cần
             })
             .ToList();
        }

        public List<ChiThiPheDuyet> GetListChiThiPheDuyetsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dbContext.ChiThiPheDuyets
                .AsNoTracking()
                .Where(c => c.CreateAt.Date >= startDate.Date && c.CreateAt.Date <= endDate.Date)
                .OrderByDescending(c => c.CreateAt)
                .Select(c => new ChiThiPheDuyet
                {
                    Id = c.Id,
                    LineName = c.LineName,
                    ModelName = c.ModelName,
                    CreateAt = c.CreateAt.ToLocalTime(),
                    TotalStage = c.TotalStage,
                    TotalStep = c.TotalStep,
                    isDandory_Done = c.isDandory_Done,
                    Shift = c.Shift,
                    PICCreate = c.PICCreate
                    // Thêm các trường khác nếu cần
                })
                .ToList();
        }

        public List<ChiThiPheDuyet> GetListChiThiPheDuyetsByMonth(DateTime date)
        {
            DateTime startOfMonth = new DateTime(date.Year, date.Month,1 ).ToUniversalTime();

            // Xác định ngày cuối tháng
            DateTime endOfMonth = startOfMonth.AddMonths(1).ToUniversalTime();

            return _dbContext.ChiThiPheDuyets
                .AsNoTracking()
                .Where(c => c.CreateAt.Date >= startOfMonth && c.CreateAt.Date <= endOfMonth)
                .OrderByDescending(c => c.CreateAt)
                .Select(c => new ChiThiPheDuyet
                {
                    Id = c.Id,
                    LineName = c.LineName,
                    ModelName = c.ModelName,
                    CreateAt = c.CreateAt.ToLocalTime(),
                    TotalStage = c.TotalStage,
                    TotalStep = c.TotalStep,
                    isDandory_Done = c.isDandory_Done,
                    Shift = c.Shift,
                    PICCreate = c.PICCreate
                    // Thêm các trường khác nếu cần
                })
                .ToList();
        }

        public NguoiDung GetUserBy_Code_and_Pass(string code,string password)
        {
            try
            {
              
                NguoiDung nguoidung = _dbContext.NguoiDungs.FirstOrDefault(c => c.Code == code);
                if(nguoidung != null)
                {
                    string passwordHash = nguoidung.Password;
                    bool checkPassword = PasswordHasher.VerifyPassword(password, passwordHash);

                    if (checkPassword)
                    {
                        return nguoidung;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
              
            }
            catch(Exception ex)
            {
                return null;
            }
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

        public async Task<bool> ImportListUser(List<NguoiDung> nguoiDungs)
        {
            try {
                _dbContext.NguoiDungs.AddRange(nguoiDungs);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> PheDuyetChiThi_By_Id(Guid Id)
        {
            try
            {
                ChiThiPheDuyet chiThiPheDuyet = await _dbContext.ChiThiPheDuyets.FindAsync(Id);
                chiThiPheDuyet.isDandory_Done = true;

                _dbContext.ChiThiPheDuyets.Update(chiThiPheDuyet);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateChiThiMauChiTiet(List<ChiThiMau_ChiTiet> listChiThiMau_ChiTiets)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.ChiThiMau_ChiTiets.UpdateRange(listChiThiMau_ChiTiets);
                await _dbContext.SaveChangesAsync();
                return true;    
            } catch (Exception ex)
            {
                MaterialMessageBox.Show("Cập nhật thất bại");
                return false;
            }
        }

        public async Task<bool> UpdateSigleChiThiPheDuyet_ChiTiet_By_Id(ChiThiPheDuyet_ChiTiet chiThiPheDuyet_ChiTiet)
        {
            try
            {
                Debug.WriteLine($"Update completed for: {chiThiPheDuyet_ChiTiet.Id}");
                _dbContext.ChangeTracker.Clear();
                _dbContext.ChiThiPheDuyet_ChiTiets.Update(chiThiPheDuyet_ChiTiet);

                await _dbContext.SaveChangesAsync();
               

                return true;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("Cập nhật thất bại");
                return false;
            }
        }
    }
}
