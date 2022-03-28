using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ManagerId1",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ManagerId1",
                table: "AspNetUsers",
                newName: "ManagersId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ManagerId1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ManagersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ManagersId",
                table: "AspNetUsers",
                column: "ManagersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ManagersId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ManagersId",
                table: "AspNetUsers",
                newName: "ManagerId1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ManagersId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ManagerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ManagerId1",
                table: "AspNetUsers",
                column: "ManagerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
