using System;
using System.Collections.Generic;
using System.Text;

namespace Hope.Core
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; set; }
        public int ComposerId { get; set; }
        public virtual Composer Composer { get; set; }
    }
}
