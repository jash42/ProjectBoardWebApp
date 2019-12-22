using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBoardWebApp.Migrations.WorkTaskDb
{
    public partial class AddTaskName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskName",
                table: "WorkTask",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskName",
                table: "WorkTask");
        }
    }
}
