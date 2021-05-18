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
        public async Task<IActionResult> Users()
        {
            return View(await iu.GetUsersAsync());
        }
    }
}
