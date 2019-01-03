using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories
{
    public class ClubRepository
    {
        private CaveServiceContext database;

        public ClubRepository(CaveServiceContext context)
        {
            database = context;
        }

        public List<Club> All()
        {
            return database.Clubs.ToList();
        }

        public List<ClubBasic> AllBasic()
        {
            return database.Clubs.Select
                (c => new ClubBasic
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City
                }
                )
                .ToList();
        }

        public Club GetById(int id)
        {
            return database.Clubs.FirstOrDefault(c => c.Id == id);
        }
    }
}
