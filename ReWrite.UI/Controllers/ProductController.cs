using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReWrite.UI.ApiServices;
using ReWrite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _service;
        public ProductController(ProductApiService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //string token = HttpContext.Session.GetString("myToken");
            string token = Request.Cookies["token"];
            var products = await _service.GetProducts(token);            
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new ProductDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProductName", "SupplierID", "CategoryID")]ProductDTO dto)
        {
            //string token = HttpContext.Session.GetString("myToken");
            string token = Request.Cookies["token"];
            TempData["AddProductMessage"] = await _service.AddProduct(dto, token);
            return RedirectToAction("Index");
        }
    }
}
