using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using CaveBase.WebAPI.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories
{
    public class CountryRepository : Repository<Country>
    {
        public CountryRepository(CaveServiceContext context) : base(context) { }
    }
}
