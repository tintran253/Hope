using Hope.Core;
using Microsoft.EntityFrameworkCore;

namespace Hope.Data.Mapping
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {            
            this.ToTable("Article");
            this.HasRequired(z => z.Composer)
                 .WithMany(x => x.Articles)
                 .HasForeignKey(z => z.ComposerId);
        }
    }
}
