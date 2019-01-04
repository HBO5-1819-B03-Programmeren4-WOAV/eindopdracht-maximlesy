﻿// <auto-generated />
using System;
using CaveBase.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaveBase.WebAPI.Migrations
{
    [DbContext(typeof(CaveServiceContext))]
    partial class CaveServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaveBase.Library.Models.Cave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClubId");

                    b.Property<int>("CountryId");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("Depth");

                    b.Property<string>("Description");

                    b.Property<int>("Difficulty");

                    b.Property<bool>("HasFormations");

                    b.Property<bool>("IsDivingCave");

                    b.Property<double>("Latitude");

                    b.Property<int>("Length");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoName");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("CountryId");

                    b.ToTable("Caves");

                    b.HasData(
                        new { Id = 1, ClubId = 1, CountryId = 1, Created = new DateTime(2019, 1, 4, 18, 28, 8, 535, DateTimeKind.Local), Depth = 100, Description = "Awesome cave!", Difficulty = 4, HasFormations = true, IsDivingCave = true, Latitude = 30.343432, Length = 123, Longitude = 3.238184, Name = "Fosse Sin Sin", PhotoName = "caveimg1.jpg" },
                        new { Id = 2, ClubId = 1, CountryId = 1, Created = new DateTime(2019, 1, 4, 18, 28, 8, 535, DateTimeKind.Local), Depth = 130, Description = "Bears!", Difficulty = 1, HasFormations = false, IsDivingCave = false, Latitude = 33.433488, Length = 123, Longitude = 8.5941, Name = "Fosse Aux Ours", PhotoName = "caveimg2.jpg" },
                        new { Id = 3, ClubId = 2, CountryId = 1, Created = new DateTime(2019, 1, 4, 18, 28, 8, 535, DateTimeKind.Local), Depth = 4130, Description = "Big cave!", Difficulty = 3, HasFormations = true, IsDivingCave = false, Latitude = 1.777777, Length = 1623, Longitude = 2.777777, Name = "Grottes de Han", PhotoName = "caveimg3.jpg" }
                    );
                });

            modelBuilder.Entity("CaveBase.Library.Models.Caver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Cavers");

                    b.HasData(
                        new { Id = 1, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), FirstName = "Maxim", LastName = "Lesy" },
                        new { Id = 2, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), FirstName = "Evi", LastName = "De Baets" },
                        new { Id = 3, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), FirstName = "Charlotte", LastName = "Janssens" }
                    );
                });

            modelBuilder.Entity("CaveBase.Library.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("Housenumber");

                    b.Property<string>("Name");

                    b.Property<int>("PostalCode");

                    b.Property<string>("Streetname");

                    b.HasKey("Id");

                    b.ToTable("Clubs");

                    b.HasData(
                        new { Id = 1, City = "Oostende", Created = new DateTime(2019, 1, 4, 18, 28, 8, 532, DateTimeKind.Local), Housenumber = 22, Name = "Speleo Cascade", PostalCode = 8250, Streetname = "Koebrugstraat" },
                        new { Id = 2, City = "Brugge", Created = new DateTime(2019, 1, 4, 18, 28, 8, 534, DateTimeKind.Local), Housenumber = 33, Name = "Speleo IVO", PostalCode = 8000, Streetname = "Nijverheidslaan" }
                    );
                });

            modelBuilder.Entity("CaveBase.Library.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new { Id = 1, Created = new DateTime(2019, 1, 4, 18, 28, 8, 534, DateTimeKind.Local), Name = "Belgium", ShortName = "BE" }
                    );
                });

            modelBuilder.Entity("CaveBase.Library.Models.DifficultyRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaveId");

                    b.Property<int>("CaverId");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("Difficulty");

                    b.HasKey("Id");

                    b.HasIndex("CaveId");

                    b.HasIndex("CaverId");

                    b.ToTable("DifficultyRatings");

                    b.HasData(
                        new { Id = 1, CaveId = 1, CaverId = 1, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), Difficulty = 5 },
                        new { Id = 2, CaveId = 1, CaverId = 2, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), Difficulty = 2 },
                        new { Id = 3, CaveId = 1, CaverId = 3, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), Difficulty = 1 },
                        new { Id = 4, CaveId = 2, CaverId = 1, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), Difficulty = 4 },
                        new { Id = 5, CaveId = 2, CaverId = 3, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), Difficulty = 1 },
                        new { Id = 6, CaveId = 2, CaverId = 3, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), Difficulty = 2 },
                        new { Id = 7, CaveId = 3, CaverId = 1, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), Difficulty = 1 },
                        new { Id = 8, CaveId = 3, CaverId = 2, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), Difficulty = 5 },
                        new { Id = 9, CaveId = 3, CaverId = 1, Created = new DateTime(2019, 1, 4, 18, 28, 8, 816, DateTimeKind.Local), Difficulty = 1 }
                    );
                });

            modelBuilder.Entity("CaveBase.Library.Models.Cave", b =>
                {
                    b.HasOne("CaveBase.Library.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CaveBase.Library.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CaveBase.Library.Models.DifficultyRating", b =>
                {
                    b.HasOne("CaveBase.Library.Models.Cave", "Cave")
                        .WithMany()
                        .HasForeignKey("CaveId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CaveBase.Library.Models.Caver", "Caver")
                        .WithMany("DifficultyRatings")
                        .HasForeignKey("CaverId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
