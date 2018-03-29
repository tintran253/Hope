using Hope.Core;
using System;
using System.Data.Entity;
using System.Linq;

namespace Hope.Data
{
    public class HopeContext : DbContext, IDbContext
    {
        public HopeContext(string cnn) : base(cnn)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Composer> Composers { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new ArticleMap());
        //    modelBuilder.Configurations.Add(new ComposerMap());
        //    modelBuilder.Configurations.Add(new ReaderMap());
        //    base.OnModelCreating(modelBuilder);
        //}

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}
