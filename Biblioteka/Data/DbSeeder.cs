using Biblioteka.Models;

namespace Biblioteka.Data
{
    public class DbSeeder
    {
        public void Seed(AppDbContext dbContext)
        {
            if (dbContext.Wydawnictwa.Any())
            {
                return;
            }

            dbContext.Wydawnictwa.AddRange(
            new Wydawnictwo
            {
                Nazwa = "PWN"
            },
            new Wydawnictwo
            {
                Nazwa = "Wydawnictwo Literackie"
            });

            if (dbContext.Autorzy.Any())
            {
                return;
            }

            dbContext.Autorzy.AddRange(
            new Autor
            {
                ImieNazwisko = "Andrzej Sapkowski",
                Biografia = "Biografia Andrzeja Sapowskiego"
            },
            new Autor
            {
                ImieNazwisko = "Remigiusz Mróz",
                Biografia = "Biografia Remigiusza Mroza"
            });


            dbContext.SaveChanges();

            if (dbContext.Ksiazki.Any())
            {
                return;
            }

            dbContext.Ksiazki.AddRange(
            new Ksiazki
            {
                Nazwa = "Wiedźmin Miecz Przeznaczenia",
                Opis = "Opis książki Wiedźmin Miecz Przeznaczenia",
                AutorId = 1,
                Kategoria = Enums.KsiazkaKategoria.Fantastyka,
                WydawnictwoId = 1
            },
            new Ksiazki
            {
                Nazwa = "Behawiorysta",
                Opis = "Opis książki Behawiorysta",
                AutorId = 2,
                Kategoria = Enums.KsiazkaKategoria.Thriller,
                WydawnictwoId = 2
            }
            );

            dbContext.SaveChanges();

        }
    }
}
