using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddNewMesWorkTagScanEntity_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "MesWorkTagScans",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tagInvoice = table.Column<string>(nullable: true),
                    tagInvoiceVersion = table.Column<int>(nullable: false),
                    tagReceiptNumber = table.Column<string>(nullable: true),
                    tagLocation = table.Column<string>(nullable: true),
                    tagNumber = table.Column<string>(nullable: true),
                    tagScanAccount = table.Column<string>(nullable: true),
                    tagScanDeptID = table.Column<int>(nullable: false),
                    tagScanDateTime = table.Column<string>(nullable: true),
                    tagUploadDateTime = table.Column<string>(nullable: true),
                    tagScanPDASerial = table.Column<string>(nullable: true),
                    tagScanPDAUUID = table.Column<string>(nullable: true),
                    isInOrOut = table.Column<int>(nullable: false),
                    tagStyle = table.Column<string>(nullable: true),
                    tagColor = table.Column<string>(nullable: true),
                    tagSize = table.Column<string>(nullable: true),
                    tagQty = table.Column<int>(nullable: false),
                    isUploaded = table.Column<int>(nullable: false),
                    isSyncMesData = table.Column<int>(nullable: false),
                    isPrints = table.Column<int>(nullable: false),
                    isDels = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesWorkTagScans", x => x.Id);
                });

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "MesWorkTagScans");
           
        }
    }
}
