using CaveBase.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Database
{
    public class CaveServiceContext : DbContext
    {
        public DbSet<Cave> Caves { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Caver> Cavers { get; set; }
        public DbSet<DifficultyRating> DifficultyRatings { get; set; }

        public CaveServiceContext(DbContextOptions<CaveServiceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Club>()
                        .ToTable("Clubs")
                        .HasData(
                        new Club {
                            Id = 1,
                            Name = "Speleo Cascade",
                            Created = DateTime.Now,
                            City = "Oostende",
                            Streetname = "Koebrugstraat",
                            Housenumber = 22,
                            PostalCode = 8250
                        },

                        new Club
                        {
                            Id = 2,
                            Name = "Speleo IVO",
                            Created = DateTime.Now,
                            City = "Brugge",
                            Streetname = "Nijverheidslaan",
                            Housenumber = 33,
                            PostalCode = 8000
                        }
                        );

            modelbuilder.Entity<Caver>()
                        .ToTable("Cavers")
                        .HasData(
                            new Caver { Id = 1, FirstName = "Maxim", LastName = "Lesy" },
                            new Caver { Id = 2, FirstName = "Evi", LastName = "De Baets" },
                            new Caver { Id = 3, FirstName = "Charlotte", LastName = "Janssens" });

            modelbuilder.Entity<DifficultyRating>()
                        .ToTable("DifficultyRatings")
                        .HasData(
                            new DifficultyRating { Id = 1, CaveId = 1, CaverId = 1, Difficulty = Difficulty.Expert },
                            new DifficultyRating { Id = 2, CaveId = 1, CaverId = 2, Difficulty = Difficulty.Normal },
                            new DifficultyRating { Id = 3, CaveId = 1, CaverId = 3, Difficulty = Difficulty.Easy },
                            new DifficultyRating { Id = 4, CaveId = 2, CaverId = 1, Difficulty = Difficulty.Difficult },
                            new DifficultyRating { Id = 5, CaveId = 2, CaverId = 3, Difficulty = Difficulty.Easy },
                            new DifficultyRating { Id = 6, CaveId = 2, CaverId = 3, Difficulty = Difficulty.Normal },
                            new DifficultyRating { Id = 7, CaveId = 3, CaverId = 1, Difficulty = Difficulty.Easy },
                            new DifficultyRating { Id = 8, CaveId = 3, CaverId = 2, Difficulty = Difficulty.Expert },
                            new DifficultyRating { Id = 9, CaveId = 3, CaverId = 1, Difficulty = Difficulty.Easy }
                );

            modelbuilder.Entity<Country>()
                        .ToTable("Countries")
                        .HasData(
                        new {
                            Id = 1,
                            Created = DateTime.Now,
                            Name = "Belgium",
                            ShortName = "BE"
                        }
                        );

            modelbuilder.Entity<Cave>()
            .ToTable("Caves")
            .HasData(
                new
                {
                    Id = 1,
                    Name = "Fosse Sin Sin",
                    CountryId = 1,
                    Depth = 100,
                    Description = "Awesome cave!",
                    Created = DateTime.Now,
                    Difficulty = Difficulty.Difficult,
                    IsDivingCave = true,
                    HasFormations = true,
                    Latitude = 30.343432,
                    Longitude = 3.238184,
                    Length = 123,
                    ClubId = 1,
                    PhotoName = "caveimg1.jpg"
                },

                new
                {
                    Id = 2,
                    Name = "Fosse Aux Ours",
                    CountryId = 1,
                    Depth = 130,
                    Description = "Bears!",
                    Created = DateTime.Now,
                    Difficulty = Difficulty.Easy,
                    IsDivingCave = false,
                    HasFormations = false,
                    Latitude = 33.433488,
                    Longitude = 8.594100,
                    Length = 123,
                    ClubId = 1,
                    PhotoName = "caveimg2.jpg"
                },

                new
                {
                    Id = 3,
                    Name = "Grottes de Han",
                    CountryId = 1,
                    Depth = 4130,
                    Description = "Big cave!",
                    Created = DateTime.Now,
                    Difficulty = Difficulty.Medium,
                    IsDivingCave = false,
                    HasFormations = true,
                    Latitude = 1.777777,
                    Longitude = 2.777777,
                    Length = 1623,
                    ClubId = 2,
                    PhotoName = "caveimg3.jpg"
                }
                );

            modelbuilder.Entity<Cave>()
                        .Property(p => p.Created)
                        .HasDefaultValueSql("GETDATE()")
                        .ValueGeneratedOnAddOrUpdate();

            modelbuilder.Entity<Country>()
                        .Property(p => p.Created)
                        .HasDefaultValueSql("GETDATE()")
                        .ValueGeneratedOnAddOrUpdate();

            modelbuilder.Entity<Club>()
                        .Property(p => p.Created)
                        .HasDefaultValueSql("GETDATE()")
                        .ValueGeneratedOnAddOrUpdate();

            modelbuilder.Entity<Caver>()
                        .Property(p => p.Created)
                        .HasDefaultValueSql("GETDATE()")
                        .ValueGeneratedOnAddOrUpdate();

            modelbuilder.Entity<DifficultyRating>()
                        .Property(p => p.Created)
                        .HasDefaultValueSql("GETDATE()")
                        .ValueGeneratedOnAddOrUpdate();
        }
    }
}
