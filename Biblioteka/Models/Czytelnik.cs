using Biblioteka.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class Czytelnik
    {
        public int Id { get; set; }
        public string ImieNazwisko { get; set; }
        public string NumerKarty { get; set; }
        public string Email { get; set; }
        public StatusCzytelnika StatusCzytelnika { get; set; }

        //Relacje
        public Adres Adres { get; set; }

        public List<Ksiazki> Ksiazki { get; set; }
    }
}
