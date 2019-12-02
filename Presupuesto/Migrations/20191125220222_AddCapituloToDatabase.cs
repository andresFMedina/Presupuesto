using Microsoft.EntityFrameworkCore.Migrations;

namespace Presupuesto.Migrations
{
    public partial class AddCapituloToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CapituloId",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroCapitulo",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValorUnitario",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Capitulo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    ProyectoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Capitulo_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_CapituloId",
                table: "Item",
                column: "CapituloId");

            migrationBuilder.CreateIndex(
                name: "IX_Capitulo_ProyectoId",
                table: "Capitulo",
                column: "ProyectoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Capitulo_CapituloId",
                table: "Item",
                column: "CapituloId",
                principalTable: "Capitulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Capitulo_CapituloId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "Capitulo");

            migrationBuilder.DropIndex(
                name: "IX_Item_CapituloId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CapituloId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "NumeroCapitulo",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ValorUnitario",
                table: "Item");
        }
    }
}
