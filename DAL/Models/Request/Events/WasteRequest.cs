using MyAnaliz.DAL.Models.Other;
using MyAnaliz.DAL.Models.Response;
using System.ComponentModel.DataAnnotations;

namespace MyAnaliz.DAL.Models.Request.Events
{
    public class WasteRequest
    {
        [Required]
        [DataType(DataType.Currency)]
        public long Amount { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public OperationType OperationType = OperationType.Waste;
    }
}
