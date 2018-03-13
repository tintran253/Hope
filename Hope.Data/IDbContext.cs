using Hope.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hope.Data
{
    public interface IDbContext
    {
        //DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
