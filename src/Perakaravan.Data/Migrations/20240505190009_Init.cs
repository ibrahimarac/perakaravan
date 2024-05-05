using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Perakaravan.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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

            migrationBuilder.CreateTable(
                name: "SiteStatic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "varchar(12)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Address = table.Column<string>(type: "varchar(255)", nullable: false),
                    GoogleMap = table.Column<string>(type: "varchar(50)", nullable: false),
                    Instagram = table.Column<string>(type: "varchar(150)", nullable: false),
                    Facebook = table.Column<string>(type: "varchar(150)", nullable: false),
                    Twitter = table.Column<string>(type: "varchar(150)", nullable: false),
                    HomepageTitle = table.Column<string>(type: "varchar(255)", nullable: false),
                    Footer = table.Column<string>(type: "varchar(255)", nullable: false),
                    Logo = table.Column<string>(type: "varchar(100)", nullable: false),
                    LogoTitle = table.Column<string>(type: "varchar(100)", nullable: false),
                    SmtpUrl = table.Column<string>(type: "varchar(100)", nullable: false),
                    SmtpDisplayName = table.Column<string>(type: "varchar(100)", nullable: false),
                    SmtpPort = table.Column<int>(type: "int", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteStatic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(150)", nullable: false),
                    SubTitle = table.Column<string>(type: "varchar(300)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(150)", nullable: false),
                    RedirectUrl = table.Column<string>(type: "varchar(150)", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LoginUsers",
                columns: new[] { "Id", "CreatedTime", "CreatedUser", "Email", "IsDeleted", "Name", "Password", "Phone", "RefreshToken", "RefreshTokenExpire", "Surname", "UpdatedTime", "UpdatedUser", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 5, 22, 0, 7, 800, DateTimeKind.Unspecified).AddTicks(4792), "admin", "6i1RRb8yv2k93LY76uQYXg==", false, "İsmet Aydın", "oscldUV7cgbn0b8V8HmpyQ==", "YCPrDtNs284S9G5ikUK4fA==", null, null, "YURTSEVER", null, null, "isayyu" },
                    { 2, new DateTime(2024, 5, 5, 22, 0, 7, 800, DateTimeKind.Unspecified).AddTicks(4840), "admin", "YPRqARSJPWq8wMRbcsaVck2Wnq3lgHLvl0z7T+wsoKc=", false, "Halil İbrahim", "PaFmrqp5h+CAYfGVZvjZsw==", "YCPrDtNs284S9G5ikUK4fA==", null, null, "ARAÇ", null, null, "ibrahim" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginUsers");

            migrationBuilder.DropTable(
                name: "SiteStatic");

            migrationBuilder.DropTable(
                name: "Slider");
        }
    }
}
