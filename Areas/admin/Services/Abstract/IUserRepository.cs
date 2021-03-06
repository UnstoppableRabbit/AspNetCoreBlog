using blog.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Areas.admin.Services.Abstract
{
    public interface IUserRepository
    {
        public Task<List<UserT>> GetUsersAsync();
        public Task UpdateUserAsync(string id, string email, string role, string nick);
        public Task DeleteUserAsync(string id);
    }
}
