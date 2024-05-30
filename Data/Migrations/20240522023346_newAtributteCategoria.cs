using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemu.Data.Migrations
{
    public partial class newAtributteCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icono",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icono",
                table: "Categorias");
        }
    }
}
