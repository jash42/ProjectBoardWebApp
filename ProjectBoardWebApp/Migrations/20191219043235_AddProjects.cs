using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBoardWebApp.Migrations
{
    public partial class AddProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(maxLength: 30, nullable: false),
                    ProjectDesc = table.Column<string>(maxLength: 500, nullable: false),
                    ProjectStartDate = table.Column<DateTime>(nullable: false),
                    ProjectStatus = table.Column<string>(maxLength: 25, nullable: true),
                    LeaderID = table.Column<string>(maxLength: 450, nullable: true),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
