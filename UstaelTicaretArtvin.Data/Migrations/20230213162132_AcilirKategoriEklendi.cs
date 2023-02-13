using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UstaelTicaretArtvin.Data.Migrations
{
    /// <inheritdoc />
    public partial class AcilirKategoriEklendi : Migration
    {
        /// <inheritdoc />  
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTopMenu",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 2, 13, 19, 21, 31, 931, DateTimeKind.Local).AddTicks(1837));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTopMenu",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 2, 7, 14, 54, 40, 178, DateTimeKind.Local).AddTicks(3507));
        }
    }
}
