using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class agregandoNuevoModeloCarProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Carritos_IdCarrito",
                table: "Juegos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Carritos_IdCarrito",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdCarrito",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_IdCarrito",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "IdCarrito",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdCarrito",
                table: "Juegos");

            migrationBuilder.CreateTable(
                name: "CarritoJuego",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    JuegoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoJuego", x => new { x.CarritoId, x.JuegoId });
                    table.ForeignKey(
                        name: "FK_CarritoJuego_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "IdCarrito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoJuego_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "IdJuego",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoProducto",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoProducto", x => new { x.CarritoId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "IdCarrito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoJuego_JuegoId",
                table: "CarritoJuego",
                column: "JuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProducto_ProductoId",
                table: "CarritoProducto",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoJuego");

            migrationBuilder.DropTable(
                name: "CarritoProducto");

            migrationBuilder.AddColumn<int>(
                name: "IdCarrito",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCarrito",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCarrito",
                table: "Productos",
                column: "IdCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_IdCarrito",
                table: "Juegos",
                column: "IdCarrito");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Carritos_IdCarrito",
                table: "Juegos",
                column: "IdCarrito",
                principalTable: "Carritos",
                principalColumn: "IdCarrito");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Carritos_IdCarrito",
                table: "Productos",
                column: "IdCarrito",
                principalTable: "Carritos",
                principalColumn: "IdCarrito");
        }
    }
}
