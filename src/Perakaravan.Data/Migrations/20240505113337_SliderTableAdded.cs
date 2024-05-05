using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perakaravan.Data.Migrations
{
    /// <inheritdoc />
    public partial class SliderTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "LoginUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 5, 14, 33, 35, 760, DateTimeKind.Unspecified).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "LoginUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 5, 14, 33, 35, 760, DateTimeKind.Unspecified).AddTicks(8778));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.UpdateData(
                table: "LoginUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 2, 18, 21, 2, 12, 621, DateTimeKind.Unspecified).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "LoginUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 2, 18, 21, 2, 12, 621, DateTimeKind.Unspecified).AddTicks(3729));
        }
    }
}
