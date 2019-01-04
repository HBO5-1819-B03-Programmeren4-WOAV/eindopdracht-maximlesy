using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Controllers.Generic;
using CaveBase.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : GenericCrudController<Club, ClubRepository>
    {
        //Pass onto generic controller
        public ClubsController(ClubRepository repo) : base(repo) { }

        [HttpGet("basic")]
        public async Task<IActionResult> GetClubsBasic()
        {
            return Ok(await repo.ListBasic());
        }
    }
}