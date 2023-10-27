using Microsoft.AspNetCore.Mvc;
using Biblioteka.Models;
namespace Biblioteka.Controllers
{
    public class KsiazkaController : Controller
    {
        private static IList<Ksiazki> books = new List<Ksiazki>()
        {
            new Ksiazki(){Id = 1, Name = "Władca Pierścieni. Drużyna Pierścienia", Description="Opis książki Władca Pierścieni. Drużyna Pierścienia", Author="J.R.Tolkien"},
            new Ksiazki(){Id = 2, Name = "Harry Potter i Książę Półkrwi", Description="Opis książki Harry Potter i Książę Półkrwi", Author="J.K. Rowling"},
            new Ksiazki(){Id = 3, Name = "Wiedźmin Ostatnie Życzenie", Description="Opis książki Wiedźmin Ostatnie Życzenie", Author="Andrzej Sapkowski"},
            new Ksiazki(){Id = 4, Name = "Gry Szpiegów", Description="Opis książki Gry Szpiegów", Author="John Altman"}
        };

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Create()
        {
            return View(new Ksiazki());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Ksiazki ksiazka)
        {
            ksiazka.Id = books.Count + 1;
            books.Add(ksiazka);
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            return View(books.FirstOrDefault(x => x.Id == id));
        }

        public IActionResult Edit(int id)
        {
            return View(books.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Ksiazki ksiazki)
        {

            Ksiazki ksiazka = books.FirstOrDefault(x => x.Id == id);
            ksiazka.Name = ksiazki.Name;
            ksiazka.Description = ksiazki.Description;
            ksiazka.Author = ksiazki.Author;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Ksiazki ksiazka = books.FirstOrDefault(x => x.Id == id);
            books.Remove(ksiazka);
            return RedirectToAction(nameof(Index));
        }
    }
}
