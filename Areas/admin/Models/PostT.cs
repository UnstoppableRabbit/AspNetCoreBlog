using System;
using System.Collections.Generic;

#nullable disable

namespace blog.Areas.admin.Models
{
    public partial class PostT
    {
        public PostT()
        {
            CommentTs = new HashSet<CommentT>();
            PostThemeTs = new HashSet<PostThemeT>();
        }

        public Guid PostId { get; set; }
        public string Header { get; set; }
        public Guid UserId { get; set; }
        public DateTime PostDate { get; set; }
        public string PostText { get; set; }
        public string Image { get; set; }

        public virtual UserT User { get; set; }
        public virtual ICollection<CommentT> CommentTs { get; set; }
        public virtual ICollection<PostThemeT> PostThemeTs { get; set; }
    }
}
