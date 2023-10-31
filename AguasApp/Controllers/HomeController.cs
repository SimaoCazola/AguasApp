using AguasApp.Data;
using AguasApp.Data.Entities;
using AguasApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AguasApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult IndexComments() 
        {
            var comments = _context.Comments.ToList();
            return View("Views/Home/Index.cshtml", comments);
        }

       
    }
}

