using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class AddProponenteToProyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Proponente",
                table: "Proyecto",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proponente",
                table: "Proyecto");
        }
    }
}
