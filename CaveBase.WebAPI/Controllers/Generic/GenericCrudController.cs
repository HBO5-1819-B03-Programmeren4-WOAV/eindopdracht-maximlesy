using CaveBase.Library.Models;
using CaveBase.WebAPI.Repositories.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Controllers.Generic
{
    public class GenericCrudController<T, R> : ControllerBase where T : EntityBase
                                                              where R : Repository<T>
    {
        //fields
        protected R repo;

        public GenericCrudController(R repo)
        {
            this.repo = repo;
        }

        //GET: api/{controllerName}
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(await repo.ListAll());
        }

        //GET: api/{controllerName}/{id}
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await repo.GetById(id));
        }

        //POST: api/{controllerName}
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            T addEntity = await repo.Add(entity);
            if (addEntity == null) return NotFound();

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        //PUT: api/{controllerName}/{id}
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromBody] T entity, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (entity.Id != id) return BadRequest();

            T updateEntity = await repo.Update(entity);
            if (updateEntity == null) return NotFound();

            return Ok(updateEntity);
        }

        //DELETE: api/{controllerName}/{id}
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var deletedEntity = await repo.Delete(id);
            if (deletedEntity == null) return NotFound();

            return Ok(deletedEntity);
        }
    }
}
