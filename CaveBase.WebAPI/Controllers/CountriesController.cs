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
        public IActionResult GetCountries()
        {
            return Ok(repo.All());
        }

        //GET: api/countries/{id}
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            return Ok(repo.GetById(id));
        }
    }
}