using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class Adres
    {
        public int Id { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string KodPocztowy { get; set; }

        //Relacje
        public int CzytelnikId { get; set; }
        public Czytelnik Czytelnik { get; set; }


    }
}
