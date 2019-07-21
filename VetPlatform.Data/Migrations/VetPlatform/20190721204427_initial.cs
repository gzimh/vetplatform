using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations.VetPlatform
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    Schedule = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("1b0c3500-3a46-4655-9b87-2c37ec110b12"), new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("d2fa32c6-a26f-4dd1-80e1-3d3947c8514a"), new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
