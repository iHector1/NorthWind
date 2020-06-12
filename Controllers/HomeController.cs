using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthWind.Models;
using NorthWind.Model;

namespace NorthWind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var db = new NorthWindContext();
            return View(db.Products.ToList());
        }
       
        [HttpPost]
        public IActionResult Index(float number)
        {
            long numbers = Convert.ToInt16(number);
            if(numbers<0){
                return Index();
            }
            using (var db = new NorthWindContext())
            {
                List<Products> products = db.Products.Where(a => a.UnitsInStock <= numbers).ToList();
                return View(products);
            }
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
