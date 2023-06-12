using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MyAnaliz.BLL.Services.IServices;
using MyAnaliz.DAL.Models.Request.Dashboard;
using MyAnaliz.DAL.Models.Response.Account;
using MyAnaliz.DAL.Repositories.IRepositories;

namespace MyAnaliz.BLL.Services
{
    public class HomeService : IHomeService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITransactionRepository _transactionRepo;
        private readonly IMapper _mapper;

        public HomeService(IMapper mapper, ITransactionRepository transactionRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _transactionRepo = transactionRepository;
            _userManager = userManager;
        }

        public async Task<TransactionsRequest?> GetTransactions(string? UserName)
        {
            var transactionRequest = new TransactionsRequest();
            if (!string.IsNullOrEmpty(UserName))
            {
                var user = await _userManager.FindByNameAsync(UserName);
                if (user != null)
                {
                    var transactions = _transactionRepo.GetUserTransactirons(user.Id).Take(50).OrderByDescending(x => x.Date).ToList(); // Take first 50 transactions
                    foreach (var item in _transactionRepo.GetUserTransactirons(user.Id).Skip(50)) // Remove another transactions
                        await _transactionRepo.RemoveTransaction(item.Id);
                    transactionRequest.transactions = transactions;

                    var topFiveCategory = transactions
                    .GroupBy(t => t.Category)
                    .Select(g => new
                    {
                        Category = g.Key,
                        TotalSum = g.Sum(t => t.Amount)
                    })
                    .OrderByDescending(g => g.TotalSum)
                    .Take(5).Select(t => t.Category)
                    .ToList();
                    transactionRequest.Categories = topFiveCategory;
                }
            }
            return transactionRequest;
        }
    }
}
