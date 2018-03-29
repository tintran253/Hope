using System;
using System.Collections.Generic;
using Hope.Core;
using Hope.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/Composers")]
    public class ComposersController : Controller
    {
        private readonly IComposerService _composerService;
        public ComposersController(IComposerService composerService)
        {
            _composerService = composerService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._composerService.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Composer Get(int id)
        {
            return this._composerService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
