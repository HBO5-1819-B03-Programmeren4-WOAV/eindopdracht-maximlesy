using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using CaveBase.WebAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories
{
    public class DifficultyRatingRepository : Repository<DifficultyRating>
    {
        public DifficultyRatingRepository(CaveServiceContext context) : base(context) { }

        public async Task<List<DifficultyRating>> GetAllFullAsList()
        {
            return await GetAll().Include(dr => dr.Cave)
                                 .Include(dr => dr.Caver)
                                 .ToListAsync();
        }
    }
}
