using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hope.Core;
using Hope.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hope.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IComposerService _composerService;
        public ValuesController(IComposerService composerService)
        {
            _composerService = composerService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
