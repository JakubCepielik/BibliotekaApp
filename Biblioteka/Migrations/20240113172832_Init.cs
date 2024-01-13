using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autorzy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImieNazwisko = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Biografia = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorzy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Czytelnicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImieNazwisko = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NumerKarty = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    StatusCzytelnika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Czytelnicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wydawnictwa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydawnictwa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miasto = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "varchar(6)", nullable: false),
                    CzytelnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adres_Czytelnicy_CzytelnikId",
                        column: x => x.CzytelnikId,
                        principalTable: "Czytelnicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Kategoria = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    WydawnictwoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Autorzy_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autorzy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Wydawnictwa_WydawnictwoId",
                        column: x => x.WydawnictwoId,
                        principalTable: "Wydawnictwa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CzytelnikKsiazki",
                columns: table => new
                {
                    CzytelnicyId = table.Column<int>(type: "int", nullable: false),
                    KsiazkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CzytelnikKsiazki", x => new { x.CzytelnicyId, x.KsiazkiId });
                    table.ForeignKey(
                        name: "FK_CzytelnikKsiazki_Czytelnicy_CzytelnicyId",
                        column: x => x.CzytelnicyId,
                        principalTable: "Czytelnicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CzytelnikKsiazki_Ksiazki_KsiazkiId",
                        column: x => x.KsiazkiId,
                        principalTable: "Ksiazki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_CzytelnikId",
                table: "Adres",
                column: "CzytelnikId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CzytelnikKsiazki_KsiazkiId",
                table: "CzytelnikKsiazki",
                column: "KsiazkiId");

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
                name: "Adres");

            migrationBuilder.DropTable(
                name: "CzytelnikKsiazki");

            migrationBuilder.DropTable(
                name: "Czytelnicy");

            migrationBuilder.DropTable(
                name: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Autorzy");

            migrationBuilder.DropTable(
                name: "Wydawnictwa");
        }
    }
}
