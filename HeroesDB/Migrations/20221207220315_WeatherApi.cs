using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesSqlDb.Migrations
{
    /// <inheritdoc />
    public partial class WeatherApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Power",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Weatherboost",
                table: "Heroes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Power",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Weatherboost",
                table: "Heroes");
        }
    }
}
