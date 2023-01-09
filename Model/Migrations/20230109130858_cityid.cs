using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class cityid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_cities_CityName",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_CityName",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "locations");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "locations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "cities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_locations_CityId",
                table: "locations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_locations_cities_CityId",
                table: "locations",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_cities_CityId",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_CityId",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "cities");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "locations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "cities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_locations_CityName",
                table: "locations",
                column: "CityName");

            migrationBuilder.AddForeignKey(
                name: "FK_locations_cities_CityName",
                table: "locations",
                column: "CityName",
                principalTable: "cities",
                principalColumn: "Name");
        }
    }
}
