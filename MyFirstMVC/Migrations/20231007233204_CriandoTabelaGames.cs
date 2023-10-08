using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstMVC.Migrations
{
    public partial class CriandoTabelaGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeJogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plataforma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
