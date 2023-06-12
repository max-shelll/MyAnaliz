using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAnaliz.BLL.Services.IServices;
using MyAnaliz.DAL.Models.Request.Account;
using MyAnaliz.DAL.Models.Response.Account;
using System.Data;

namespace MyAnaliz.BLL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Register(request);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (ModelState.IsValid) 
            {
                var result = await _accountService.Login(request);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError(string.Empty, "Неправильный логин и (или) пароль");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAccount();
            return RedirectToAction("Index", "Home");
        }
    }
}
