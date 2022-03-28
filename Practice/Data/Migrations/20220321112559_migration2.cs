using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Commission",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobsId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobsId",
                table: "AspNetUsers",
                column: "JobsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Jobs_JobsId",
                table: "AspNetUsers",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Jobs_JobsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_JobsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Commission",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JobsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "AspNetUsers");
        }
    }
}
