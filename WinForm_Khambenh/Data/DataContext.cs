using Microsoft.EntityFrameworkCore;
using System;
using WinForm_Khambenh.Model;

namespace WinForm_Khambenh.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<HoSoKhamBenh> HoSoKhamBenhs { get; set; }  // SỬA: đúng tên DbSet

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HoSoKhamBenhDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoSoKhamBenh>()
                .Property(h => h.MaHoSo)
                .ValueGeneratedNever();  // Tắt auto increment

            // Seed dữ liệu ban đầu
            modelBuilder.Entity<HoSoKhamBenh>().HasData(
                new HoSoKhamBenh { MaHoSo = 1, KhoaKham = "Nội tổng quát", MaBenhNhan = 101, NgayKham = DateTime.Today.AddDays(-2), LoaiBenh = "Cảm cúm", CapCuu = false },
                new HoSoKhamBenh { MaHoSo = 2, KhoaKham = "Ngoại chấn thương", MaBenhNhan = 102, NgayKham = DateTime.Today.AddDays(-1), LoaiBenh = "Gãy tay", CapCuu = true },
                new HoSoKhamBenh { MaHoSo = 3, KhoaKham = "Tai mũi họng", MaBenhNhan = 103, NgayKham = DateTime.Today, LoaiBenh = "Viêm họng", CapCuu = false }
            );
        }
    }
}
