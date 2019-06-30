using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations
{
    public partial class Changed_Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "HostName", "Name" },
                values: new object[] { new Guid("fe0024a5-5d18-4b2e-b2eb-59a0f42d1861"), "localhost", "Dev" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("fe0024a5-5d18-4b2e-b2eb-59a0f42d1861"));
        }
    }
}
