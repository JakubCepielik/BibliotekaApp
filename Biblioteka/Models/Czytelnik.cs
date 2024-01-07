using Biblioteka.Data.Enums;

namespace Biblioteka.Models
{
    public class Czytelnik
    {
        public int CzytelnikId { get; set; }
        public string ImieNazwisko { get; set; }
        public string NumerKarty { get; set; }
        public string Email { get; set; }
        public StatusCzytelnika StatusCzytelnika { get; set; }

        //Relacje

        public int AdresId { get; set; }
        public Adres Adres { get; set; }

        public List<Czytelnik_Ksiazka> Czytelnicy_Ksiazki { get; set;}
    }
}
