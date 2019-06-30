using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations.VetPlatform
{
    public partial class initial_create_vp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    Schedule = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "TenantId" },
                values: new object[] { new Guid("789c6fde-5928-4272-bb40-2ef19dc3443a"), new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "TenantId" },
                values: new object[] { new Guid("8a2402c3-fb29-4a72-9435-4b07794694e5"), new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("85029b8d-86f1-4c81-befc-a832819ad557") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
