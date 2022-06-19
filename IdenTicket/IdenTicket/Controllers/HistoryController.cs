using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdenTicket.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdenTicket.Controllers
{
    [Authorize(Roles = "Customer")]
    public class HistoryController : Controller
    {
        private readonly UnitOfWork _uow;
        private readonly ILogger<HistoryController> _logger;

        public HistoryController(ILogger<HistoryController> logger, UnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        public IActionResult History()
        {
            return View();
        }
    }
}
