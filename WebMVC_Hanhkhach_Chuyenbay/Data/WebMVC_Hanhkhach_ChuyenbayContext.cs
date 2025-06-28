using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMVC_Hanhkhach_Chuyenbay.Models;

namespace WebMVC_Hanhkhach_Chuyenbay.Data
{
    public class WebMVC_Hanhkhach_ChuyenbayContext : DbContext
    {
        public WebMVC_Hanhkhach_ChuyenbayContext(DbContextOptions<WebMVC_Hanhkhach_ChuyenbayContext> options)
            : base(options)
        {
        }

        public DbSet<WebMVC_Hanhkhach_Chuyenbay.Models.HanhKhach> HanhKhach { get; set; } = default!;

        public DbSet<WebMVC_Hanhkhach_Chuyenbay.Models.ChuyenBay>? ChuyenBay { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChuyenBay>()
                .HasOne(c => c.HanhKhach)
                .WithMany(h => h.ChuyenBays)
                .HasForeignKey(c => c.MaHanhKhach)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<HanhKhach>().HasData(
                new HanhKhach { MaHanhKhach = 1, HoTen = "Nguyen Van A", SoCMND = "123456789", SoDT = "0987654321", NoiDen = "Hanoi" },
                new HanhKhach { MaHanhKhach = 2, HoTen = "Tran Thi B", SoCMND = "987654321", SoDT = "0123456789", NoiDen = "Ho Chi Minh City" },
                new HanhKhach { MaHanhKhach = 3, HoTen = "Le Van C", SoCMND = "456789123", SoDT = "1234567890", NoiDen = "Da Nang" }
                );
            modelBuilder.Entity<ChuyenBay>().HasData(
                new ChuyenBay { MaChuyenBay = 1, MaHanhKhach = 1, NgayBay = new DateTime(2023, 10, 1), GiaVe = 1000000 },
                new ChuyenBay { MaChuyenBay = 4, MaHanhKhach = 1, NgayBay = new DateTime(2023, 10, 1), GiaVe = 1000000 },
                new ChuyenBay { MaChuyenBay = 2, MaHanhKhach = 2, NgayBay = new DateTime(2023, 10, 2), GiaVe = 1500000 },
                new ChuyenBay { MaChuyenBay = 5, MaHanhKhach = 2, NgayBay = new DateTime(2023, 10, 2), GiaVe = 1500000 },
                new ChuyenBay { MaChuyenBay = 3, MaHanhKhach = 3, NgayBay = new DateTime(2023, 10, 3), GiaVe = 2000000 },
                new ChuyenBay { MaChuyenBay = 6, MaHanhKhach = 3, NgayBay = new DateTime(2023, 10, 3), GiaVe = 2000000 }
                );               }
    }

}
