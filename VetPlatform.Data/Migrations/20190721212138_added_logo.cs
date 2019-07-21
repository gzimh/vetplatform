using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations
{
    public partial class added_logo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Tenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Tenants");
        }
    }
}
