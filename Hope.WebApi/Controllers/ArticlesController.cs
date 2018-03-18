using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hope.Core;
using Hope.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hope.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Articles")]
    public class ArticlesController : Controller
    {
        private readonly IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return _articleService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Article Get(int id)
        {
            return this._articleService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post(Article article)
        {
            this._articleService.Add(article);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Article article)
        {
            article.Id = id;
            this._articleService.Edit(article);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this._articleService.Delete(id);
            return Ok();
        }
    }
}