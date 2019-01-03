using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories
{
    public class CountryRepository
    {
        private CaveServiceContext database;

        public CountryRepository(CaveServiceContext context)
        {
            database = context;
        }

        public List<Country> All()
        {
            return database.Countries.ToList();
        }

        public Country GetById(int id)
        {
            return database.Countries.FirstOrDefault(c => c.Id == id);
        }

    }
}
