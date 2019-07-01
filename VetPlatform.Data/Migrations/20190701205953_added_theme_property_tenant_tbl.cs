using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPlatform.Data.Migrations
{
    public partial class added_theme_property_tenant_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Tenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Tenants");
        }
    }
}
