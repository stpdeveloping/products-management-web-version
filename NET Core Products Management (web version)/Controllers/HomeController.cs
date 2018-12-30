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
        [HttpGet]
        public ActionResult Index()
        {
            return View(productRepository.LoadProducts()
                .OrderBy(p => p.productId).ToList());
        }
        public ViewResult ProductCreation()
        {
            var prodTemplate = new ExtendedProduct();
            prodTemplate.Warehouses
                .AddRange(productRepository.GetWarehousesNames());
            return View(prodTemplate);
        }
        [HttpPost]
        public ActionResult ProductCreation(ExtendedProduct newProd)
        {
            if (ModelState.IsValid)
            {
                productRepository.CreateNewProduct(newProd);
                return RedirectToAction("Index");
            }
            else return View(newProd);
        }
        [HttpPut]
        public ActionResult ProductUpdate(ProductToUpdate p)
        {
            if (ModelState.IsValid)
            {
                productRepository
                    .UpdateProductProperty
                    (p.columnName, p.productId, p.value, p.productMagName);
                return Ok();
            }
            else return BadRequest("Field cannot be empty!");
        }
        [HttpDelete]
        public ActionResult ProductDelete(int id)
        {
            if (productRepository.RemoveProducts(id))
                return Ok();
            else return BadRequest("Incorrect id!");
        }
        [HttpPost]
        public ActionResult ProperWhSymbol(string warehouseName)
        {
            return Json(productRepository.GetWarehouseSymbol(warehouseName));
        }
    }
}
