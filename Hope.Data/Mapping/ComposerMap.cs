using Hope.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Hope.Data.Mapping
{
    public class ComposerMap : EntityTypeConfiguration<Composer>
    {
        public ComposerMap()
        {
            this.ToTable("Composer");
        }
    }
}
