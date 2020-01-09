using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class RemoveHerramientaMenor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Porcentaje_Menor",
                table: "Proyecto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Porcentaje_Menor",
                table: "Proyecto",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
