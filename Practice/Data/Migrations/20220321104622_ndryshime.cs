using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Data.Migrations
{
    public partial class ndryshime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Countries_CountriesFK",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_CountriesFK",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "CountriesFK",
                table: "Regions");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CountriesFK",
                table: "Regions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountriesFK",
                table: "Regions",
                column: "CountriesFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Countries_CountriesFK",
                table: "Regions",
                column: "CountriesFK",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
