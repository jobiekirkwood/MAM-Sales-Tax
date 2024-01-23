using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAM_Sales_Tax.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDoublesToDecimalType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "TaxCategories",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "ImportTaxCategories",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "ImportTaxCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rate",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "ImportTaxCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rate",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 12.49m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 14.99m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 0.85m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 10.00m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 47.50m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 27.99m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 18.99m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 9.75m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 11.25m);

            migrationBuilder.UpdateData(
                table: "TaxCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rate",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "TaxCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rate",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "TaxCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rate",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "TaxCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rate",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "TaxCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rate",
                value: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "TaxCategories",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "ImportTaxCategories",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "ImportTaxCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rate",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "ImportTaxCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rate",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 12.49);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 14.99);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 0.84999999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 47.5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 27.989999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 18.989999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 9.75);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 11.25);

            migrationBuilder.UpdateData(
                table: "TaxCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rate",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "TaxCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rate",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "TaxCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rate",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "TaxCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rate",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "TaxCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rate",
                value: 0.0);
        }
    }
}
