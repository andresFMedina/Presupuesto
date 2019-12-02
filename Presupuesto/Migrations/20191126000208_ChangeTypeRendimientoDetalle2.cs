using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class ChangeTypeRendimientoDetalle2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rendimiento",
                table: "Detalle",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rendimiento",
                table: "Detalle",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
