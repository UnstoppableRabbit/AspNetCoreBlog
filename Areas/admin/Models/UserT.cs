using System;
using System.Collections.Generic;

#nullable disable

namespace blog.Areas.admin.Models
{
    public partial class UserT
    {
        public UserT()
        {
            CommentTs = new HashSet<CommentT>();
            PostTs = new HashSet<PostT>();
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<CommentT> CommentTs { get; set; }
        public virtual ICollection<PostT> PostTs { get; set; }
    }
}
