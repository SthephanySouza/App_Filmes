using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeApi.Migrations
{
    /// <inheritdoc />
    public partial class IniciarBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atores",
                columns: table => new
                {
                    IdAtor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAtor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ObraTrab = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atores", x => x.IdAtor);
                });

            migrationBuilder.CreateTable(
                name: "Diretores",
                columns: table => new
                {
                    IdDiretor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDiretor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaiorObra = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretores", x => x.IdDiretor);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    IdFilme = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFilme = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Classificacao = table.Column<int>(type: "int", nullable: false),
                    Diretor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Idioma = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DataLanc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ator = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.IdFilme);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGenero = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atores");

            migrationBuilder.DropTable(
                name: "Diretores");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
