using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBoardWebApp.Migrations.WorkTaskDb
{
    public partial class CreateWorkTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkTask",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(nullable: false),
                    ParentTask = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false),
                    AssignedID = table.Column<string>(nullable: true),
                    TaskDesc = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false),
                    HoursEstimated = table.Column<float>(nullable: false),
                    HoursUsed = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTask", x => x.TaskID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkTask");
        }
    }
}
