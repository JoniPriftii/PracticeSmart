using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class SetForegnKey1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_AspNetUsers_EmployeesId1",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_EmployeesId1",
                table: "JobHistories");

            migrationBuilder.DropColumn(
                name: "EmployeesId1",
                table: "JobHistories");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeesId",
                table: "JobHistories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmplyeesId",
                table: "JobHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_EmployeesId",
                table: "JobHistories",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_AspNetUsers_EmployeesId",
                table: "JobHistories",
                column: "EmployeesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_AspNetUsers_EmployeesId",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_EmployeesId",
                table: "JobHistories");

            migrationBuilder.DropColumn(
                name: "EmplyeesId",
                table: "JobHistories");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeesId",
                table: "JobHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeesId1",
                table: "JobHistories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_EmployeesId1",
                table: "JobHistories",
                column: "EmployeesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_AspNetUsers_EmployeesId1",
                table: "JobHistories",
                column: "EmployeesId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
