using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HostName = table.Column<string>(nullable: true),
                    Theme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "HostName", "Name", "Theme" },
                values: new object[] { new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174"), "pets.vetplatform.local", "Pets Clinic", null });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "HostName", "Name", "Theme" },
                values: new object[] { new Guid("85029b8d-86f1-4c81-befc-a832819ad557"), "meds.vetplatform.local", "Meds Clinic", null });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "HostName", "Name", "Theme" },
                values: new object[] { new Guid("fe0024a5-5d18-4b2e-b2eb-59a0f42d1861"), "localhost", "Dev", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
