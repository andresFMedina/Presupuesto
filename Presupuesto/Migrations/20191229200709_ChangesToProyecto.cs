using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class ChangesToProyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desperdicio_Materiales",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "Porcentaje_Prestaciones_Sociales",
                table: "Proyecto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Desperdicio_Materiales",
                table: "Proyecto",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Porcentaje_Prestaciones_Sociales",
                table: "Proyecto",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
