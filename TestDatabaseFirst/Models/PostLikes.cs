using System;
using System.Collections.Generic;

namespace TestDatabaseFirst.Models
{
    public partial class PostLikes
    {
        public int PostlikesId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Posts Post { get; set; }
        public Users User { get; set; }
    }
}
