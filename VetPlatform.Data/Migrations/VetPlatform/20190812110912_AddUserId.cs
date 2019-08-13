using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations.VetPlatform
{
    public partial class AddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("9946c7ce-8e3b-434a-94ed-b916d66d498a"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("a6f13cd5-bca9-4a99-9bb8-29cdee6fc605"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Reason", "Schedule", "Status", "TenantId", "UserId" },
                values: new object[] { new Guid("7f35a503-971e-4a34-ac73-039aa9e870eb"), null, new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Done", new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174"), null });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Reason", "Schedule", "Status", "TenantId", "UserId" },
                values: new object[] { new Guid("07a8efa1-13e6-4b57-94b6-51c4fd812456"), null, new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174"), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("07a8efa1-13e6-4b57-94b6-51c4fd812456"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("7f35a503-971e-4a34-ac73-039aa9e870eb"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Reason", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("9946c7ce-8e3b-434a-94ed-b916d66d498a"), null, new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Done", new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Reason", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("a6f13cd5-bca9-4a99-9bb8-29cdee6fc605"), null, new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });
        }
    }
}
