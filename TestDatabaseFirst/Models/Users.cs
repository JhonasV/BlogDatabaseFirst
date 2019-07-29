using System;
using System.Collections.Generic;

namespace TestDatabaseFirst.Models
{
    public partial class Users
    {
        public Users()
        {
            PostComments = new HashSet<PostComments>();
            PostLikes = new HashSet<PostLikes>();
            Posts = new HashSet<Posts>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<PostComments> PostComments { get; set; }
        public ICollection<PostLikes> PostLikes { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}
