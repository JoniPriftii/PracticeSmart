using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class SetForegnKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_Departments_DepartmentsId",
                table: "JobHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_Jobs_JobsId",
                table: "JobHistories");

            migrationBuilder.DropColumn(
                name: "DepartamentsId",
                table: "JobHistories");

            migrationBuilder.AlterColumn<int>(
                name: "JobsId",
                table: "JobHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentsId",
                table: "JobHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_Departments_DepartmentsId",
                table: "JobHistories",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_Jobs_JobsId",
                table: "JobHistories",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_Departments_DepartmentsId",
                table: "JobHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_Jobs_JobsId",
                table: "JobHistories");

            migrationBuilder.AlterColumn<int>(
                name: "JobsId",
                table: "JobHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentsId",
                table: "JobHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentsId",
                table: "JobHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_Departments_DepartmentsId",
                table: "JobHistories",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_Jobs_JobsId",
                table: "JobHistories",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
