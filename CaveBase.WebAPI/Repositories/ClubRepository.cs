using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class ClubRepository : MappingRepository<Club>
    {
        public ClubRepository(CaveServiceContext context, IMapper mapper) : base(context, mapper){ }

        public async Task<List<ClubBasic>> ListBasic()
        {
            return await database.Clubs.ProjectTo<ClubBasic>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
