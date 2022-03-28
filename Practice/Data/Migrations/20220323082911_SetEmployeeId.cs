using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class SetEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_AspNetUsers_EmployeesId",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_EmployeesId",
                table: "JobHistories");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "JobHistories");

            migrationBuilder.AlterColumn<string>(
                name: "EmplyeesId",
                table: "JobHistories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_EmplyeesId",
                table: "JobHistories",
                column: "EmplyeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_AspNetUsers_EmplyeesId",
                table: "JobHistories",
                column: "EmplyeesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_AspNetUsers_EmplyeesId",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_EmplyeesId",
                table: "JobHistories");

            migrationBuilder.AlterColumn<int>(
                name: "EmplyeesId",
                table: "JobHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeesId",
                table: "JobHistories",
                type: "nvarchar(450)",
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
    }
}
