using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class CostoIndirectoMigracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostoIndirecto_Proyecto_ProyectoId",
                table: "CostoIndirecto");

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoId",
                table: "CostoIndirecto",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CostoIndirecto_Proyecto_ProyectoId",
                table: "CostoIndirecto",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostoIndirecto_Proyecto_ProyectoId",
                table: "CostoIndirecto");

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoId",
                table: "CostoIndirecto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CostoIndirecto_Proyecto_ProyectoId",
                table: "CostoIndirecto",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
