using MAM_Sales_Tax.DataAccess;
using MAM_Sales_Tax.Models;
using MAM_Sales_Tax.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MAM_Sales_Tax.Controllers
{
    public class HomeController(ILogger<HomeController> logger, AppDbContext appDbContext, TaxCalculator taxCalculator) : Controller
    {

        private readonly AppDbContext _appDbContext = appDbContext;
        private readonly TaxCalculator _taxCalculator = taxCalculator;

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _appDbContext.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Index(List<BasketItem> basketItems)
        {

            if (basketItems.Count == 0)
                return View(nameof(HomeController.Index));


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
    }
}
