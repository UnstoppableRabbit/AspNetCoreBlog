using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Areas.admin.Services;
using blog.Areas.admin.Services.Abstract;

namespace blog.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private IUserRepository iu;
        public HomeController( IUserRepository userRepository)
        {
            iu = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Users()
        {
            return View(await iu.GetUsersAsync());
        }
        [HttpPost]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> UpdateUser(string id, string email, string role, string nick, string btnType)
        {
            if(btnType == "change")
                await iu.UpdateUserAsync(id, email, role, nick);
            else if (btnType == "delete")
                await iu.DeleteUserAsync(id);
            return RedirectToAction("Users", "Home", new { area = "admin" });
        }
    }
}
