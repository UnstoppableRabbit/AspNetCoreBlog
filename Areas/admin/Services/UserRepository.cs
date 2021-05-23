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
            return await bc.UserTs.Select(x => x).ToListAsync();
        }
        public async Task UpdateUserAsync(string id, string email, string role, string nick)
        {
            UserT user = await (from x in bc.UserTs
                                where x.UserId.ToString() == id
                                select x).FirstAsync();
            user.Email = email;
            user.Nickname = nick;
            user.Role = role;
            await bc.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(string id)
        {
             UserT user= await (from x in bc.UserTs
                              where x.UserId.ToString() == id
                              select x).FirstAsync();
             bc.UserTs.Remove(user);
             await bc.SaveChangesAsync();
        }
    }
}
