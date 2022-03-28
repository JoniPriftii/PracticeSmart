using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class SetForegnKey3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Regions_RegionsId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Locations_LocationsId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "department_name",
                table: "Departments",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "LocationsId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EmplyeesId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "RegionsId",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Regions_RegionsId",
                table: "Countries",
                column: "RegionsId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Locations_LocationsId",
                table: "Departments",
                column: "LocationsId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Regions_RegionsId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Locations_LocationsId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "EmplyeesId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "department_name");

            migrationBuilder.AlterColumn<int>(
                name: "LocationsId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RegionsId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Regions_RegionsId",
                table: "Countries",
                column: "RegionsId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Locations_LocationsId",
                table: "Departments",
                column: "LocationsId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
