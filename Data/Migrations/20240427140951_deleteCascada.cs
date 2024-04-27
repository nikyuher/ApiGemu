using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class deleteCascada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Usuarios_UsuarioIdUsuario",
                table: "Anuncios");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecas_Usuarios_UsuarioIdUsuario",
                table: "Bibliotecas");

            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioIdUsuario",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reseñas_Usuarios_UsuarioIdUsuario",
                table: "Reseñas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Usuarios_UsuarioIdUsuario",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_UsuarioIdUsuario",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Reseñas_UsuarioIdUsuario",
                table: "Reseñas");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_UsuarioIdUsuario",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotecas_UsuarioIdUsuario",
                table: "Bibliotecas");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_UsuarioIdUsuario",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Reseñas");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Bibliotecas");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Anuncios");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_IdUsuario",
                table: "Transacciones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_IdUsuario",
                table: "Reseñas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdUsuario",
                table: "Carritos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecas_IdUsuario",
                table: "Bibliotecas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_IdUsuario",
                table: "Anuncios",
                column: "IdUsuario");

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
                name: "FK_Reseñas_Usuarios_IdUsuario",
                table: "Reseñas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Usuarios_IdUsuario",
                table: "Transacciones",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Reseñas_Usuarios_IdUsuario",
                table: "Reseñas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Usuarios_IdUsuario",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_IdUsuario",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Reseñas_IdUsuario",
                table: "Reseñas");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_IdUsuario",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotecas_IdUsuario",
                table: "Bibliotecas");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_IdUsuario",
                table: "Anuncios");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Transacciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Reseñas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Carritos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Bibliotecas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Anuncios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_UsuarioIdUsuario",
                table: "Transacciones",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_UsuarioIdUsuario",
                table: "Reseñas",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_UsuarioIdUsuario",
                table: "Carritos",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecas_UsuarioIdUsuario",
                table: "Bibliotecas",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_UsuarioIdUsuario",
                table: "Anuncios",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Usuarios_UsuarioIdUsuario",
                table: "Anuncios",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotecas_Usuarios_UsuarioIdUsuario",
                table: "Bibliotecas",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioIdUsuario",
                table: "Carritos",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Reseñas_Usuarios_UsuarioIdUsuario",
                table: "Reseñas",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Usuarios_UsuarioIdUsuario",
                table: "Transacciones",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }
    }
}
