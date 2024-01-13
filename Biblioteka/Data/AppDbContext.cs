using Biblioteka.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;


namespace Biblioteka.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Czytelnik> Czytelnicy { get; set; }
        public DbSet<Autor> Autorzy { get; set; }
        public DbSet<Ksiazki> Ksiazki { get; set; }
        public DbSet<Wydawnictwo> Wydawnictwa { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ksiazki>(k =>
            {
                k.Property(x => x.Nazwa).IsRequired().HasColumnType("nvarchar(100)");
                k.Property(x => x.Opis).HasColumnType("nvarchar(1000)");
                k.Property(x => x.Kategoria).IsRequired();
            }
            );
            modelBuilder.Entity<Ksiazki>(k => k.HasMany(x => x.Czytelnicy).WithMany(x => x.Ksiazki));

            modelBuilder.Entity<Adres>(a =>
            {
                a.Property(x => x.Miasto).IsRequired().HasColumnType("nvarchar(50)");
                a.Property(x => x.Ulica).IsRequired().HasColumnType("nvarchar(100)");
                a.Property(x => x.KodPocztowy).IsRequired().HasColumnType("varchar(6)");

            }
            );

            modelBuilder.Entity<Autor>(at =>
            {
                at.Property(x => x.ImieNazwisko).IsRequired().HasColumnType("nvarchar(50)");
                at.Property(x => x.Biografia).HasColumnType("nvarchar(1000)");
                at.HasMany(x => x.Ksiazki).WithOne(x => x.Autor).HasForeignKey(x => x.AutorId);
            }
            );

            modelBuilder.Entity<Czytelnik>(c =>
            {
                c.Property(x => x.ImieNazwisko).IsRequired().HasColumnType("nvarchar(50)");
                c.Property(x => x.NumerKarty).IsRequired().HasColumnType("varchar(10)");
                c.Property(x => x.Email).IsRequired().HasColumnType("varchar(50)");
                c.Property(x => x.StatusCzytelnika).IsRequired();
                c.HasOne(x => x.Adres).WithOne(x => x.Czytelnik).HasForeignKey<Adres>(x => x.CzytelnikId);
            }
            );

            modelBuilder.Entity<Wydawnictwo>(w =>
            {
                w.Property(x => x.Nazwa).IsRequired().HasColumnType("nvarchar(100)");
                w.HasMany(x => x.Ksiazki).WithOne(x => x.Wydawnictwo).HasForeignKey(x => x.WydawnictwoId);
            }
            );

            base.OnModelCreating(modelBuilder);

        }





    }
}
