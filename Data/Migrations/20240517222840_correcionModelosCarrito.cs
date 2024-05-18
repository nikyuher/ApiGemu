using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class correcionModelosCarrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarritoProducto",
                table: "CarritoProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarritoJuego",
                table: "CarritoJuego");

            migrationBuilder.AddColumn<int>(
                name: "CarritoProductoId",
                table: "CarritoProducto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CarritoJuegoId",
                table: "CarritoJuego",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarritoProducto",
                table: "CarritoProducto",
                column: "CarritoProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarritoJuego",
                table: "CarritoJuego",
                column: "CarritoJuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProducto_CarritoId",
                table: "CarritoProducto",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoJuego_CarritoId",
                table: "CarritoJuego",
                column: "CarritoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarritoProducto",
                table: "CarritoProducto");

            migrationBuilder.DropIndex(
                name: "IX_CarritoProducto_CarritoId",
                table: "CarritoProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarritoJuego",
                table: "CarritoJuego");

            migrationBuilder.DropIndex(
                name: "IX_CarritoJuego_CarritoId",
                table: "CarritoJuego");

            migrationBuilder.DropColumn(
                name: "CarritoProductoId",
                table: "CarritoProducto");

            migrationBuilder.DropColumn(
                name: "CarritoJuegoId",
                table: "CarritoJuego");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarritoProducto",
                table: "CarritoProducto",
                columns: new[] { "CarritoId", "ProductoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarritoJuego",
                table: "CarritoJuego",
                columns: new[] { "CarritoId", "JuegoId" });
        }
    }
}
