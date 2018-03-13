using Hope.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hope.Data
{
    //, IHopeContext
    public class HopeContext : DbContext, IDbContext
    {
        public HopeContext(DbContextOptions<HopeContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Composer> Composers { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Reader> Readers { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new ArticleMap());
        //    modelBuilder.Configurations.Add(new ComposerMap());
        //    modelBuilder.Configurations.Add(new ReaderMap());
        //    base.OnModelCreating(modelBuilder);
        //}

        //public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}

        //public new DbSet<TEntity> Set<TEntity>()
        //{
        //    return base.Set<TEntity>();
        //}
    }
}
