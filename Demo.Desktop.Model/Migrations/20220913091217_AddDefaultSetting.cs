using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Desktop.Model.Migrations
{
    public partial class AddDefaultSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "DemoServerBaseUrl" },
                values: new object[] { new Guid("63973a67-52c8-43a5-a196-457fa16074b6"), "https://localhost:7111/api/" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("63973a67-52c8-43a5-a196-457fa16074b6"));
        }
    }
}
