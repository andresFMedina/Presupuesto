using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class DetalleChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_RecursoBasico_RecursoBasicoId",
                table: "Detalle");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_RecursoBasicoId",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "RecursoBasicoId",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "Valor_Unitario",
                table: "AnalisisUnitario");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Detalle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Detalle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetalleDe",
                table: "Detalle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId2",
                table: "Detalle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Precio",
                table: "Detalle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unidad",
                table: "Detalle",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ValorUnitario",
                table: "AnalisisUnitario",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_ItemId2",
                table: "Detalle",
                column: "ItemId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Item_ItemId2",
                table: "Detalle",
                column: "ItemId2",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Item_ItemId2",
                table: "Detalle");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_ItemId2",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "DetalleDe",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "ItemId2",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "Unidad",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "ValorUnitario",
                table: "AnalisisUnitario");

            migrationBuilder.AddColumn<int>(
                name: "RecursoBasicoId",
                table: "Detalle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Valor_Unitario",
                table: "AnalisisUnitario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_RecursoBasicoId",
                table: "Detalle",
                column: "RecursoBasicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_RecursoBasico_RecursoBasicoId",
                table: "Detalle",
                column: "RecursoBasicoId",
                principalTable: "RecursoBasico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
