using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations.VetPlatform
{
    public partial class Initial : Migration
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
                values: new object[] { new Guid("19458668-177c-4ca8-9acb-6cd2da85903f"), new DateTime(2019, 4, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Schedule", "Status", "TenantId" },
                values: new object[] { new Guid("5d1f7f02-c4e8-40c5-acff-2f9fc76868fc"), new DateTime(2019, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
