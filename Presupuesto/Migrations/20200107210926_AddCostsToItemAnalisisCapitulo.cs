using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class AddCostsToItemAnalisisCapitulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CostoEquipo",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CostoManoObra",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CostoMateriales",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CostoEquipo",
                table: "Capitulo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CostoManoObra",
                table: "Capitulo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CostoMateriales",
                table: "Capitulo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CostoEquipo",
                table: "AnalisisUnitario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CostoManoObra",
                table: "AnalisisUnitario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CostoMateriales",
                table: "AnalisisUnitario",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostoEquipo",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CostoManoObra",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CostoMateriales",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CostoEquipo",
                table: "Capitulo");

            migrationBuilder.DropColumn(
                name: "CostoManoObra",
                table: "Capitulo");

            migrationBuilder.DropColumn(
                name: "CostoMateriales",
                table: "Capitulo");

            migrationBuilder.DropColumn(
                name: "CostoEquipo",
                table: "AnalisisUnitario");

            migrationBuilder.DropColumn(
                name: "CostoManoObra",
                table: "AnalisisUnitario");

            migrationBuilder.DropColumn(
                name: "CostoMateriales",
                table: "AnalisisUnitario");
        }
    }
}
