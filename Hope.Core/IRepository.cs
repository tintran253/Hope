using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hope.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object Id);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        IQueryable<T> Table { get; }
    }

}
