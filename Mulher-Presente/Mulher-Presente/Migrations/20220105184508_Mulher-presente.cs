using Microsoft.EntityFrameworkCore.Migrations;

namespace Mulher_Presente.Migrations
{
    public partial class Mulherpresente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParceirosUser",
                columns: table => new
                {
                    ID_parceiro = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone_parceiro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_parceiro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParceirosUser", x => x.ID_parceiro);
                });

            migrationBuilder.CreateTable(
                name: "VitimaUser",
                columns: table => new
                {
                    ID_vitima = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParceirosUserID_parceiro = table.Column<int>(type: "int", nullable: false),
                    ParceirosUserID_parceiro1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitimaUser", x => x.ID_vitima);
                    table.ForeignKey(
                        name: "FK_VitimaUser_ParceirosUser_ParceirosUserID_parceiro1",
                        column: x => x.ParceirosUserID_parceiro1,
                        principalTable: "ParceirosUser",
                        principalColumn: "ID_parceiro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VitimaUser_ParceirosUserID_parceiro1",
                table: "VitimaUser",
                column: "ParceirosUserID_parceiro1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VitimaUser");

            migrationBuilder.DropTable(
                name: "ParceirosUser");
        }
    }
}
