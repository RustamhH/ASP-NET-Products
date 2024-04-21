using Microsoft.AspNetCore.Mvc;
using Products.Models;
using System.Diagnostics;

namespace Products.Controllers
{
    public class ProductController : Controller
    {
        public List<Product> Products { get; set; }

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            Products = new List<Product>()
            {
                new Product { Id = 1,Name="Cola",Price=10},
                new Product { Id = 2,Name="Lays",Price=12},
                new Product { Id = 3,Name="Sprite",Price=14},
                new Product { Id = 4,Name="Doritos",Price=16},
                new Product { Id = 5,Name="Fanta",Price=19},
                new Product { Id = 6,Name="Mirinda",Price=20},
                new Product { Id = 7,Name="Mountain Dew",Price=30},
                new Product { Id = 8,Name="Pepsi",Price=40},
                new Product { Id = 9,Name="Snickers",Price=50},
                new Product { Id = 10,Name="Bounty",Price=110},
                new Product { Id = 11,Name="Salmon",Price=80},
                new Product { Id = 12,Name="Cappy",Price=90},
                new Product { Id = 13,Name="Red Bull",Price=111},
                new Product { Id = 14,Name="Hell",Price=102},
                new Product { Id = 15,Name="Bizon",Price=104},
                new Product { Id = 16,Name="Burn",Price=105},
                new Product { Id = 17,Name="Dynamit",Price=106},
                new Product { Id = 18,Name="Twix",Price=107},
                new Product { Id = 19,Name="Mars",Price=108},
                new Product { Id = 20,Name="Magnum",Price=113},
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public IActionResult GetAllProducts()
        {
            return View(Products);
        }
        public IActionResult GetProductById(int id)
        {
            foreach (var item in Products)
            {

                if (item.Id == id) return View(item);
            }
            return RedirectToAction("GetAllProducts");
        }

        public IActionResult DeleteProductById(int id)
        {
            var selectedProduct = Products.FirstOrDefault(p => p.Id == id);
            Products.Remove(selectedProduct!);
            return RedirectToAction("GetAllProducts");
        }
    }
}
