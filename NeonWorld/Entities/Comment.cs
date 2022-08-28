using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public string UserComment { get; set; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
    }
}
