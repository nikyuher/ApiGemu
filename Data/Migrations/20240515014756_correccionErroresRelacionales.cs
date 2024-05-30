using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class correccionErroresRelacionales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Juegos_IdJuego",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Productos_IdProducto",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Categorias_CategoriaIdCategoria",
                table: "Juegos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaIdCategoria",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoriaIdCategoria",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_CategoriaIdCategoria",
                table: "Juegos");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_IdJuego",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_IdProducto",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "IdJuego",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "Categorias");

            migrationBuilder.CreateTable(
                name: "juegoCategorias",
                columns: table => new
                {
                    JuegoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_juegoCategorias", x => new { x.JuegoId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_juegoCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_juegoCategorias_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "IdJuego",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoCategorias",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCategorias", x => new { x.ProductoId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_ProductoCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoCategorias_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_juegoCategorias_CategoriaId",
                table: "juegoCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCategorias_CategoriaId",
                table: "ProductoCategorias",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "juegoCategorias");

            migrationBuilder.DropTable(
                name: "ProductoCategorias");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdJuego",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaIdCategoria",
                table: "Productos",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_CategoriaIdCategoria",
                table: "Juegos",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdJuego",
                table: "Categorias",
                column: "IdJuego");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdProducto",
                table: "Categorias",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Juegos_IdJuego",
                table: "Categorias",
                column: "IdJuego",
                principalTable: "Juegos",
                principalColumn: "IdJuego");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Productos_IdProducto",
                table: "Categorias",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Categorias_CategoriaIdCategoria",
                table: "Juegos",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaIdCategoria",
                table: "Productos",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria");
        }
    }
}
