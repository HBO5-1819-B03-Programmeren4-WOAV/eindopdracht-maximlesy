using CaveBase.Library.Models;
using CaveBase.WebAPI.Controllers.Generic;
using CaveBase.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : GenericCrudController<Country, CountryRepository>
    {
        //Pass onto generic controller
        public CountriesController(CountryRepository repo) : base(repo) { }
    }
}