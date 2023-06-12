using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAnaliz.DAL.Models.Response;
using MyAnaliz.DAL.Models.Response.Account;
using Transaction = MyAnaliz.DAL.Models.Response.Events.Transaction;

namespace MyAnaliz.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
