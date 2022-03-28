using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class SetEmployeeId0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentsId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentsId",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "JobHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentsId = table.Column<int>(type: "int", nullable: true),
                    EmplyeesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobsId = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobHistories_AspNetUsers_EmplyeesId",
                        column: x => x.EmplyeesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobHistories_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobHistories_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentsId",
                table: "AspNetUsers",
                column: "DepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_DepartmentsId",
                table: "JobHistories",
                column: "DepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_EmplyeesId",
                table: "JobHistories",
                column: "EmplyeesId");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_JobsId",
                table: "JobHistories",
                column: "JobsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentsId",
                table: "AspNetUsers",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
