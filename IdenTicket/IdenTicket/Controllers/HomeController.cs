using IdenTicket.Data;
using IdenTicket.Models;
using IdenTicket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _uow;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        [HttpGet]
        public IActionResult Index()
        {
          
            return View(new SearchViewModel() { DepartDate = DateTime.Today });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SearchViewModel searchViewModel)
        {
            if (!ModelState.IsValid)
                return View(searchViewModel);

            var result = _uow.Flights.Search(searchViewModel);

            return View("Search", result);
        }

        [HttpGet]
        public IActionResult Search(IEnumerable<Flight> result)
        {
            return View(result);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(SearchViewModel searchViewModel)
        {
            if (!ModelState.IsValid)
                return View(searchViewModel);
            return View(_uow.Flights.Search(searchViewModel));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
