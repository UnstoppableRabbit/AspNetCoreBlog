using System;
using System.Collections.Generic;

#nullable disable

namespace blog.Areas.admin.Models
{
    public partial class PostThemeT
    {
        public Guid PostThemeId { get; set; }
        public Guid PostId { get; set; }
        public Guid ThemeId { get; set; }

        public virtual PostT Post { get; set; }
        public virtual ThemeT Theme { get; set; }
    }
}
