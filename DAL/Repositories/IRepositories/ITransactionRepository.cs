using MyAnaliz.DAL.Models.Response.Events;

namespace MyAnaliz.DAL.Repositories.IRepositories
{
    public interface ITransactionRepository
    {
        List<Transaction> GetUserTransactirons(string UserId);
        Task<Transaction> GetTransactionById(string Id);
        Task AddTransaction(Transaction item);
        Task RemoveTransaction(string TransactionId);
        Task<bool> SaveChangesAsync();
    }
}
