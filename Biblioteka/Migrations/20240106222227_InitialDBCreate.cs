using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Czytelnik",
                columns: table => new
                {
                    CzytelnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerKarty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCzytelnika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Czytelnik", x => x.CzytelnikId);
                });

            migrationBuilder.CreateTable(
                name: "Wydawnictwo",
                columns: table => new
                {
                    WydawnictwoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydawnictwo", x => x.WydawnictwoId);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kategoria = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    WydawnictwoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Wydawnictwo_WydawnictwoId",
                        column: x => x.WydawnictwoId,
                        principalTable: "Wydawnictwo",
                        principalColumn: "WydawnictwoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Czytelnik_Ksiazka",
                columns: table => new
                {
                    CzytelnikId = table.Column<int>(type: "int", nullable: false),
                    KsiazkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Czytelnik_Ksiazka", x => new { x.CzytelnikId, x.KsiazkaId });
                    table.ForeignKey(
                        name: "FK_Czytelnik_Ksiazka_Czytelnik_CzytelnikId",
                        column: x => x.CzytelnikId,
                        principalTable: "Czytelnik",
                        principalColumn: "CzytelnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Czytelnik_Ksiazka_Ksiazki_KsiazkaId",
                        column: x => x.KsiazkaId,
                        principalTable: "Ksiazki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Czytelnik_Ksiazka_KsiazkaId",
                table: "Czytelnik_Ksiazka",
                column: "KsiazkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_AutorId",
                table: "Ksiazki",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_WydawnictwoId",
                table: "Ksiazki",
                column: "WydawnictwoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Czytelnik_Ksiazka");

            migrationBuilder.DropTable(
                name: "Czytelnik");

            migrationBuilder.DropTable(
                name: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Wydawnictwo");
        }
    }
}
