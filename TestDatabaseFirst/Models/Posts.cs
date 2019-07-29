using System;
using System.Collections.Generic;

namespace TestDatabaseFirst.Models
{
    public partial class Posts
    {
        public Posts()
        {
            PostComments = new HashSet<PostComments>();
            PostLikes = new HashSet<PostLikes>();
        }

        public int PostId { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
        public ICollection<PostComments> PostComments { get; set; }
        public ICollection<PostLikes> PostLikes { get; set; }
    }
}
