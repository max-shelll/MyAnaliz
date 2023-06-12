using Microsoft.EntityFrameworkCore;
using MyAnaliz.DAL.Models.Response.Events;
using MyAnaliz.DAL.Repositories.IRepositories;
using Transaction = MyAnaliz.DAL.Models.Response.Events.Transaction;

namespace MyAnaliz.DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetTransactionById(string Id)
        {
            return _context.Transactions.FirstOrDefaultAsync(t => t.Id == Id).Result;
        }

        public async Task AddTransaction(Transaction item)
        {
            await _context.AddAsync(item);
            await SaveChangesAsync();
        }

        public List<Transaction> GetUserTransactirons(string UserId)
        {
            return _context.Transactions.Where(t => t.User.Id == UserId).ToList();
        }

        public async Task RemoveTransaction(string TransactionId)
        {
            _context.Transactions.Remove(GetTransactionById(TransactionId).Result);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
