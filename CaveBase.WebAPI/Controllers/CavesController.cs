using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CaveBase.Library.DTO;
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
        public async Task<IActionResult> GetCaves()
        {
            return Ok(await repo.GetAllFullAsList());
        }

        //GET: api/caves/basic
        [HttpGet]
        [Route("basic")]
        public async Task<IActionResult> GetAllBasic()
        {
            return Ok(await repo.GetAllBasicAsList());
        }

        //GET: api/caves/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCaveById(int id)
        {
            return Ok(await repo.GetById(id));
        }

        // GET: api/caves/imagebyname/{filename}
        [HttpGet]
        [Route("imagebyname/{filename}")]
        public IActionResult GetImageByFileName(string filename)
        {
            var image = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", filename);
            return PhysicalFile(image, "image/jpg");
        }

        // GET: api/caves/imagebyid/{caveId}
        [HttpGet]
        [Route("ImageById/{caveId}")]
        public async Task<IActionResult> ImageById(int caveId)
        {
            CaveDetail cave = await repo.GetCaveDetailById(caveId);
            return GetImageByFileName(cave.PhotoName);
        }
    }
}