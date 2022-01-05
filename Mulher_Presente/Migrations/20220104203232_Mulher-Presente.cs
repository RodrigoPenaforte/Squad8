using Microsoft.EntityFrameworkCore.Migrations;

namespace Mulher_Presente.Migrations
{
    public partial class MulherPresente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    id_parceiro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especilidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.id_parceiro);
                });

            migrationBuilder.CreateTable(
                name: "Vitima",
                columns: table => new
                {
                    id_vitima = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apelido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parceirosid_parceiro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitima", x => x.id_vitima);
                    table.ForeignKey(
                        name: "FK_Vitima_Parceiros_Parceirosid_parceiro",
                        column: x => x.Parceirosid_parceiro,
                        principalTable: "Parceiros",
                        principalColumn: "id_parceiro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vitima_Parceirosid_parceiro",
                table: "Vitima",
                column: "Parceirosid_parceiro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vitima");

            migrationBuilder.DropTable(
                name: "Parceiros");
        }
    }
}
