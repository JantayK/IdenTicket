using IdenTicket.Data;
using IdenTicket.Models;
using IdenTicket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Index(SearchViewModel searchViewModel)
        {
            if(ModelState.IsValid)
            {

            }
            throw new System.Exception();
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
