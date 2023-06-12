using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyAnaliz.BLL.Services.IServices;
using MyAnaliz.DAL.Models.Request.Account;
using MyAnaliz.DAL.Models.Response.Account;

namespace MyAnaliz.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AccountService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(RegisterRequest model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                return result;
            }
            else
            {
                return result;
            }
        }

        public async Task<SignInResult> Login(LoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            return result;
        }

        public async Task LogoutAccount()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
