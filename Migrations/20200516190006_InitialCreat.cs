using Microsoft.EntityFrameworkCore.Migrations;

namespace monitor_covid19.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Infeccoes",
                columns: table => new
                {
                    InfeccaoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CasosConfirmados = table.Column<int>(nullable: false),
                    Mortes = table.Column<int>(nullable: false),
                    Recuperados = table.Column<int>(nullable: false),
                    PaisRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infeccoes", x => x.InfeccaoId);
                    table.ForeignKey(
                        name: "FK_Infeccoes_Paises_PaisRef",
                        column: x => x.PaisRef,
                        principalTable: "Paises",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Infeccoes_PaisRef",
                table: "Infeccoes",
                column: "PaisRef",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infeccoes");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
