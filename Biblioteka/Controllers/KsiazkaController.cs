using Microsoft.AspNetCore.Mvc;
using Biblioteka.Models;
namespace Biblioteka.Controllers
{
    public class KsiazkaController : Controller
    {
        private static IList<Ksiazki> books = new List<Ksiazki>();

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
            ksiazka.KsiazkaId = books.Count + 1;
            books.Add(ksiazka);
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            return View(books.FirstOrDefault(x => x.KsiazkaId == id));
        }

        public IActionResult Edit(int id)
        {
            return View(books.FirstOrDefault(x => x.KsiazkaId == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Ksiazki ksiazki)
        {

            Ksiazki ksiazka = books.FirstOrDefault(x => x.KsiazkaId == id);
            ksiazka.Nazwa = ksiazki.Nazwa;
            ksiazka.Opis = ksiazki.Opis;
            ksiazka.Autor = ksiazki.Autor;
            ksiazka.Kategoria = ksiazki.Kategoria;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Ksiazki ksiazka = books.FirstOrDefault(x => x.KsiazkaId == id);
            books.Remove(ksiazka);
            return RedirectToAction(nameof(Index));
        }
    }
}
