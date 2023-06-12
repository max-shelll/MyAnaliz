using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAnaliz.BLL.Services.IServices;
using MyAnaliz.DAL.Models.Request.Events;
using MyAnaliz.DAL.Models.Response.Account;
using MyAnaliz.DAL.Models.Response.Events;
using MyAnaliz.DAL.Repositories.IRepositories;

namespace MyAnaliz.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITransactionRepository _transactionRepo;
        private readonly IMapper _mapper;

        public EventService(IMapper mapper, ITransactionRepository transactionRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _transactionRepo = transactionRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Addition(AdditionRequest request, string? UserName)
        {
            if (string.IsNullOrEmpty(UserName))
                return new NoContentResult();

            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null)
                return new NoContentResult();

            user.Balance += request.Amount;
            await _userManager.UpdateAsync(user);

            var transaction = _mapper.Map<Transaction>(request);
            transaction.User = user;

            await _transactionRepo.AddTransaction(transaction);
            return new OkResult();
        }

        public async Task<IActionResult> Waste(WasteRequest request, string? UserName)
        {
            if (string.IsNullOrEmpty(UserName))
                return new NoContentResult();

            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null)
                return new NoContentResult();

            user.Balance -= request.Amount;
            await _userManager.UpdateAsync(user);

            var transaction = _mapper.Map<Transaction>(request);
            transaction.User = user;

            await _transactionRepo.AddTransaction(transaction);
            return new OkResult();
        }
    }
}
