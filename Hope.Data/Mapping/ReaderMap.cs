using Hope.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Data.Mapping
{
    public class ReaderMap: EntityTypeConfiguration<Reader>
    {
        public ReaderMap()
        {
            this.ToTable("Reader");

        }
    }
}
