using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class prueba16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Juegos_JuegoId",
                table: "Imagenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Juegos_JuegoIdJuego",
                table: "Imagenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Productos_ProductoId",
                table: "Imagenes");

            migrationBuilder.DropIndex(
                name: "IX_Imagenes_JuegoIdJuego",
                table: "Imagenes");

            migrationBuilder.DropColumn(
                name: "IdImagen",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "JuegoIdJuego",
                table: "Imagenes");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Juegos_JuegoId",
                table: "Imagenes",
                column: "JuegoId",
                principalTable: "Juegos",
                principalColumn: "IdJuego",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Productos_ProductoId",
                table: "Imagenes",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Juegos_JuegoId",
                table: "Imagenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Productos_ProductoId",
                table: "Imagenes");

            migrationBuilder.AddColumn<int>(
                name: "IdImagen",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JuegoIdJuego",
                table: "Imagenes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_JuegoIdJuego",
                table: "Imagenes",
                column: "JuegoIdJuego",
                unique: true,
                filter: "[JuegoIdJuego] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Juegos_JuegoId",
                table: "Imagenes",
                column: "JuegoId",
                principalTable: "Juegos",
                principalColumn: "IdJuego");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Juegos_JuegoIdJuego",
                table: "Imagenes",
                column: "JuegoIdJuego",
                principalTable: "Juegos",
                principalColumn: "IdJuego");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Productos_ProductoId",
                table: "Imagenes",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "IdProducto");
        }
    }
}
