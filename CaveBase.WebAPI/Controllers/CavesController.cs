﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        [Route("ImageById/{caveId}")]
        public async Task<IActionResult> ImageById(int caveId)
        {
            CaveDetail cave = await repo.GetCaveDetailById(caveId);
            return GetImageByFileName(cave.PhotoName);
        }
    }
}