using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveBase.Library.Models;
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
        public async Task<IActionResult> GetClubs()
        {
            return Ok(await repo.ListAll());
        }

        //GET: api/clubs/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClubById(int id)
        {
            return Ok(await repo.GetById(id));
        }

        //PUT: api/clubs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClub([FromRoute] int id, [FromBody] Club club)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != club.Id) return BadRequest();

            Club updatedClub = await repo.Update(club);
            if (updatedClub == null) return NotFound();
            return Ok(updatedClub);
        }

        //POST: api/clubs
        [HttpPost]
        public async Task<IActionResult> PostClub([FromBody] Club club)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await repo.Add(club);

            return CreatedAtAction("GetClubById", new { id = club.Id }, club);
        }

        //DELETE: api/clubs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Club deleteClub = await repo.Delete(id);

            if (deleteClub == null) return NotFound();
            return Ok(deleteClub);
        }

    }
}