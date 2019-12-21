using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBoardWebApp.Data.Migrations
{
    public partial class MoreUserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrgID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "userLocation",
                table: "AspNetUsers",
                maxLength: 25,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrgID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userLocation",
                table: "AspNetUsers");
        }
    }
}
