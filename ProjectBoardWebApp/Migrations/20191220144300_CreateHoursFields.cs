using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBoardWebApp.Migrations
{
    public partial class CreateHoursFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HoursProjected",
                table: "Project",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HoursUsed",
                table: "Project",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursProjected",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "HoursUsed",
                table: "Project");
        }
    }
}
