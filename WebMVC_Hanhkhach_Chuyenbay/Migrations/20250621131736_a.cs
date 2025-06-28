using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVC_Hanhkhach_Chuyenbay.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HanhKhach",
                columns: table => new
                {
                    MaHanhKhach = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoCMND = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HanhKhach", x => x.MaHanhKhach);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenBay",
                columns: table => new
                {
                    MaChuyenBay = table.Column<int>(type: "int", nullable: false),
                    MaHanhKhach = table.Column<int>(type: "int", nullable: false),
                    NgayBay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiaVe = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenBay", x => x.MaChuyenBay);
                    table.ForeignKey(
                        name: "FK_ChuyenBay_HanhKhach_MaHanhKhach",
                        column: x => x.MaHanhKhach,
                        principalTable: "HanhKhach",
                        principalColumn: "MaHanhKhach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HanhKhach",
                columns: new[] { "MaHanhKhach", "HoTen", "NoiDen", "SoCMND", "SoDT" },
                values: new object[] { 1, "Nguyen Van A", "Hanoi", "123456789", "0987654321" });

            migrationBuilder.InsertData(
                table: "HanhKhach",
                columns: new[] { "MaHanhKhach", "HoTen", "NoiDen", "SoCMND", "SoDT" },
                values: new object[] { 2, "Tran Thi B", "Ho Chi Minh City", "987654321", "0123456789" });

            migrationBuilder.InsertData(
                table: "HanhKhach",
                columns: new[] { "MaHanhKhach", "HoTen", "NoiDen", "SoCMND", "SoDT" },
                values: new object[] { 3, "Le Van C", "Da Nang", "456789123", "1234567890" });

            migrationBuilder.InsertData(
                table: "ChuyenBay",
                columns: new[] { "MaChuyenBay", "GiaVe", "MaHanhKhach", "NgayBay" },
                values: new object[,]
                {
                    { 1, 1000000m, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1500000m, 2, new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2000000m, 3, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1000000m, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1500000m, 2, new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2000000m, 3, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenBay_MaHanhKhach",
                table: "ChuyenBay",
                column: "MaHanhKhach");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChuyenBay");

            migrationBuilder.DropTable(
                name: "HanhKhach");
        }
    }
}
