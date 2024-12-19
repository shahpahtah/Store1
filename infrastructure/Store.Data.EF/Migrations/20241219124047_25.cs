using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class _25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "characteristic",
                value: "состав : хлопок 80%\n полиэстер: 20%\r\nоттенок: чёрный принт графика\r\nпокрой: прямой\r\nдлина: средний\r\nлиния: Befree Young\n");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "characteristic",
                value: "состав: хлопок 100%\r\nоттенок: небесно-голубой\r\nпокрой: прямой\r\nдлина: средний\r\nвырез: nкруглый\r\nлиния: Befree Young\n");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "characteristic",
                value: "состав: акрил 80%, полиэстер 20% \r\nоттенок: nмультиколор\r\nпокрой: свободный\r\nвырез: круглый\r\nлиния: Befree Young \n");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "characteristic",
                value: "состав: полиэстер 94%, эластан 6%\r\nоттенок: серебро\r\nтип платья: с тонкими бретельками\r\nдлина платья: миди\r\nвырез: на бретелях\r\nрукава: без рукавов\r\nталия: средняя");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "characteristic",
                value: "состав: основной материал: полиэстер 100%\r\nоттенок: черный\r\nпосадка: средняя\r\nмодель юбки: oблегающая\r\nдлина юбки: мини\r\nвид застежки: молния");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "characteristic",
                value: "состав:основной материал: полиэстер 100%; подкладка: полиэстер 100%\r\nоттенок:черный\r\nпокрой:оверсайз");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "characteristic",
                value: "sss");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "characteristic",
                value: "sss");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "characteristic",
                value: "sss");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "characteristic",
                value: "sss");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "characteristic",
                value: "sss");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "characteristic",
                value: "sss");
        }
    }
}
