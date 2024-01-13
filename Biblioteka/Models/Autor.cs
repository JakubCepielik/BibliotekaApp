using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string ImieNazwisko { get; set; }
        public string Biografia { get; set; }

        //Relacje
        public List<Ksiazki> Ksiazki { get; set; }


    }
}
