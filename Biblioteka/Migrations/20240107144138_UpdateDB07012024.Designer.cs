﻿// <auto-generated />
using Biblioteka.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteka.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240107144138_UpdateDB07012024")]
    partial class UpdateDB07012024
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biblioteka.Models.Adres", b =>
                {
                    b.Property<int>("AdresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdresId"));

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdresId");

                    b.ToTable("Adres");
                });

            modelBuilder.Entity("Biblioteka.Models.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutorId"));

                    b.Property<string>("Biografia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImieNazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zdjecie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutorId");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("Biblioteka.Models.Czytelnik", b =>
                {
                    b.Property<int>("CzytelnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CzytelnikId"));

                    b.Property<int>("AdresId")
                        .HasColumnType("int");

                    b.Property<string>("ImieNazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerKarty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusCzytelnika")
                        .HasColumnType("int");

                    b.HasKey("CzytelnikId");

                    b.HasIndex("AdresId");

                    b.ToTable("Czytelnik");
                });

            modelBuilder.Entity("Biblioteka.Models.Czytelnik_Ksiazka", b =>
                {
                    b.Property<int>("CzytelnikId")
                        .HasColumnType("int");

                    b.Property<int>("KsiazkaId")
                        .HasColumnType("int");

                    b.HasKey("CzytelnikId", "KsiazkaId");

                    b.HasIndex("KsiazkaId");

                    b.ToTable("Czytelnik_Ksiazka");
                });

            modelBuilder.Entity("Biblioteka.Models.Ksiazki", b =>
                {
                    b.Property<int>("KsiazkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KsiazkaId"));

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("Kategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WydawnictwoId")
                        .HasColumnType("int");

                    b.HasKey("KsiazkaId");

                    b.HasIndex("AutorId");

                    b.HasIndex("WydawnictwoId");

                    b.ToTable("Ksiazki");
                });

            modelBuilder.Entity("Biblioteka.Models.Wydawnictwo", b =>
                {
                    b.Property<int>("WydawnictwoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WydawnictwoId"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WydawnictwoId");

                    b.ToTable("Wydawnictwo");
                });

            modelBuilder.Entity("Biblioteka.Models.Czytelnik", b =>
                {
                    b.HasOne("Biblioteka.Models.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adres");
                });

            modelBuilder.Entity("Biblioteka.Models.Czytelnik_Ksiazka", b =>
                {
                    b.HasOne("Biblioteka.Models.Czytelnik", "Czytelnik")
                        .WithMany("Czytelnicy_Ksiazki")
                        .HasForeignKey("CzytelnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteka.Models.Ksiazki", "Ksiazka")
                        .WithMany("Czytelnicy_Ksiazki")
                        .HasForeignKey("KsiazkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Czytelnik");

                    b.Navigation("Ksiazka");
                });

            modelBuilder.Entity("Biblioteka.Models.Ksiazki", b =>
                {
                    b.HasOne("Biblioteka.Models.Autor", "Autor")
                        .WithMany("Ksiazki")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteka.Models.Wydawnictwo", "Wydawnictwo")
                        .WithMany()
                        .HasForeignKey("WydawnictwoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Wydawnictwo");
                });

            modelBuilder.Entity("Biblioteka.Models.Autor", b =>
                {
                    b.Navigation("Ksiazki");
                });

            modelBuilder.Entity("Biblioteka.Models.Czytelnik", b =>
                {
                    b.Navigation("Czytelnicy_Ksiazki");
                });

            modelBuilder.Entity("Biblioteka.Models.Ksiazki", b =>
                {
                    b.Navigation("Czytelnicy_Ksiazki");
                });
#pragma warning restore 612, 618
        }
    }
}
