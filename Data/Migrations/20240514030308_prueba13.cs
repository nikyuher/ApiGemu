using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class prueba13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Productos_ProductoId",
                table: "Imagenes");

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
                name: "FK_Imagenes_Productos_ProductoId",
                table: "Imagenes");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Productos_ProductoId",
                table: "Imagenes",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "IdProducto");
        }
    }
}
