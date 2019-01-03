using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using CaveBase.WebAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories
{
    public class ClubRepository : Repository<Club>
    {
        public ClubRepository(CaveServiceContext context) : base(context){ }

        public async Task<List<ClubBasic>> ListBasic()
        {
            var clubs = await database.Clubs.Select
                (c => new ClubBasic
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City
                }
                )
                .ToListAsync();

            return clubs;
        }
    }
}
