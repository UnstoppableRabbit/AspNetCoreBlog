using blog.Areas.admin.Models;
using blog.Areas.admin.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Areas.admin.Services
{
    public class UserRepository : IUserRepository
    {
        BlogDBContext bc;
        public UserRepository(BlogDBContext blog)
        {
            bc = blog;
        }

        public async Task<List<UserT>> GetUsersAsync()
        {
            return await bc.UserTs.Select(x=>x).ToListAsync();
        }
    }
}
