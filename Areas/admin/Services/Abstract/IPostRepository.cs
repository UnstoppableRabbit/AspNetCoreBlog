using blog.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Areas.admin.Services.Abstract
{
    interface IPostRepository
    {
        public Task<List<PostT>> GetUsersAsync();
    }
}
