using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class prueba6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SaldoActual",
                table: "Usuarios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaldoActual",
                table: "Usuarios");
        }
    }
}
