using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class creacionCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Icono", "Nombre", "Seccion" },
                values: new object[,]
                {
                    { 1, "mdi-ghost", "Terror", "juegos" },
                    { 2, "mdi-sword", "Aventura", "juegos" },
                    { 3, "mdi-pistol", "FPS", "juegos" },
                    { 4, "mdi-karate", "Accion", "juegos" },
                    { 5, "mdi-island-variant", "Mundo Abierto", "juegos" },
                    { 6, "mdi-car-sports", "Carrera", "juegos" },
                    { 7, "mdi-chess-pawn", "Estrategia", "juegos" },
                    { 8, "mdi-microsoft-xbox-controller", "Multijugador", "juegos" },
                    { 9, "mdi-account", "Un jugador", "juegos" },
                    { 10, "mdi-castle", "RPG", "juegos" },
                    { 11, "mdi-kabaddi", "Lucha", "juegos" },
                    { 12, null, "Juegos de Consola", "marketplace" },
                    { 13, null, "Consolas", "marketplace" },
                    { 14, null, "Accesorio", "marketplace" },
                    { 15, null, "Componentes", "marketplace" },
                    { 16, null, "Portatiles", "marketplace" },
                    { 17, "mdi-monitor", "PC", "plataforma" },
                    { 18, "mdi-sony-playstation", "Ps5", "plataforma" },
                    { 19, "mdi-microsoft-xbox", "Xbox", "plataforma" },
                    { 20, "mdi-nintendo-switch", "Nintendo", "plataforma" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 20);
        }
    }
}
