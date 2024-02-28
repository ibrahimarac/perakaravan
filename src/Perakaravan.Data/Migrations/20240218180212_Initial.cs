using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Perakaravan.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    RefreshTokenExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LoginUsers",
                columns: new[] { "Id", "CreatedTime", "CreatedUser", "Email", "IsDeleted", "Name", "Password", "Phone", "RefreshToken", "RefreshTokenExpire", "Surname", "UpdatedTime", "UpdatedUser", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 18, 21, 2, 12, 621, DateTimeKind.Unspecified).AddTicks(3686), "admin", "6i1RRb8yv2k93LY76uQYXg==", false, "İsmet Aydın", "oscldUV7cgbn0b8V8HmpyQ==", "YCPrDtNs284S9G5ikUK4fA==", null, null, "YURTSEVER", null, null, "isayyu" },
                    { 2, new DateTime(2024, 2, 18, 21, 2, 12, 621, DateTimeKind.Unspecified).AddTicks(3729), "admin", "YPRqARSJPWq8wMRbcsaVck2Wnq3lgHLvl0z7T+wsoKc=", false, "Halil İbrahim", "PaFmrqp5h+CAYfGVZvjZsw==", "YCPrDtNs284S9G5ikUK4fA==", null, null, "ARAÇ", null, null, "ibrahim" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginUsers");
        }
    }
}
