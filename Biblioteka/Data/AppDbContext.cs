using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;


namespace Biblioteka.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Czytelnik_Ksiazka>().HasKey(ck => new
            {
                ck.CzytelnikId,
                ck.KsiazkaId
            });

            modelBuilder.Entity<Czytelnik_Ksiazka>().HasOne(k => k.Ksiazka).WithMany(ck => ck.Czytelnicy_Ksiazki).HasForeignKey(k => k.KsiazkaId);
            modelBuilder.Entity<Czytelnik_Ksiazka>().HasOne(c => c.Czytelnik).WithMany(ck => ck.Czytelnicy_Ksiazki).HasForeignKey(c => c.CzytelnikId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Czytelnik> Czytelnik { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Ksiazki> Ksiazki { get; set; }
        public DbSet<Czytelnik_Ksiazka> Czytelnik_Ksiazka { get; set; }
        public DbSet<Wydawnictwo> Wydawnictwo { get; set; }




    }
}
