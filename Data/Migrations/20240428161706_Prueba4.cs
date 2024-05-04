using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class Prueba4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rol_RolIdRol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolIdRol",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "RolIdRol",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "IdRol");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "IdRol", "Nombre" },
                values: new object[] { 1, "Usuario" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "IdRol", "Nombre" },
                values: new object[] { 2, "Admin" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "CodigoPostal", "Contraseña", "Correo", "Direccion", "FotoPerfil", "IdRol", "Nombre" },
                values: new object[] { 1, 0, "ADMINcontraseña123@", "admin@gmail.com", null, null, 2, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_IdRol",
                table: "Usuarios",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_IdRol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "IdRol",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "IdRol",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Rol");

            migrationBuilder.AddColumn<int>(
                name: "RolIdRol",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolIdRol",
                table: "Usuarios",
                column: "RolIdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Rol_RolIdRol",
                table: "Usuarios",
                column: "RolIdRol",
                principalTable: "Rol",
                principalColumn: "IdRol");
        }
    }
}
