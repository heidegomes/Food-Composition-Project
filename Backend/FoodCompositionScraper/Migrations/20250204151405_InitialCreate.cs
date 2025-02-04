using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodCompositionScraper.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ScientificName = table.Column<string>(type: "TEXT", nullable: false),
                    Group = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "FoodDataComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FoodCode = table.Column<string>(type: "TEXT", nullable: false),
                    Component = table.Column<string>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    ValuePer100g = table.Column<string>(type: "TEXT", nullable: false),
                    StandardDeviation = table.Column<string>(type: "TEXT", nullable: false),
                    MinimumValue = table.Column<string>(type: "TEXT", nullable: false),
                    MaximumValue = table.Column<string>(type: "TEXT", nullable: false),
                    NumberSamples = table.Column<string>(type: "TEXT", nullable: false),
                    Reference = table.Column<string>(type: "TEXT", nullable: false),
                    DataType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDataComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDataComponent_Foods_FoodCode",
                        column: x => x.FoodCode,
                        principalTable: "Foods",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodDataComponent_FoodCode",
                table: "FoodDataComponent",
                column: "FoodCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodDataComponent");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
