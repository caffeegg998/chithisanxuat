using Microsoft.EntityFrameworkCore;
using ProductionDirectives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.DbContexts
{
    public class ProductionDirectivesDbContext:DbContext
    {
        public ProductionDirectivesDbContext()
        {

        }

        public ProductionDirectivesDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<ChiThi_Template> ChiThi_Templates { get; set; }
        public DbSet<ChiThiMau> ChiThiMaus { get; set; }
        public DbSet<ChiThiMau_ChiTiet> ChiThiMau_ChiTiets { get; set; }
        public DbSet<ChiThiPheDuyet> ChiThiPheDuyets { get; set; }
        public DbSet<ChiThiPheDuyet_ChiTiet> ChiThiPheDuyet_ChiTiets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=192.168.1.101;Database=ProductionDirective;Username=postgres;Password=root");
                //optionsBuilder.UseSqlite("Data Source=mydb.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChiThiMau>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasMany(e => e.ChiTiets)
                      .WithOne(e => e.ChiThiMau)
                      .HasForeignKey(e => e.Id_ChiThiMau)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ChiThiMau_ChiTiet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.ChiThiMau)
                      .WithMany(e => e.ChiTiets)
                      .HasForeignKey(e => e.Id_ChiThiMau)
                      .OnDelete(DeleteBehavior.Cascade);
            });




            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

        }
    }
}
