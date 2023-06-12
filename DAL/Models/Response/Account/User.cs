using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.Transactions;
using Transaction = MyAnaliz.DAL.Models.Response.Events.Transaction;

namespace MyAnaliz.DAL.Models.Response.Account
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Balance { get; set; }

        public List<Transaction> Transactions = new List<Transaction>();
    }
}
