using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Obra = table.Column<string>(nullable: false),
                    Contratante = table.Column<string>(nullable: false),
                    Fecha_Presentacion = table.Column<string>(nullable: false),
                    Fecha_Modificacion = table.Column<string>(nullable: false),
                    Comentarios = table.Column<string>(nullable: false),
                    Porcentaje_Menor = table.Column<float>(nullable: false),
                    Porcentaje_Prestaciones_Sociales = table.Column<float>(nullable: false),
                    Desperdicio_Materiales = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostoIndirecto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Porcentaje = table.Column<float>(nullable: false),
                    ProyectoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostoIndirecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostoIndirecto_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Grupo = table.Column<string>(nullable: true),
                    Abreviatura = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    ProyectoId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoId = table.Column<int>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Unidad = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Frente = table.Column<int>(nullable: false),
                    Actividad = table.Column<int>(nullable: false),
                    Aporte = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalisisUnitario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoId = table.Column<int>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Unidad = table.Column<string>(nullable: true),
                    GrupoId = table.Column<int>(nullable: true),
                    Clasificacion = table.Column<string>(nullable: true),
                    Valor_Unitario = table.Column<long>(nullable: false),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisisUnitario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisisUnitario_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnalisisUnitario_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnalisisUnitario_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecursoBasico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Unidad = table.Column<string>(nullable: true),
                    GrupoId = table.Column<int>(nullable: true),
                    Clasificacion = table.Column<string>(nullable: true),
                    Precio = table.Column<long>(nullable: false),
                    Fecha = table.Column<string>(nullable: true),
                    AnalisisUnitarioId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursoBasico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecursoBasico_AnalisisUnitario_AnalisisUnitarioId",
                        column: x => x.AnalisisUnitarioId,
                        principalTable: "AnalisisUnitario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecursoBasico_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecursoBasico_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisUnitario_GrupoId",
                table: "AnalisisUnitario",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisUnitario_ItemId",
                table: "AnalisisUnitario",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisUnitario_ProyectoId",
                table: "AnalisisUnitario",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_CostoIndirecto_ProyectoId",
                table: "CostoIndirecto",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_ProyectoId",
                table: "Grupo",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ProyectoId",
                table: "Item",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecursoBasico_AnalisisUnitarioId",
                table: "RecursoBasico",
                column: "AnalisisUnitarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RecursoBasico_GrupoId",
                table: "RecursoBasico",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecursoBasico_ItemId",
                table: "RecursoBasico",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostoIndirecto");

            migrationBuilder.DropTable(
                name: "RecursoBasico");

            migrationBuilder.DropTable(
                name: "AnalisisUnitario");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Proyecto");
        }
    }
}
