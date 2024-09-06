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

        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<ChiThi_Template> ChiThi_Templates { get; set; }
        public DbSet<ChiThiMau> ChiThiMaus { get; set; }
        public DbSet<ChiThiMau_ChiTiet> ChiThiMau_ChiTiets { get; set; }
        public DbSet<ChiThiPheDuyet> ChiThiPheDuyets { get; set; }
        public DbSet<ChiThiPheDuyet_ChiTiet> ChiThiPheDuyet_ChiTiets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=192.168.173.96;Database=ProductionDirective;Username=sa;Password=admin!23");
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

            modelBuilder.Entity<ChiThiPheDuyet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                // Quan hệ với NguoiDung (PICCreate)
                entity.HasOne(e => e.PICCreateNguoiDung)
                      .WithMany(e => e.ChiThiPheDuyets)
                      .HasForeignKey(e => e.PICCreate)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(e => e.ChiThiPheDuyet_ChiTiets)
                      .WithOne(e => e.ChiThiPheDuyet)
                      .HasForeignKey(e => e.Id_ChiThiPheDuyet)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ChiThiPheDuyet_ChiTiet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                // Quan hệ với NguoiDung (PICCheck)
                entity.HasOne(e => e.PICCheck)
                      .WithMany(e => e.ChiThiPheDuyetChiTiets)
                      .HasForeignKey(e => e.PICCheckId)
                      .IsRequired(false)  // Đặt IsRequired(false) để cho phép null
                      .OnDelete(DeleteBehavior.Restrict);
                // Quan hệ với ChiThiPheDuyet
                entity.HasOne(e => e.ChiThiPheDuyet)
                      .WithMany(e => e.ChiThiPheDuyet_ChiTiets)
                      .HasForeignKey(e => e.Id_ChiThiPheDuyet)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.Password).IsRequired();

                // Quan hệ với ChiThiPheDuyet_ChiTiet
                entity.HasMany(e => e.ChiThiPheDuyetChiTiets)
                      .WithOne(e => e.PICCheck)
                      .HasForeignKey(e => e.PICCheckId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Quan hệ mới với ChiThiPheDuyet
                entity.HasMany(e => e.ChiThiPheDuyets)
                      .WithOne(e => e.PICCreateNguoiDung)
                      .HasForeignKey(e => e.PICCreate)
                      .OnDelete(DeleteBehavior.Restrict);
            });




            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

        }
    }
}
