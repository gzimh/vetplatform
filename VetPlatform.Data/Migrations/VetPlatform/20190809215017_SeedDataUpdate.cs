using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations.VetPlatform
{
    public partial class SeedDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("19458668-177c-4ca8-9acb-6cd2da85903f"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("5d1f7f02-c4e8-40c5-acff-2f9fc76868fc"));

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("c324f0cc-a6e5-4434-a24a-802b08ec0a4c"), new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Done", new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("b579f793-dca4-4fac-b600-fc0603b71826"), new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("b579f793-dca4-4fac-b600-fc0603b71826"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("c324f0cc-a6e5-4434-a24a-802b08ec0a4c"));

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("19458668-177c-4ca8-9acb-6cd2da85903f"), new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("5d1f7f02-c4e8-40c5-acff-2f9fc76868fc"), new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });
        }
    }
}
