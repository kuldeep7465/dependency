using dependecy.infratecture;
using dependecy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dependecy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Istudent db;
        public HomeController(ILogger<HomeController> logger, Istudent _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult List()
        {
            var a = db.GetAll();
            return View(a);
        }

        public IActionResult Details(int Id)
        {
            var b = db.GEtById(Id);
            return View(b);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee Employee)
        {
           db.Add(Employee);
            return View();
        }
        public IActionResult Delete(int Id)
        {
           db.Delete(Id);
            return View(Id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
