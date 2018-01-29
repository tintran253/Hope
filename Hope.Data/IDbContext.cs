using Hope.Core;
using System.Collections.Generic;
using System.Data.Entity;

namespace Hope.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
