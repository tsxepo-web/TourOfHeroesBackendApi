using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesDB.Migrations
{
    /// <inheritdoc />
    public partial class AddIsVillainColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsHero",
                table: "Heroes",
                newName: "IsVillain");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsVillain",
                table: "Heroes",
                newName: "IsHero");
        }
    }
}
