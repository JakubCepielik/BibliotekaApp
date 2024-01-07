using Biblioteka.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class Ksiazki
    {
        public int KsiazkiId { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public KsiazkaKategoria Kategoria { get; set; }

        //Relacje

        public List<Czytelnik_Ksiazka> Czytelnicy_Ksiazki { get; set; }

        public int AutorId { get; set; }
        [ForeignKey("AutorId")]

        public Autor Autor { get; set; }

        public int WydawnictwoId {get; set;}
        [ForeignKey("WydawnictwoId")]
        public Wydawnictwo Wydawnictwo { get; set; }
    }
}
