using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations.Tenant
{
    public partial class SeedDataChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174"),
                column: "Theme",
                value: "#3f51b5");

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("85029b8d-86f1-4c81-befc-a832819ad557"),
                column: "Theme",
                value: "#33691e");

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("fe0024a5-5d18-4b2e-b2eb-59a0f42d1861"),
                column: "Theme",
                value: "#bf360c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174"),
                column: "Theme",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("85029b8d-86f1-4c81-befc-a832819ad557"),
                column: "Theme",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("fe0024a5-5d18-4b2e-b2eb-59a0f42d1861"),
                column: "Theme",
                value: null);
        }
    }
}
