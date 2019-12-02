using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class DetalleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalisisUnitario_Item_ItemId",
                table: "AnalisisUnitario");

            migrationBuilder.DropForeignKey(
                name: "FK_RecursoBasico_AnalisisUnitario_AnalisisUnitarioId",
                table: "RecursoBasico");

            migrationBuilder.DropForeignKey(
                name: "FK_RecursoBasico_Item_ItemId",
                table: "RecursoBasico");

            migrationBuilder.DropIndex(
                name: "IX_RecursoBasico_AnalisisUnitarioId",
                table: "RecursoBasico");

            migrationBuilder.DropIndex(
                name: "IX_RecursoBasico_ItemId",
                table: "RecursoBasico");

            migrationBuilder.DropIndex(
                name: "IX_AnalisisUnitario_ItemId",
                table: "AnalisisUnitario");

            migrationBuilder.DropColumn(
                name: "AnalisisUnitarioId",
                table: "RecursoBasico");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "RecursoBasico");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "AnalisisUnitario");

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnalisisUnitarioId = table.Column<int>(nullable: true),
                    RecursoBasicoId = table.Column<int>(nullable: true),
                    Rendimiento = table.Column<int>(nullable: false),
                    AnalisisUnitarioId2 = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalle_AnalisisUnitario_AnalisisUnitarioId",
                        column: x => x.AnalisisUnitarioId,
                        principalTable: "AnalisisUnitario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detalle_AnalisisUnitario_AnalisisUnitarioId2",
                        column: x => x.AnalisisUnitarioId2,
                        principalTable: "AnalisisUnitario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detalle_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detalle_RecursoBasico_RecursoBasicoId",
                        column: x => x.RecursoBasicoId,
                        principalTable: "RecursoBasico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_AnalisisUnitarioId",
                table: "Detalle",
                column: "AnalisisUnitarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_AnalisisUnitarioId2",
                table: "Detalle",
                column: "AnalisisUnitarioId2");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_ItemId",
                table: "Detalle",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_RecursoBasicoId",
                table: "Detalle",
                column: "RecursoBasicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.AddColumn<int>(
                name: "AnalisisUnitarioId",
                table: "RecursoBasico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "RecursoBasico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "AnalisisUnitario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecursoBasico_AnalisisUnitarioId",
                table: "RecursoBasico",
                column: "AnalisisUnitarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RecursoBasico_ItemId",
                table: "RecursoBasico",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisUnitario_ItemId",
                table: "AnalisisUnitario",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalisisUnitario_Item_ItemId",
                table: "AnalisisUnitario",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecursoBasico_AnalisisUnitario_AnalisisUnitarioId",
                table: "RecursoBasico",
                column: "AnalisisUnitarioId",
                principalTable: "AnalisisUnitario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecursoBasico_Item_ItemId",
                table: "RecursoBasico",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
