using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string ImieNazwisko { get; set; }
        public string Zdjecie { get; set; }
        public string Biografia { get; set;}

        //Relacje
        public List<Ksiazki> Ksiazki { get; set; }


    }
}
