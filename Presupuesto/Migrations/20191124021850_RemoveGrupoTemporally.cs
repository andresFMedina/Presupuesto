using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class RemoveGrupoTemporally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalisisUnitario_Grupo_GrupoId",
                table: "AnalisisUnitario");

            migrationBuilder.DropIndex(
                name: "IX_AnalisisUnitario_GrupoId",
                table: "AnalisisUnitario");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "AnalisisUnitario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "AnalisisUnitario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisUnitario_GrupoId",
                table: "AnalisisUnitario",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisisUnitario_Grupo_GrupoId",
                table: "AnalisisUnitario",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
