using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NET_Core_Products_Management__web_version_.Models;

namespace NET_Core_Products_Management__web_version_.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        public HomeController()
        {
            productRepository = new ProductRepository(new ProductsContext());
        }
        public ViewResult Index()
        {
            return View(productRepository.LoadProducts());
        }
        public IActionResult ProductCreation()
        {
            return View();
        }
        /*public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
