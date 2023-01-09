﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB.Data;

namespace WEB.Migrations
{
    [DbContext(typeof(WEBContext))]
    [Migration("20230109204738_ins")]
    partial class ins
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WEB.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumeCategorie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("WEB.Models.CategorieSport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("SportID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("SportID");

                    b.ToTable("CategorieSport");
                });

            modelBuilder.Entity("WEB.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Experienta")
                        .HasColumnType("int");

                    b.Property<int?>("InstructorID")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Varsta")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("WEB.Models.Locatie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeSala")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oras")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Locatie");
                });

            modelBuilder.Entity("WEB.Models.Sport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Durata")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("InstructorID")
                        .HasColumnType("int");

                    b.Property<int?>("LocatieID")
                        .HasColumnType("int");

                    b.Property<string>("NumeSport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("InstructorID");

                    b.HasIndex("LocatieID");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("WEB.Models.CategorieSport", b =>
                {
                    b.HasOne("WEB.Models.Categorie", "Categorie")
                        .WithMany("CategoriiSport")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEB.Models.Sport", "Sport")
                        .WithMany("CategoriiSport")
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("WEB.Models.Instructor", b =>
                {
                    b.HasOne("WEB.Models.Instructor", null)
                        .WithMany("Instructori")
                        .HasForeignKey("InstructorID");
                });

            modelBuilder.Entity("WEB.Models.Sport", b =>
                {
                    b.HasOne("WEB.Models.Instructor", "Instructor")
                        .WithMany("Sporturi")
                        .HasForeignKey("InstructorID");

                    b.HasOne("WEB.Models.Locatie", "Locatie")
                        .WithMany("Sporturi")
                        .HasForeignKey("LocatieID");

                    b.Navigation("Instructor");

                    b.Navigation("Locatie");
                });

            modelBuilder.Entity("WEB.Models.Categorie", b =>
                {
                    b.Navigation("CategoriiSport");
                });

            modelBuilder.Entity("WEB.Models.Instructor", b =>
                {
                    b.Navigation("Instructori");

                    b.Navigation("Sporturi");
                });

            modelBuilder.Entity("WEB.Models.Locatie", b =>
                {
                    b.Navigation("Sporturi");
                });

            modelBuilder.Entity("WEB.Models.Sport", b =>
                {
                    b.Navigation("CategoriiSport");
                });
#pragma warning restore 612, 618
        }
    }
}
