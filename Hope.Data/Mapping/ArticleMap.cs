using Hope.Core;
using System.Data.Entity.ModelConfiguration;

namespace Hope.Data.Mapping
{
    public class ArticleMap : EntityTypeConfiguration<Article>
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
