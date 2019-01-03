﻿// <auto-generated />
using System;
using CaveBase.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaveBase.WebAPI.Migrations
{
    [DbContext(typeof(CaveServiceContext))]
    [Migration("20190103132741_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("CountryId");

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

                    b.Property<int?>("ResponsibleClubId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("ResponsibleClubId");

                    b.ToTable("Caves");

                    b.HasData(
                        new { Id = 1, CountryId = 1, Created = new DateTime(2019, 1, 3, 14, 27, 41, 477, DateTimeKind.Local), Depth = 100, Description = "Awesome cave!", Difficulty = 4, HasFormations = true, IsDivingCave = true, Latitude = 30.343432, Length = 123, Longitude = 3.238184, Name = "Fosse Sin Sin", PhotoName = "caveimg1.jpg", ResponsibleClubId = 1 },
                        new { Id = 2, CountryId = 1, Created = new DateTime(2019, 1, 3, 14, 27, 41, 479, DateTimeKind.Local), Depth = 130, Description = "Bears!", Difficulty = 1, HasFormations = false, IsDivingCave = false, Latitude = 33.433488, Length = 123, Longitude = 8.5941, Name = "Fosse Aux Ours", PhotoName = "caveimg2.jpg", ResponsibleClubId = 1 },
                        new { Id = 3, CountryId = 1, Created = new DateTime(2019, 1, 3, 14, 27, 41, 479, DateTimeKind.Local), Depth = 4130, Description = "Big cave!", Difficulty = 3, HasFormations = true, IsDivingCave = false, Latitude = 1.777777, Length = 1623, Longitude = 2.777777, Name = "Grottes de Han", PhotoName = "caveimg3.jpg", ResponsibleClubId = 2 }
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
                        new { Id = 1, City = "Oostende", Created = new DateTime(2019, 1, 3, 14, 27, 41, 479, DateTimeKind.Local), Housenumber = 22, Name = "Speleo Cascade", PostalCode = 8250, Streetname = "Koebrugstraat" },
                        new { Id = 2, City = "Brugge", Created = new DateTime(2019, 1, 3, 14, 27, 41, 480, DateTimeKind.Local), Housenumber = 33, Name = "Speleo IVO", PostalCode = 8000, Streetname = "Nijverheidslaan" }
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
                        new { Id = 1, Created = new DateTime(2019, 1, 3, 14, 27, 41, 480, DateTimeKind.Local), Name = "Belgium", ShortName = "BE" }
                    );
                });

            modelBuilder.Entity("CaveBase.Library.Models.Cave", b =>
                {
                    b.HasOne("CaveBase.Library.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("CaveBase.Library.Models.Club", "ResponsibleClub")
                        .WithMany()
                        .HasForeignKey("ResponsibleClubId");
                });
#pragma warning restore 612, 618
        }
    }
}
