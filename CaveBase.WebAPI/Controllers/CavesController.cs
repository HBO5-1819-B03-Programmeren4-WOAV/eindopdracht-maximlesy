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
        public IActionResult ImageById(int caveId)
        {
            CaveDetail cave = repo.GetById(caveId);
            return GetImageByFileName(cave.PhotoName);
        }
    }
}