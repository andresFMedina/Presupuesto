using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class AddingForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalisisUnitario_Grupo_GrupoId",
                table: "AnalisisUnitario");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalisisUnitario_Proyecto_ProyectoId",
                table: "AnalisisUnitario");

            migrationBuilder.DropForeignKey(
                name: "FK_CostoIndirecto_Proyecto_ProyectoId",
                table: "CostoIndirecto");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Proyecto_ProyectoId",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoId",
                table: "Item",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoId",
                table: "CostoIndirecto",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoId",
                table: "AnalisisUnitario",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GrupoId",
                table: "AnalisisUnitario",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisisUnitario_Grupo_GrupoId",
                table: "AnalisisUnitario",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisisUnitario_Proyecto_ProyectoId",
                table: "AnalisisUnitario",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostoIndirecto_Proyecto_ProyectoId",
                table: "CostoIndirecto",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Proyecto_ProyectoId",
                table: "Item",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalisisUnitario_Grupo_GrupoId",
                table: "AnalisisUnitario");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalisisUnitario_Proyecto_ProyectoId",
                table: "AnalisisUnitario");

            migrationBuilder.DropForeignKey(
                name: "FK_CostoIndirecto_Proyecto_ProyectoId",
                table: "CostoIndirecto");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Proyecto_ProyectoId",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoId",
                table: "Item",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoId",
                table: "CostoIndirecto",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoId",
                table: "AnalisisUnitario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GrupoId",
                table: "AnalisisUnitario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisisUnitario_Grupo_GrupoId",
                table: "AnalisisUnitario",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisisUnitario_Proyecto_ProyectoId",
                table: "AnalisisUnitario",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostoIndirecto_Proyecto_ProyectoId",
                table: "CostoIndirecto",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Proyecto_ProyectoId",
                table: "Item",
                column: "ProyectoId",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
