using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Controllers.Generic;
using CaveBase.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CavesController : GenericCrudController<Cave, CaveRepository>
    {
        //Pass onto generic controller
        public CavesController(CaveRepository repo) : base(repo) { }

        // GET: api/caves
        [HttpGet]
        public override async Task<IActionResult> Get()
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

        //GET: api/caves/detailed/{id}
        [HttpGet]
        [Route("detailed/{id}")]
        public async Task<IActionResult> GetCaveDetailedById(int id)
        {
            return Ok(await repo.GetCaveDetailById(id));
        }

        [HttpGet]
        [Route("stats")]
        public async Task<IActionResult> GetAllCaveStats()
        {
            return Ok(await repo.GetAllCaveStatsAsList());
        }

        // GET: api/caves/imagebyname/{filename}
        [HttpGet]
        [Route("imagebyname/{filename}")]
        public IActionResult GetImageByFileName(string filename)
        {
            var image = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", filename);
            return PhysicalFile(image, "image/jpeg");
        }

        // GET: api/caves/imagebyid/{caveId}
        [HttpGet]
        [Route("imagebyid/{caveId}")]
        public async Task<IActionResult> ImageById(int caveId)
        {
            CaveDetail cave = await repo.GetCaveDetailById(caveId);
            return GetImageByFileName(cave.PhotoName);
        }

        //POST: api/caves/upload/image
        [HttpPost]
        [Route("upload/image")]
        public async Task<IActionResult> UploadImage(IFormFile uploadImg)
        {
            //create a unique identifier
            var ticks = new DateTime(2000, 1, 1).Ticks;
            var ans = DateTime.Now.Ticks - ticks;
            string uniqueId = ans.ToString("X"); //to hex notation

            string uniqueName = $"{uniqueId}{uploadImg.FileName}";

            //uploadImg or fileName could be null
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", uniqueName);

                if (uploadImg.Length > 0)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await uploadImg.CopyToAsync(stream);
                    }
                }
            }
            catch
            {
                Console.Write("Image could not be uploaded.");
                return BadRequest(new { success = false });
            }
            return Ok(new { filename = uniqueName, sizeInBytes = uploadImg.Length, success = true });
        }

    }
}