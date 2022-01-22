using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddNewMesWorkTagScanEntity_Migration226 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tagLine",
                table: "MesWorkTagScans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tagOrg",
                table: "MesWorkTagScans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tagLine",
                table: "MesWorkTagScans");

            migrationBuilder.DropColumn(
                name: "tagOrg",
                table: "MesWorkTagScans");
        }
    }
}
