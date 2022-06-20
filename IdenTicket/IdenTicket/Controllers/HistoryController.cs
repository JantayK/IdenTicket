using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdenTicket.Data;
using IdenTicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdenTicket.Controllers
{
    [Authorize(Roles = "Customer, Admin")]
    public class HistoryController : Controller
    {
        private readonly UnitOfWork _uow;
        private readonly ILogger<HistoryController> _logger;

        public HistoryController(ILogger<HistoryController> logger, UnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        [HttpGet]
        public IActionResult History()
        {
            var searchLogs = _uow.SearchLogs.GetByCustomerId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(searchLogs ?? new List<SearchLog>());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _uow.SearchLogs.Delete(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction("History");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult TotalHistory()
        {
            var searchLogs = _uow.SearchLogs.GetAll();
            return View(searchLogs ?? new List<SearchLog>());
        }
    }
}
