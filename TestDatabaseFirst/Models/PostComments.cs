using System;
using System.Collections.Generic;

namespace TestDatabaseFirst.Models
{
    public partial class PostComments
    {
        public int PostCommentId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Posts Post { get; set; }
        public Users User { get; set; }
    }
}
