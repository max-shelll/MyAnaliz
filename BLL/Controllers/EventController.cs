using Microsoft.AspNetCore.Mvc;
using MyAnaliz.BLL.Services.IServices;
using MyAnaliz.DAL.Models.Request.Dashboard;
using MyAnaliz.DAL.Models.Request.Events;

namespace MyAnaliz.BLL.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public async Task<IActionResult> Addition(TransactionsRequest request)
        {
            var result = await _eventService.Addition(request.additionRequest, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Waste(TransactionsRequest request)
        {
            var result = await _eventService.Waste(request.wasteRequest, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }
    }
}
