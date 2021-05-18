using System;
using System.Collections.Generic;

#nullable disable

namespace blog.Areas.admin.Models
{
    public partial class CommentT
    {
        public Guid CommentId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual PostT Post { get; set; }
        public virtual UserT User { get; set; }
    }
}
