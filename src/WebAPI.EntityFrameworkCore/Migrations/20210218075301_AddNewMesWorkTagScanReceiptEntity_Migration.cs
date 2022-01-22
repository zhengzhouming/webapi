using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddNewMesWorkTagScanReceiptEntity_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MesWorkTagScanReceipts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Version = table.Column<string>(nullable: true),
                    tagScanAccount = table.Column<string>(nullable: true),
                    tagScanDeptID = table.Column<int>(nullable: false),
                    tagScanDateTime = table.Column<string>(nullable: true),
                    tagScanPDASerial = table.Column<string>(nullable: true),
                    tagScanPDAUUID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesWorkTagScanReceipts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MesWorkTagScanReceipts");
        }
    }
}
