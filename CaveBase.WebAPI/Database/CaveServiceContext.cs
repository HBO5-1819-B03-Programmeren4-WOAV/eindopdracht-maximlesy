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

        public CaveServiceContext(DbContextOptions<CaveServiceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
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
                                ResponsibleClubId = 1,
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
                                ResponsibleClubId = 1,
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
                                ResponsibleClubId = 2,
                                PhotoName = "caveimg3.jpg"
                            }

                            );

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


        }
    }
}
