using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class Wydawnictwo
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        //Relacje
        public List<Ksiazki> Ksiazki { get; set; }
    }
}
