using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    IdJuego = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Plataforma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descuento = table.Column<int>(type: "int", nullable: true),
                    CodigoJuego = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos", x => x.IdJuego);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoPerfil = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datos = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EsPortada = table.Column<bool>(type: "bit", nullable: false),
                    JuegoId = table.Column<int>(type: "int", nullable: true),
                    ProductoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagenes_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "IdJuego");
                    table.ForeignKey(
                        name: "FK_Imagenes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "IdProducto");
                });

            migrationBuilder.CreateTable(
                name: "Anuncios",
                columns: table => new
                {
                    IdAnuncio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    ProductoIdProducto = table.Column<int>(type: "int", nullable: true),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncios", x => x.IdAnuncio);
                    table.ForeignKey(
                        name: "FK_Anuncios_Productos_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto");
                    table.ForeignKey(
                        name: "FK_Anuncios_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Bibliotecas",
                columns: table => new
                {
                    IdBiblioteca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    ProductosIdProducto = table.Column<int>(type: "int", nullable: true),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecas", x => x.IdBiblioteca);
                    table.ForeignKey(
                        name: "FK_Bibliotecas_Productos_ProductosIdProducto",
                        column: x => x.ProductosIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto");
                    table.ForeignKey(
                        name: "FK_Bibliotecas_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    IdCarrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    ProductosIdProducto = table.Column<int>(type: "int", nullable: true),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.IdCarrito);
                    table.ForeignKey(
                        name: "FK_Carritos_Productos_ProductosIdProducto",
                        column: x => x.ProductosIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto");
                    table.ForeignKey(
                        name: "FK_Carritos_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Reseñas",
                columns: table => new
                {
                    IdReseña = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Solicitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    JuegoIdJuego = table.Column<int>(type: "int", nullable: true),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reseñas", x => x.IdReseña);
                    table.ForeignKey(
                        name: "FK_Reseñas_Juegos_JuegoIdJuego",
                        column: x => x.JuegoIdJuego,
                        principalTable: "Juegos",
                        principalColumn: "IdJuego");
                    table.ForeignKey(
                        name: "FK_Reseñas_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    IdTransaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.IdTransaccion);
                    table.ForeignKey(
                        name: "FK_Transacciones_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_ProductoIdProducto",
                table: "Anuncios",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_UsuarioIdUsuario",
                table: "Anuncios",
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
                name: "IX_Carritos_ProductosIdProducto",
                table: "Carritos",
                column: "ProductosIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_UsuarioIdUsuario",
                table: "Carritos",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_JuegoId",
                table: "Imagenes",
                column: "JuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_ProductoId",
                table: "Imagenes",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_JuegoIdJuego",
                table: "Reseñas",
                column: "JuegoIdJuego");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_UsuarioIdUsuario",
                table: "Reseñas",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_UsuarioIdUsuario",
                table: "Transacciones",
                column: "UsuarioIdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anuncios");

            migrationBuilder.DropTable(
                name: "Bibliotecas");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Imagenes");

            migrationBuilder.DropTable(
                name: "Reseñas");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Juegos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
