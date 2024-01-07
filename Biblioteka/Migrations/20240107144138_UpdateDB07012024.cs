using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB07012024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Czytelnik");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Wydawnictwo",
                newName: "Nazwa");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Ksiazki",
                newName: "Opis");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Ksiazki",
                newName: "Nazwa");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ksiazki",
                newName: "KsiazkaId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Czytelnik",
                newName: "ImieNazwisko");

            migrationBuilder.RenameColumn(
                name: "ProfilePicURL",
                table: "Autor",
                newName: "Zdjecie");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Autor",
                newName: "ImieNazwisko");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Autor",
                newName: "Biografia");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Autor",
                newName: "AutorId");

            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Czytelnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    AdresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.AdresId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Czytelnik_AdresId",
                table: "Czytelnik",
                column: "AdresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Czytelnik_Adres_AdresId",
                table: "Czytelnik",
                column: "AdresId",
                principalTable: "Adres",
                principalColumn: "AdresId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Czytelnik_Adres_AdresId",
                table: "Czytelnik");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Czytelnik_AdresId",
                table: "Czytelnik");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Czytelnik");

            migrationBuilder.RenameColumn(
                name: "Nazwa",
                table: "Wydawnictwo",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Opis",
                table: "Ksiazki",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Nazwa",
                table: "Ksiazki",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "KsiazkaId",
                table: "Ksiazki",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ImieNazwisko",
                table: "Czytelnik",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Zdjecie",
                table: "Autor",
                newName: "ProfilePicURL");

            migrationBuilder.RenameColumn(
                name: "ImieNazwisko",
                table: "Autor",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Biografia",
                table: "Autor",
                newName: "Biography");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Autor",
                newName: "AuthorId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Czytelnik",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
