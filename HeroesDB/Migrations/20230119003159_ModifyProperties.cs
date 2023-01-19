using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesSqlDb.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Powers = table.Column<int>(type: "int", nullable: false),
                    Weatherboost = table.Column<int>(type: "int", nullable: false),
                    PowerLevel = table.Column<int>(type: "int", nullable: false),
                    IsVillain = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
