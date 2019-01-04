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
            //OLD CODE TO MAP
            //return await database.Caves
            //               .Select(c => new CaveBasic { Id = c.Id, Name = c.Name, Description = c.Description})
            //               .ToListAsync();

            //CODE USING AUTOMAPPER
            return await database.Caves.ProjectTo<CaveBasic>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<CaveDetail> GetCaveDetailById(int id)
        {
            return await database.Caves.Select
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
                    ClubId = c.Club.Id,
                    ClubName = c.Club.Name,
                    CountryId = c.Country.Id,
                    CountryName = c.Country.Name,
                    PhotoName = c.PhotoName
                }
                )
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
