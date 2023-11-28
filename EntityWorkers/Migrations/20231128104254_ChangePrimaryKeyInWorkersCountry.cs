using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityWorkers.Migrations
{
    /// <inheritdoc />
    public partial class ChangePrimaryKeyInWorkersCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkersCountries_CountryId",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkersCountries",
                table: "WorkersCountries");

            migrationBuilder.DropIndex(
                name: "IX_Workers_CountryId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WorkersCountries");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Workers");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "WorkersCountries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "WorkersCountryCountry",
                table: "Workers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkersCountries",
                table: "WorkersCountries",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkersCountryCountry",
                table: "Workers",
                column: "WorkersCountryCountry");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_WorkersCountries_WorkersCountryCountry",
                table: "Workers",
                column: "WorkersCountryCountry",
                principalTable: "WorkersCountries",
                principalColumn: "Country",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkersCountries_WorkersCountryCountry",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkersCountries",
                table: "WorkersCountries");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WorkersCountryCountry",
                table: "Workers");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "WorkersCountries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WorkersCountries",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "WorkersCountryCountry",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkersCountries",
                table: "WorkersCountries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CountryId",
                table: "Workers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_WorkersCountries_CountryId",
                table: "Workers",
                column: "CountryId",
                principalTable: "WorkersCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
