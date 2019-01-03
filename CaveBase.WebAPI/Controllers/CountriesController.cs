using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveBase.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        CountryRepository repo;

        public CountriesController(CountryRepository repo)
        {
            this.repo = repo;
        }

        //GET: api/countries
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await repo.ListAll());
        }

        //GET: api/countries/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            return Ok(await repo.GetById(id));
        }
    }
}