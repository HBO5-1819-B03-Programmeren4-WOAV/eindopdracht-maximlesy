using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Controllers.Generic;
using CaveBase.WebAPI.Database;
using CaveBase.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyRatingsController : GenericCrudController<DifficultyRating, DifficultyRatingRepository>
    {
        //Pass onto generic controller
        public DifficultyRatingsController(DifficultyRatingRepository repo) : base(repo) { }

        //[HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repo.GetAllFullAsList());
        }
    }
}