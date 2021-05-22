using blog.Areas.admin.Models;
using blog.Areas.admin.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Areas.admin.Services
{
    public class PostRepository : IPostRepository
    {
        BlogDBContext bc;
        public PostRepository(BlogDBContext blog)
        {
            bc = blog;
        }

        public async Task<List<PostT>> GetUsersAsync()
        {
            return await bc.PostTs.Select(x => x).ToListAsync();
        }
    }
}
