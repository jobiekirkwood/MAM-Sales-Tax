using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetUpandSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportTaxCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportTaxCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TaxCategoryId = table.Column<int>(type: "int", nullable: false),
                    ImportTaxCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ImportTaxCategories_ImportTaxCategoryId",
                        column: x => x.ImportTaxCategoryId,
                        principalTable: "ImportTaxCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_TaxCategories_TaxCategoryId",
                        column: x => x.TaxCategoryId,
                        principalTable: "TaxCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ImportTaxCategories",
                columns: new[] { "Id", "Name", "Rate" },
                values: new object[,]
                {
                    { 1, "Uncategorised0", 0.0 },
                    { 2, "Uncategorised5", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "TaxCategories",
                columns: new[] { "Id", "Name", "Rate" },
                values: new object[,]
                {
                    { 1, "Uncategorised0", 0.0 },
                    { 2, "Uncategorised10", 10.0 },
                    { 3, "Books", 0.0 },
                    { 4, "Food", 0.0 },
                    { 5, "Medical", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImportTaxCategoryId", "Name", "Price", "TaxCategoryId" },
                values: new object[,]
                {
                    { 1, 1, "Book", 12.49, 3 },
                    { 2, 1, "Music CD", 14.99, 2 },
                    { 3, 1, "Chocolate Bar", 0.84999999999999998, 4 },
                    { 4, 2, "Imported Box of Chocolates", 10.0, 4 },
                    { 5, 2, "Imported Bottle of Perfume", 47.5, 2 },
                    { 6, 2, "Imported Bottle of Perfume", 27.989999999999998, 2 },
                    { 7, 1, "Bottle of Perfume", 18.989999999999998, 2 },
                    { 8, 1, "Packet of Paracetemol", 9.75, 5 },
                    { 9, 2, "Imported Box of Chocolates", 11.25, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImportTaxCategoryId",
                table: "Products",
                column: "ImportTaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TaxCategoryId",
                table: "Products",
                column: "TaxCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ImportTaxCategories");

            migrationBuilder.DropTable(
                name: "TaxCategories");
        }
    }
}
