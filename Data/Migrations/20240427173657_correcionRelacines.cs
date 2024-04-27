using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class correcionRelacines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Productos_ProductoIdProducto",
                table: "Anuncios");

            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Usuarios_UsuarioIdUsuario",
                table: "Anuncios");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecas_Productos_ProductosIdProducto",
                table: "Bibliotecas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecas_Usuarios_UsuarioIdUsuario",
                table: "Bibliotecas");

            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Productos_ProductosIdProducto",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioIdUsuario",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reseñas_Juegos_JuegoIdJuego",
                table: "Reseñas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reseñas_Usuarios_UsuarioIdUsuario",
                table: "Reseñas");

            migrationBuilder.DropIndex(
                name: "IX_Reseñas_JuegoIdJuego",
                table: "Reseñas");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_ProductosIdProducto",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_UsuarioIdUsuario",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotecas_ProductosIdProducto",
                table: "Bibliotecas");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotecas_UsuarioIdUsuario",
                table: "Bibliotecas");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_ProductoIdProducto",
                table: "Anuncios");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_UsuarioIdUsuario",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "JuegoIdJuego",
                table: "Reseñas");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "ProductosIdProducto",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "Bibliotecas");

            migrationBuilder.DropColumn(
                name: "ProductosIdProducto",
                table: "Bibliotecas");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Bibliotecas");

            migrationBuilder.DropColumn(
                name: "ProductoIdProducto",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Anuncios");

            migrationBuilder.RenameColumn(
                name: "UsuarioIdUsuario",
                table: "Reseñas",
                newName: "IdJuego");

            migrationBuilder.RenameIndex(
                name: "IX_Reseñas_UsuarioIdUsuario",
                table: "Reseñas",
                newName: "IX_Reseñas_IdJuego");

            migrationBuilder.AlterColumn<int>(
                name: "IdProducto",
                table: "Reseñas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAnuncio",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdBiblioteca",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCarrito",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdReseña",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReseñaIdReseña",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoJuego",
                table: "Juegos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdBiblioteca",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCarrito",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdImagen",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdReseña",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReseñaIdReseña",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JuegoIdJuego",
                table: "Imagenes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdJuego = table.Column<int>(type: "int", nullable: true),
                    IdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_Categorias_Juegos_IdJuego",
                        column: x => x.IdJuego,
                        principalTable: "Juegos",
                        principalColumn: "IdJuego");
                    table.ForeignKey(
                        name: "FK_Categorias_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_IdProducto",
                table: "Reseñas",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_IdUsuario",
                table: "Reseñas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaIdCategoria",
                table: "Productos",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdBiblioteca",
                table: "Productos",
                column: "IdBiblioteca");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCarrito",
                table: "Productos",
                column: "IdCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ReseñaIdReseña",
                table: "Productos",
                column: "ReseñaIdReseña");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_CategoriaIdCategoria",
                table: "Juegos",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_IdBiblioteca",
                table: "Juegos",
                column: "IdBiblioteca");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_IdCarrito",
                table: "Juegos",
                column: "IdCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_ReseñaIdReseña",
                table: "Juegos",
                column: "ReseñaIdReseña");

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_JuegoIdJuego",
                table: "Imagenes",
                column: "JuegoIdJuego",
                unique: true,
                filter: "[JuegoIdJuego] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdUsuario",
                table: "Carritos",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecas_IdUsuario",
                table: "Bibliotecas",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_IdProducto",
                table: "Anuncios",
                column: "IdProducto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_IdUsuario",
                table: "Anuncios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdJuego",
                table: "Categorias",
                column: "IdJuego");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdProducto",
                table: "Categorias",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Productos_IdProducto",
                table: "Anuncios",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Usuarios_IdUsuario",
                table: "Anuncios",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotecas_Usuarios_IdUsuario",
                table: "Bibliotecas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Usuarios_IdUsuario",
                table: "Carritos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Juegos_JuegoIdJuego",
                table: "Imagenes",
                column: "JuegoIdJuego",
                principalTable: "Juegos",
                principalColumn: "IdJuego");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Bibliotecas_IdBiblioteca",
                table: "Juegos",
                column: "IdBiblioteca",
                principalTable: "Bibliotecas",
                principalColumn: "IdBiblioteca");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Carritos_IdCarrito",
                table: "Juegos",
                column: "IdCarrito",
                principalTable: "Carritos",
                principalColumn: "IdCarrito");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Categorias_CategoriaIdCategoria",
                table: "Juegos",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Reseñas_ReseñaIdReseña",
                table: "Juegos",
                column: "ReseñaIdReseña",
                principalTable: "Reseñas",
                principalColumn: "IdReseña");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Bibliotecas_IdBiblioteca",
                table: "Productos",
                column: "IdBiblioteca",
                principalTable: "Bibliotecas",
                principalColumn: "IdBiblioteca");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Carritos_IdCarrito",
                table: "Productos",
                column: "IdCarrito",
                principalTable: "Carritos",
                principalColumn: "IdCarrito");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaIdCategoria",
                table: "Productos",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Reseñas_ReseñaIdReseña",
                table: "Productos",
                column: "ReseñaIdReseña",
                principalTable: "Reseñas",
                principalColumn: "IdReseña");

            migrationBuilder.AddForeignKey(
                name: "FK_Reseñas_Juegos_IdJuego",
                table: "Reseñas",
                column: "IdJuego",
                principalTable: "Juegos",
                principalColumn: "IdJuego");

            migrationBuilder.AddForeignKey(
                name: "FK_Reseñas_Productos_IdProducto",
                table: "Reseñas",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Reseñas_Usuarios_IdUsuario",
                table: "Reseñas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Productos_IdProducto",
                table: "Anuncios");

            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Usuarios_IdUsuario",
                table: "Anuncios");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecas_Usuarios_IdUsuario",
                table: "Bibliotecas");

            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Usuarios_IdUsuario",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Juegos_JuegoIdJuego",
                table: "Imagenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Bibliotecas_IdBiblioteca",
                table: "Juegos");

            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Carritos_IdCarrito",
                table: "Juegos");

            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Categorias_CategoriaIdCategoria",
                table: "Juegos");

            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Reseñas_ReseñaIdReseña",
                table: "Juegos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Bibliotecas_IdBiblioteca",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Carritos_IdCarrito",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaIdCategoria",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Reseñas_ReseñaIdReseña",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reseñas_Juegos_IdJuego",
                table: "Reseñas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reseñas_Productos_IdProducto",
                table: "Reseñas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reseñas_Usuarios_IdUsuario",
                table: "Reseñas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Reseñas_IdProducto",
                table: "Reseñas");

            migrationBuilder.DropIndex(
                name: "IX_Reseñas_IdUsuario",
                table: "Reseñas");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoriaIdCategoria",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdBiblioteca",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdCarrito",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ReseñaIdReseña",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_CategoriaIdCategoria",
                table: "Juegos");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_IdBiblioteca",
                table: "Juegos");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_IdCarrito",
                table: "Juegos");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_ReseñaIdReseña",
                table: "Juegos");

            migrationBuilder.DropIndex(
                name: "IX_Imagenes_JuegoIdJuego",
                table: "Imagenes");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_IdUsuario",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotecas_IdUsuario",
                table: "Bibliotecas");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_IdProducto",
                table: "Anuncios");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_IdUsuario",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdAnuncio",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdBiblioteca",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdCarrito",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdReseña",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ReseñaIdReseña",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "IdBiblioteca",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "IdCarrito",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "IdImagen",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "IdReseña",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "ReseñaIdReseña",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "JuegoIdJuego",
                table: "Imagenes");

            migrationBuilder.RenameColumn(
                name: "IdJuego",
                table: "Reseñas",
                newName: "UsuarioIdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Reseñas_IdJuego",
                table: "Reseñas",
                newName: "IX_Reseñas_UsuarioIdUsuario");

            migrationBuilder.AlterColumn<int>(
                name: "IdProducto",
                table: "Reseñas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JuegoIdJuego",
                table: "Reseñas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoJuego",
                table: "Juegos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "Carritos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductosIdProducto",
                table: "Carritos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Carritos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "Bibliotecas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductosIdProducto",
                table: "Bibliotecas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Bibliotecas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoIdProducto",
                table: "Anuncios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Anuncios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_JuegoIdJuego",
                table: "Reseñas",
                column: "JuegoIdJuego");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_ProductosIdProducto",
                table: "Carritos",
                column: "ProductosIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_UsuarioIdUsuario",
                table: "Carritos",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecas_ProductosIdProducto",
                table: "Bibliotecas",
                column: "ProductosIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecas_UsuarioIdUsuario",
                table: "Bibliotecas",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_ProductoIdProducto",
                table: "Anuncios",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_UsuarioIdUsuario",
                table: "Anuncios",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Productos_ProductoIdProducto",
                table: "Anuncios",
                column: "ProductoIdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Usuarios_UsuarioIdUsuario",
                table: "Anuncios",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotecas_Productos_ProductosIdProducto",
                table: "Bibliotecas",
                column: "ProductosIdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotecas_Usuarios_UsuarioIdUsuario",
                table: "Bibliotecas",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Productos_ProductosIdProducto",
                table: "Carritos",
                column: "ProductosIdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioIdUsuario",
                table: "Carritos",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Reseñas_Juegos_JuegoIdJuego",
                table: "Reseñas",
                column: "JuegoIdJuego",
                principalTable: "Juegos",
                principalColumn: "IdJuego");

            migrationBuilder.AddForeignKey(
                name: "FK_Reseñas_Usuarios_UsuarioIdUsuario",
                table: "Reseñas",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }
    }
}
