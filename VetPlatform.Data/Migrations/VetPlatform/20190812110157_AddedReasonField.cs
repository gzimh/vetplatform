using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations.VetPlatform
{
    public partial class AddedReasonField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("b579f793-dca4-4fac-b600-fc0603b71826"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("c324f0cc-a6e5-4434-a24a-802b08ec0a4c"));

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Bookings",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Reason", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("9946c7ce-8e3b-434a-94ed-b916d66d498a"), null, new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Done", new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Reason", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("a6f13cd5-bca9-4a99-9bb8-29cdee6fc605"), null, new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("9946c7ce-8e3b-434a-94ed-b916d66d498a"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("a6f13cd5-bca9-4a99-9bb8-29cdee6fc605"));

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("c324f0cc-a6e5-4434-a24a-802b08ec0a4c"), new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Done", new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("b579f793-dca4-4fac-b600-fc0603b71826"), new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });
        }
    }
}
