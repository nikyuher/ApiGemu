using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class correcionCreacionAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bibliotecas",
                columns: new[] { "IdBiblioteca", "IdUsuario" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Carritos",
                columns: new[] { "IdCarrito", "IdUsuario" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bibliotecas",
                keyColumn: "IdBiblioteca",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carritos",
                keyColumn: "IdCarrito",
                keyValue: 1);
        }
    }
}
