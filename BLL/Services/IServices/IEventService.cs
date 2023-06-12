using Microsoft.AspNetCore.Mvc;
using MyAnaliz.DAL.Models.Request.Events;

namespace MyAnaliz.BLL.Services.IServices
{
    public interface IEventService
    {
        Task<IActionResult> Addition(AdditionRequest request, string? UserName);
        Task<IActionResult> Waste(WasteRequest request, string? UserName);
    }
}
