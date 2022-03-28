using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartamentsId = table.Column<int>(type: "int", nullable: false),
                    DepartmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobHistories_AspNetUsers_EmployeesId1",
                        column: x => x.EmployeesId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobHistories_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobHistories_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_DepartmentsId",
                table: "JobHistories",
                column: "DepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_EmployeesId1",
                table: "JobHistories",
                column: "EmployeesId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_JobsId",
                table: "JobHistories",
                column: "JobsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobHistories");
        }
    }
}
