using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductionDirectives.DbContexts;
using ProductionDirectives.Forms;
using ProductionDirectives.Forms.User_Controls;
using ProductionDirectives.Repository.Implements;
using ProductionDirectives.Repository.Interfaces;
using ProductionDirectives.Services.Implements;
using ProductionDirectives.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductionDirectivesDbContext>();
            //services.AddTransient<IPNDBRepository, ImplementPNDBRepository>();
            services.AddTransient<Func<IChithisanxuatService, QuanLyChiThi>>(sp =>
                    pndbRepository => new QuanLyChiThi(pndbRepository));
            //services.AddTransient<IScanLinhkienFuji, ImplementScanLinhKienFuji>();
            services.AddTransient<IChiThiSanXuat, ImplementChiThiSanXuat>();
            services.AddTransient<IChithisanxuatService,ImplementChithisanxuatService>();  
            services.AddTransient<MainForm>();

        }
    }
}
