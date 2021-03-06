﻿using System.Threading.Tasks;
using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Controllers.Generic;
using CaveBase.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CaveBase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaversController : GenericCrudController<Caver, CaverRepository>
    {
        //Pass onto generic controller
        public CaversController(CaverRepository repo) : base(repo) { }

        [HttpGet]
        [Route("basic")]
        public async Task<IActionResult> GetAllBasic()
        {
            return Ok(await repo.GetAllBasicAsList());
        }

        [HttpGet]
        [Route("basic/{id}")]
        public async Task<IActionResult> GetBasic(int id)
        {
            return Ok(await repo.GetBasicCaver(id));
        }

    }
}