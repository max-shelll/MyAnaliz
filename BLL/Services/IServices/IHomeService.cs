using MyAnaliz.DAL.Models.Request.Dashboard;

namespace MyAnaliz.BLL.Services.IServices
{
    public interface IHomeService
    {
        Task<TransactionsRequest?> GetTransactions(string? UserName);
    }
}
