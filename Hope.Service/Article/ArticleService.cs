using System;
using System.Collections.Generic;
using System.Text;
using Hope.Core;

namespace Hope.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRepository;

        public ArticleService(IRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public void Add(Article article)
        {
            _articleRepository.Insert(article);
        }

        public bool Delete(int id)
        {
            var entity = this._articleRepository.GetById(id);
            this._articleRepository.Delete(entity);
            return true;
        }

        public void Edit(Article article)
        {
            this._articleRepository.Update(article);
        }

        public IEnumerable<Article> GetAll()
        {
            return this._articleRepository.GetAll();
        }

        public Article GetById(int id)
        {
            return this._articleRepository.GetById(id);
        }
    }
}
