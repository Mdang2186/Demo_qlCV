using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMVC_GiaoVien_LichGiangDay.Models;

namespace WebMVC_GiaoVien_LichGiangDay.Data
{
    public class WebMVC_GiaoVien_LichGiangDayContext : DbContext
    {
        public WebMVC_GiaoVien_LichGiangDayContext (DbContextOptions<WebMVC_GiaoVien_LichGiangDayContext> options)
            : base(options)
        {
        }

        public DbSet<WebMVC_GiaoVien_LichGiangDay.Models.LichGiangDay> LichGiangDay { get; set; } = default!;

        public DbSet<WebMVC_GiaoVien_LichGiangDay.Models.GiaoVien>? GiaoVien { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            // Optional: specify delete behavior
            modelBuilder.Entity<GiaoVien>().HasData(
                new GiaoVien { MaGV = 1, HoTen = "Nguyen Van A", BoMon = "Toan", SoDienThoai = "0123456789" },
                new GiaoVien { MaGV = 2, HoTen = "Tran Thi B", BoMon = "Ly", SoDienThoai = "0987654321" },
                new GiaoVien { MaGV = 3, HoTen = "Tran Thi c", BoMon = "văn", SoDienThoai = "09876325246" }
            );
            modelBuilder.Entity<LichGiangDay>().HasData(
                    new LichGiangDay { MaLich = 1, MaGV = 1, TenMonHoc = "Toan", NgayGiangDay = new DateTime(2023, 10, 1) },
                    new LichGiangDay { MaLich = 2, MaGV = 1, TenMonHoc = "Ly", NgayGiangDay = new DateTime(2023, 10, 1) },
                    new LichGiangDay { MaLich = 3, MaGV = 2, TenMonHoc = "Van", NgayGiangDay = new DateTime(2023, 10, 2) },
                    new LichGiangDay { MaLich = 4, MaGV = 2, TenMonHoc = "Ly", NgayGiangDay = new DateTime(2023, 11, 2) },
                    new LichGiangDay { MaLich = 5, MaGV = 3, TenMonHoc = "Ly", NgayGiangDay = new DateTime(2023, 10, 2) },
                    new LichGiangDay { MaLich = 6, MaGV = 3, TenMonHoc = "Văn", NgayGiangDay = new DateTime(2023, 12, 3) }
                );

        }

        }
}
