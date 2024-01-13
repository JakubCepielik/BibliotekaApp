using Biblioteka.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class Ksiazki
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public KsiazkaKategoria Kategoria { get; set; }

        //Relacje

        public List<Czytelnik> Czytelnicy { get; set; }

        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        public int WydawnictwoId { get; set; }
        public Wydawnictwo Wydawnictwo { get; set; }
    }
}
