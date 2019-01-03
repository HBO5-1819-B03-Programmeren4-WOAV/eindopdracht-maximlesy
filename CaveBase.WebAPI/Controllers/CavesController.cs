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
    public class CavesController : ControllerBase
    {
        private CaveRepository repo;

        public CavesController(CaveRepository repo) { this.repo = repo; }

        //GET: api/caves
        [HttpGet]
        public IActionResult GetCaves()
        {
            return Ok(repo.All());
        }

        //GET: api/caves/basic
        [HttpGet]
        [Route("basic")]
        public IActionResult GetAllBasic()
        {
            return Ok(repo.AllBasic());
        }

        //GET: api/caves/{id}
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCaveById(int id)
        {
            return Ok(repo.GetById(id));
        }
    }
}