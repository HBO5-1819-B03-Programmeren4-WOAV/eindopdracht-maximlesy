using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories
{
    public class CaveRepository
    {
        private CaveServiceContext database;

        public CaveRepository(CaveServiceContext context)
        {
            database = context;
        }

        public List<Cave> All()
        {
            return database.Caves
                           .Include(c => c.Country)
                           .Include(c => c.ResponsibleClub)
                           .ToList();
        }

        public List<CaveBasic> AllBasic()
        {
            return database.Caves
                           .Select(c => new CaveBasic { Id = c.Id, Name = c.Name, Description = c.Description})
                           .ToList();
        }

        public CaveDetail GetById(int id)
        {
            return database.Caves.Select
                (c => new CaveDetail
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Longitude = c.Longitude,
                    Latitude = c.Latitude,
                    Depth = c.Depth,
                    Length = c.Length,
                    IsDivingCave = c.IsDivingCave,
                    HasFormations = c.HasFormations,
                    Difficulty = c.Difficulty,
                    ClubId = c.ResponsibleClub.Id,
                    ClubName = c.ResponsibleClub.Name,
                    CountryId = c.Country.Id,
                    CountryName = c.Country.Name
                }
                )
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
