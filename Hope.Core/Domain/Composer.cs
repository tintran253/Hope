using System;
using System.Collections.Generic;
using System.Text;

namespace Hope.Core
{
    public class Composer : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
