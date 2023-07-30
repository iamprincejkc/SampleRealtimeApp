using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SampleRealtimeApp.Contracts;
using SampleRealtimeApp.Hubs;
using SampleRealtimeApp.Models;
using System.Diagnostics;

namespace SampleRealtimeApp.Controllers
{
    public class HomeController : Controller
    {                                                    
        private readonly IHubContext<ProductHub, IProductHub> _hub;
        public HomeController(IHubContext<ProductHub,IProductHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddTestProduct()
        {
            _hub.Clients.All.ReceiveProduct("From Controller", $"Added {DateTime.Now:f}", "A", "create");
            return Content("Added Product in SignalR Realtime App");
        }
    }
}