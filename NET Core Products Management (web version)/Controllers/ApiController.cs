using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_Core_Products_Management__web_version_.Models;
using Newtonsoft.Json;

namespace NET_Core_Products_Management__web_version_.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private IProductRepository productRepository;
        public ApiController()
        {
            productRepository = new ProductRepository(new ProductsContext());
        }
        [HttpGet("[controller]/products")]
        public IActionResult GetProducts()
        {
            var products = productRepository.LoadProducts()
                .OrderBy(p => p.productId).ToList();
            return Ok(new JsonResult(products));
        }
    }
}