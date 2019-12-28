using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class RemoveGrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecursoBasico_Grupo_GrupoId",
                table: "RecursoBasico");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropIndex(
                name: "IX_RecursoBasico_GrupoId",
                table: "RecursoBasico");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "RecursoBasico");

            migrationBuilder.AddColumn<string>(
                name: "Grupo",
                table: "RecursoBasico",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grupo",
                table: "Detalle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grupo",
                table: "AnalisisUnitario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "RecursoBasico");

            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "AnalisisUnitario");

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "RecursoBasico",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abreviatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre_Grupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProyectoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupo_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecursoBasico_GrupoId",
                table: "RecursoBasico",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_ProyectoId",
                table: "Grupo",
                column: "ProyectoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecursoBasico_Grupo_GrupoId",
                table: "RecursoBasico",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
