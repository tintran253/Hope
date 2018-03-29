using System;

namespace Hope.Core
{
    public class Token : BaseEntity
    {
        public string AccessToken { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime Expriy { get; set; }
    }
}