using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinForm_Khambenh.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoSoKhamBenhs",
                columns: table => new
                {
                    MaHoSo = table.Column<int>(type: "int", nullable: false),
                    KhoaKham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaBenhNhan = table.Column<int>(type: "int", nullable: false),
                    NgayKham = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoaiBenh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapCuu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoKhamBenhs", x => x.MaHoSo);
                });

            migrationBuilder.InsertData(
                table: "HoSoKhamBenhs",
                columns: new[] { "MaHoSo", "CapCuu", "KhoaKham", "LoaiBenh", "MaBenhNhan", "NgayKham" },
                values: new object[] { 1, false, "Nội tổng quát", "Cảm cúm", 101, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "HoSoKhamBenhs",
                columns: new[] { "MaHoSo", "CapCuu", "KhoaKham", "LoaiBenh", "MaBenhNhan", "NgayKham" },
                values: new object[] { 2, true, "Ngoại chấn thương", "Gãy tay", 102, new DateTime(2025, 6, 21, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "HoSoKhamBenhs",
                columns: new[] { "MaHoSo", "CapCuu", "KhoaKham", "LoaiBenh", "MaBenhNhan", "NgayKham" },
                values: new object[] { 3, false, "Tai mũi họng", "Viêm họng", 103, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoSoKhamBenhs");
        }
    }
}
