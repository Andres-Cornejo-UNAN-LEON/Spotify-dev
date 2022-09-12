﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spotify.Models;

#nullable disable

namespace Spotify.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}
