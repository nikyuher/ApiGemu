using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class nuevoAtributoTransaccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Transacciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Transacciones");
        }
    }
}
