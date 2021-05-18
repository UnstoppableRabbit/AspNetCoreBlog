using System;
using System.Collections.Generic;

#nullable disable

namespace blog.Areas.admin.Models
{
    public partial class ThemeT
    {
        public ThemeT()
        {
            PostThemeTs = new HashSet<PostThemeT>();
        }

        public Guid ThemeId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public virtual ICollection<PostThemeT> PostThemeTs { get; set; }
    }
}
