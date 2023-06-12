using Microsoft.AspNetCore.Identity;
using MyAnaliz.DAL.Models.Request.Account;

namespace MyAnaliz.BLL.Services.IServices
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterRequest model);
        Task<SignInResult> Login(LoginRequest model);
        Task LogoutAccount();
    }
}
