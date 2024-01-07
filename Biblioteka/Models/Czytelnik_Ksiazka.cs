namespace Biblioteka.Models
{
    public class Czytelnik_Ksiazka
    {
        public int CzytelnikId { get; set; }
        public Czytelnik Czytelnik { get; set; }
        public int KsiazkaId { get; set; }
        public Ksiazki Ksiazka { get; set; } 
    }
}
