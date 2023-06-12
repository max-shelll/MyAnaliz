using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAnaliz.BLL.Services.IServices;
using MyAnaliz.DAL.Models.Response.Account;

namespace MyAnaliz.BLL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly UserManager<User> _userManager;

        public HomeController(IHomeService homeService, UserManager<User> userManager)
        {
            _homeService = homeService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _homeService.GetTransactions(User.Identity.Name);
            return View(model);
        }
    }
}
