using AutoMapper;
using AutoMapper.QueryableExtensions;
using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using CaveBase.WebAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories
{
    public class CaveRepository : MappingRepository<Cave>
    {
        public CaveRepository(CaveServiceContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<List<Cave>> GetAllFullAsList()
        {
            return await GetAll().Include(c => c.Club)
                                 .Include(c => c.Country)
                                 .ToListAsync();
        }

        public async Task<List<CaveBasic>> GetAllBasicAsList()
        {
            return await database.Caves.ProjectTo<CaveBasic>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<CaveStats>> GetAllCaveStatsAsList()
        {
            return await database.Caves.ProjectTo<CaveStats>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<CaveDetail> GetCaveDetailById(int id)
        {
            return mapper.Map<CaveDetail>(await database.Caves
                                                        .Include(c => c.Club)
                                                        .Include(c => c.Country)
                                                        .FirstOrDefaultAsync(c => c.Id == id));
        }
    }
}
