using Hope.Core;
using System.Collections.Generic;
using System.Text;

namespace Hope.Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAll();
        Article GetById(int id);
        void Add(Article article);
        void Edit(Article article);
        bool Delete(int id);
    }
}
