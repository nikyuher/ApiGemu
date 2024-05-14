using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class FKProductosImagenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdImagen",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoIdProducto",
                table: "Imagenes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_ProductoIdProducto",
                table: "Imagenes",
                column: "ProductoIdProducto",
                unique: true,
                filter: "[ProductoIdProducto] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Productos_ProductoIdProducto",
                table: "Imagenes",
                column: "ProductoIdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Productos_ProductoIdProducto",
                table: "Imagenes");

            migrationBuilder.DropIndex(
                name: "IX_Imagenes_ProductoIdProducto",
                table: "Imagenes");

            migrationBuilder.DropColumn(
                name: "IdImagen",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProductoIdProducto",
                table: "Imagenes");
        }
    }
}
