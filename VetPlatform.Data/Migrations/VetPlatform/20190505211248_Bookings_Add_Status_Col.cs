using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations.VetPlatform
{
    public partial class Bookings_Add_Status_Col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("789c6fde-5928-4272-bb40-2ef19dc3443a"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("8a2402c3-fb29-4a72-9435-4b07794694e5"));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Bookings",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("e7e00907-9e9d-4eaf-ba8e-76f0057240db"), new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("430c6f82-f06a-46de-9c2f-2dfd13bf4acd"), new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("85029b8d-86f1-4c81-befc-a832819ad557") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("430c6f82-f06a-46de-9c2f-2dfd13bf4acd"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("e7e00907-9e9d-4eaf-ba8e-76f0057240db"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "TenantId" },
                values: new object[] { new Guid("789c6fde-5928-4272-bb40-2ef19dc3443a"), new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "TenantId" },
                values: new object[] { new Guid("8a2402c3-fb29-4a72-9435-4b07794694e5"), new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("85029b8d-86f1-4c81-befc-a832819ad557") });
        }
    }
}
