using Microsoft.AspNetCore.Mvc;
using Biblioteka.Models;
using Biblioteka.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Controllers
{
    public class KsiazkaController : Controller
    {
        private readonly AppDbContext _contex;
        public KsiazkaController(AppDbContext contex)
        {
            _contex = contex;
        }


        public IActionResult Index()
        {
            return View(_contex.Ksiazki.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Autorzy = new SelectList(_contex.Autorzy, "Id", "ImieNazwisko");
            ViewBag.Wydawnictwa = new SelectList(_contex.Wydawnictwa, "Id", "Nazwa");
            return View(new Ksiazki());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Ksiazki ksiazka)
        {
            Ksiazki ksiazkaTmp = new Ksiazki();
            ksiazkaTmp.Nazwa = ksiazka.Nazwa;
            ksiazkaTmp.Opis = ksiazka.Opis;
            ksiazkaTmp.AutorId = Convert.ToInt32(ksiazka.Autor.Id);
            ksiazkaTmp.WydawnictwoId = Convert.ToInt32(ksiazka.Wydawnictwo.Id);
            ksiazkaTmp.Kategoria = ksiazka.Kategoria;
            _contex.Ksiazki.Add(ksiazkaTmp);
            _contex.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            Ksiazki ksiazka = _contex.Ksiazki
            .Include(k => k.Autor)
            .Include(k => k.Wydawnictwo)
            .FirstOrDefault(k => k.Id == id);
            return View(ksiazka);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Autorzy = new SelectList(_contex.Autorzy, "Id", "ImieNazwisko");
            ViewBag.Wydawnictwa = new SelectList(_contex.Wydawnictwa, "Id", "Nazwa");
            return View(_contex.Ksiazki.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Ksiazki ksiazka)
        {
            Ksiazki ksiazkaTmp = _contex.Ksiazki.Find(id);
            ksiazkaTmp.Nazwa = ksiazka.Nazwa;
            ksiazkaTmp.Opis = ksiazka.Opis;
            ksiazkaTmp.AutorId = Convert.ToInt32(ksiazka.AutorId);
            ksiazkaTmp.WydawnictwoId = Convert.ToInt32(ksiazka.WydawnictwoId);
            ksiazkaTmp.Kategoria = ksiazka.Kategoria;
            _contex.Ksiazki.Update(ksiazkaTmp);
            _contex.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Ksiazki ksiazka = _contex.Ksiazki.Find(id);
            _contex.Ksiazki.Remove(ksiazka);
            _contex.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
