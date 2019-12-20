using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBoardWebApp.Migrations.OrgDb
{
    public partial class InitialOrganizaions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrgID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    OrgName = table.Column<string>(maxLength: 75, nullable: false),
                    OrgAddress = table.Column<string>(maxLength: 100, nullable: false),
                    OrgAddress2 = table.Column<string>(maxLength: 100, nullable: true),
                    OrgCity = table.Column<string>(maxLength: 40, nullable: false),
                    OrgState = table.Column<string>(maxLength: 2, nullable: false),
                    OrgZip = table.Column<string>(maxLength: 30, nullable: false),
                    OrgPhone = table.Column<string>(maxLength: 30, nullable: false),
                    OrgWebsite = table.Column<string>(maxLength: 250, nullable: true),
                    MainContact = table.Column<string>(maxLength: 450, nullable: true),
                    StagingUrl = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrgID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
