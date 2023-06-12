using MyAnaliz.DAL.Models.Other;
using MyAnaliz.DAL.Models.Response;
using System.ComponentModel.DataAnnotations;

namespace MyAnaliz.DAL.Models.Request.Events
{
    public class AdditionRequest
    {
        [Required]
        [DataType(DataType.Currency)]
        public long Amount { get; set; }

        public OperationType OperationType = OperationType.Additional;
        public string Category = "System.Bank";
    }
}
