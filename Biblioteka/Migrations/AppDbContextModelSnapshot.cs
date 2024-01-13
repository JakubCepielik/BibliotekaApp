﻿// <auto-generated />
using Biblioteka.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteka.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biblioteka.Models.Adres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CzytelnikId")
                        .HasColumnType("int");

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CzytelnikId")
                        .IsUnique();

                    b.ToTable("Adres");
                });

            modelBuilder.Entity("Biblioteka.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biografia")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImieNazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Autorzy");
                });

            modelBuilder.Entity("Biblioteka.Models.Czytelnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImieNazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumerKarty")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("StatusCzytelnika")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Czytelnicy");
                });

            modelBuilder.Entity("Biblioteka.Models.Ksiazki", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("Kategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("WydawnictwoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("WydawnictwoId");

                    b.ToTable("Ksiazki");
                });

            modelBuilder.Entity("Biblioteka.Models.Wydawnictwo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Wydawnictwa");
                });

            modelBuilder.Entity("CzytelnikKsiazki", b =>
                {
                    b.Property<int>("CzytelnicyId")
                        .HasColumnType("int");

                    b.Property<int>("KsiazkiId")
                        .HasColumnType("int");

                    b.HasKey("CzytelnicyId", "KsiazkiId");

                    b.HasIndex("KsiazkiId");

                    b.ToTable("CzytelnikKsiazki");
                });

            modelBuilder.Entity("Biblioteka.Models.Adres", b =>
                {
                    b.HasOne("Biblioteka.Models.Czytelnik", "Czytelnik")
                        .WithOne("Adres")
                        .HasForeignKey("Biblioteka.Models.Adres", "CzytelnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Czytelnik");
                });

            modelBuilder.Entity("Biblioteka.Models.Ksiazki", b =>
                {
                    b.HasOne("Biblioteka.Models.Autor", "Autor")
                        .WithMany("Ksiazki")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteka.Models.Wydawnictwo", "Wydawnictwo")
                        .WithMany("Ksiazki")
                        .HasForeignKey("WydawnictwoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Wydawnictwo");
                });

            modelBuilder.Entity("CzytelnikKsiazki", b =>
                {
                    b.HasOne("Biblioteka.Models.Czytelnik", null)
                        .WithMany()
                        .HasForeignKey("CzytelnicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteka.Models.Ksiazki", null)
                        .WithMany()
                        .HasForeignKey("KsiazkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Biblioteka.Models.Autor", b =>
                {
                    b.Navigation("Ksiazki");
                });

            modelBuilder.Entity("Biblioteka.Models.Czytelnik", b =>
                {
                    b.Navigation("Adres")
                        .IsRequired();
                });

            modelBuilder.Entity("Biblioteka.Models.Wydawnictwo", b =>
                {
                    b.Navigation("Ksiazki");
                });
#pragma warning restore 612, 618
        }
    }
}
