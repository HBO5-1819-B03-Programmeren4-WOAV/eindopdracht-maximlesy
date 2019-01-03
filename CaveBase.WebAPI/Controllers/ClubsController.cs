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
    public class ClubsController : ControllerBase
    {
        ClubRepository repo;

        public ClubsController(ClubRepository repo)
        {
            this.repo = repo;
        }

        //GET: api/clubs
        [HttpGet]
        public IActionResult GetClubs()
        {
            return Ok(repo.All());
        }

        //GET: api/clubs/basic
        [HttpGet]
        [Route("basic")]
        public IActionResult GetClubsBasic()
        {
            return Ok(repo.AllBasic());
        }

        //GET: api/clubs/{id}
        [HttpGet("{id}")]
        public IActionResult GetClubById(int id)
        {
            return Ok(repo.GetById(id));
        }
    }
}