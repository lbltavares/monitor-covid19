using Microsoft.EntityFrameworkCore.Migrations;

namespace monitor_covid19.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infeccoes",
                columns: table => new
                {
                    InfeccaoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CasosConfirmados = table.Column<int>(nullable: false),
                    Mortes = table.Column<int>(nullable: false),
                    Recuperados = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infeccoes", x => x.InfeccaoId);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    InfeccaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisId);
                    table.ForeignKey(
                        name: "FK_Paises_Infeccoes_InfeccaoId",
                        column: x => x.InfeccaoId,
                        principalTable: "Infeccoes",
                        principalColumn: "InfeccaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paises_InfeccaoId",
                table: "Paises",
                column: "InfeccaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Infeccoes");
        }
    }
}
