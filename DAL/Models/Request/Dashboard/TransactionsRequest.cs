using MyAnaliz.DAL.Models.Other;
using MyAnaliz.DAL.Models.Request.Events;
using MyAnaliz.DAL.Models.Response;
using MyAnaliz.DAL.Models.Response.Events;

namespace MyAnaliz.DAL.Models.Request.Dashboard
{
    public class TransactionsRequest
    {
        public ICollection<Transaction>? transactions { get; set; }

        public AdditionRequest additionRequest {get; set;}
        public WasteRequest wasteRequest { get; set;}

        public List<string> Categories = new List<string>();

        public TransactionsRequest()
        {
            additionRequest = new AdditionRequest();
            wasteRequest = new WasteRequest();
        }
    }
}
