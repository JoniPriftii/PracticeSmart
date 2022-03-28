using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Locations_DepartmentsFK",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Countries_LocationsFk",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "LocationsFk",
                table: "Locations",
                newName: "CountriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_LocationsFk",
                table: "Locations",
                newName: "IX_Locations_CountriesId");

            migrationBuilder.RenameColumn(
                name: "DepartmentsFK",
                table: "Departments",
                newName: "LocationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_DepartmentsFK",
                table: "Departments",
                newName: "IX_Departments_LocationsId");

            migrationBuilder.AddColumn<int>(
                name: "RegionsId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_RegionsId",
                table: "Countries",
                column: "RegionsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Countries_CountriesId",
                table: "Locations",
                column: "CountriesId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Regions_RegionsId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Locations_LocationsId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Countries_CountriesId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Countries_RegionsId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "RegionsId",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "CountriesId",
                table: "Locations",
                newName: "LocationsFk");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CountriesId",
                table: "Locations",
                newName: "IX_Locations_LocationsFk");

            migrationBuilder.RenameColumn(
                name: "LocationsId",
                table: "Departments",
                newName: "DepartmentsFK");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_LocationsId",
                table: "Departments",
                newName: "IX_Departments_DepartmentsFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Locations_DepartmentsFK",
                table: "Departments",
                column: "DepartmentsFK",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Countries_LocationsFk",
                table: "Locations",
                column: "LocationsFk",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
