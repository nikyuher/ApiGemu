using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class newModelsLibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Bibliotecas_IdBiblioteca",
                table: "Juegos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Bibliotecas_IdBiblioteca",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdBiblioteca",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_IdBiblioteca",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "IdBiblioteca",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdBiblioteca",
                table: "Juegos");

            migrationBuilder.CreateTable(
                name: "BibliotecaJuegos",
                columns: table => new
                {
                    BibliotecaJuegoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BibliotecaId = table.Column<int>(type: "int", nullable: false),
                    JuegoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibliotecaJuegos", x => x.BibliotecaJuegoId);
                    table.ForeignKey(
                        name: "FK_BibliotecaJuegos_Bibliotecas_BibliotecaId",
                        column: x => x.BibliotecaId,
                        principalTable: "Bibliotecas",
                        principalColumn: "IdBiblioteca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BibliotecaJuegos_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "IdJuego",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BibliotecaProductos",
                columns: table => new
                {
                    BibliotecaProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BibliotecaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibliotecaProductos", x => x.BibliotecaProductoId);
                    table.ForeignKey(
                        name: "FK_BibliotecaProductos_Bibliotecas_BibliotecaId",
                        column: x => x.BibliotecaId,
                        principalTable: "Bibliotecas",
                        principalColumn: "IdBiblioteca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BibliotecaProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BibliotecaJuegos_BibliotecaId",
                table: "BibliotecaJuegos",
                column: "BibliotecaId");

            migrationBuilder.CreateIndex(
                name: "IX_BibliotecaJuegos_JuegoId",
                table: "BibliotecaJuegos",
                column: "JuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_BibliotecaProductos_BibliotecaId",
                table: "BibliotecaProductos",
                column: "BibliotecaId");

            migrationBuilder.CreateIndex(
                name: "IX_BibliotecaProductos_ProductoId",
                table: "BibliotecaProductos",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BibliotecaJuegos");

            migrationBuilder.DropTable(
                name: "BibliotecaProductos");

            migrationBuilder.AddColumn<int>(
                name: "IdBiblioteca",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdBiblioteca",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdBiblioteca",
                table: "Productos",
                column: "IdBiblioteca");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_IdBiblioteca",
                table: "Juegos",
                column: "IdBiblioteca");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Bibliotecas_IdBiblioteca",
                table: "Juegos",
                column: "IdBiblioteca",
                principalTable: "Bibliotecas",
                principalColumn: "IdBiblioteca");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Bibliotecas_IdBiblioteca",
                table: "Productos",
                column: "IdBiblioteca",
                principalTable: "Bibliotecas",
                principalColumn: "IdBiblioteca");
        }
    }
}
