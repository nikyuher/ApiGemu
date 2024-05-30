using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class prueba18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Imagenes_Juegos_JuegoIdJuego",
                table: "Imagenes",
                column: "JuegoIdJuego",
                principalTable: "Juegos",
                principalColumn: "IdJuego");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Juegos_JuegoIdJuego",
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
        }
    }
}
