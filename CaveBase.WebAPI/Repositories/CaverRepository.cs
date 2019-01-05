using AutoMapper;
using AutoMapper.QueryableExtensions;
using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using CaveBase.WebAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories
{
    public class CaverRepository : MappingRepository<Caver>
    {
        public CaverRepository(CaveServiceContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<List<CaverBasic>> GetAllBasicAsList()
        {
            return await database.Cavers.ProjectTo<CaverBasic>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
