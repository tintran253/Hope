using System.Collections.Generic;
using System.Data.Entity;
using Hope.Core;
using Hope.Data.Mapping;
namespace Hope.Data
{
    public class HopeContext : DbContext, IDbContext
    {
        public HopeContext(string cnn) : base(cnn)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new ComposerMap());
            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            throw new System.NotImplementedException();
        }
    }
}
