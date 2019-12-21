using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBoardWebApp.Migrations
{
    public partial class ProjectsModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectLongDesc",
                table: "Project",
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectLongDesc",
                table: "Project");
        }
    }
}
