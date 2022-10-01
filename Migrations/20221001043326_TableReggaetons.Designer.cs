﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spotify.Models;

#nullable disable

namespace Spotify.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221001043326_TableReggaetons")]
    partial class TableReggaetons
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Spotify.Models.Bachata", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Spotify")
                        .HasColumnType("longtext");

                    b.Property<string>("artista")
                        .HasColumnType("longtext");

                    b.Property<string>("cancion")
                        .HasColumnType("longtext");

                    b.Property<string>("color")
                        .HasColumnType("longtext");

                    b.Property<string>("imgPrincipal")
                        .HasColumnType("longtext");

                    b.Property<string>("lanzamiento")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Bachatas");
                });

            modelBuilder.Entity("Spotify.Models.Comentario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ReggaetonId")
                        .HasColumnType("int");

                    b.Property<string>("fecha")
                        .HasColumnType("longtext");

                    b.Property<string>("texto")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("ReggaetonId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Spotify.Models.Reggaeton", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Spotify")
                        .HasColumnType("longtext");

                    b.Property<string>("artista")
                        .HasColumnType("longtext");

                    b.Property<string>("cancion")
                        .HasColumnType("longtext");

                    b.Property<string>("color")
                        .HasColumnType("longtext");

                    b.Property<string>("imgPrincipal")
                        .HasColumnType("longtext");

                    b.Property<string>("lanzamiento")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Reggaetons");
                });

            modelBuilder.Entity("Spotify.Models.Salsa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("artista")
                        .HasColumnType("longtext");

                    b.Property<string>("cancion")
                        .HasColumnType("longtext");

                    b.Property<string>("color")
                        .HasColumnType("longtext");

                    b.Property<string>("imgPrincipal")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Salsas");
                });

            modelBuilder.Entity("Spotify.Models.Comentario", b =>
                {
                    b.HasOne("Spotify.Models.Reggaeton", "Reggaeton")
                        .WithMany("Comments")
                        .HasForeignKey("ReggaetonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reggaeton");
                });

            modelBuilder.Entity("Spotify.Models.Reggaeton", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
