using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class JobTitle1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentsId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentsId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentsId1",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "EmplyeesId",
                table: "Departments",
                newName: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentsId",
                table: "AspNetUsers",
                column: "DepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentsId",
                table: "AspNetUsers",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentsId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Departments",
                newName: "EmplyeesId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentsId1",
                table: "AspNetUsers",
                column: "DepartmentsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentsId1",
                table: "AspNetUsers",
                column: "DepartmentsId1",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
