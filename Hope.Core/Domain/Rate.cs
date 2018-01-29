using System;
using System.Collections.Generic;
using System.Text;

namespace Hope.Core
{
    public class Rate : BaseEntity
    {
        public int Stars { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public int ReaderId { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
