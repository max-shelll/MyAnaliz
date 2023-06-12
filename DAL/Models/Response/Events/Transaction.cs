using MyAnaliz.DAL.Models.Other;
using MyAnaliz.DAL.Models.Response.Account;

namespace MyAnaliz.DAL.Models.Response.Events
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public OperationType OperationType { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public string? Category { get; set; }
        public User User { get; set; }
    }
}
