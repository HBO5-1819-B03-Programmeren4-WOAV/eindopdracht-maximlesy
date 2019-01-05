using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using CaveBase.WebAPI.Repositories.Generic;

namespace CaveBase.WebAPI.Repositories
{
    public class CountryRepository : Repository<Country>
    {
        public CountryRepository(CaveServiceContext context) : base(context) { }
    }
}
