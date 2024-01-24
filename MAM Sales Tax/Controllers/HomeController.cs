using MAM_Sales_Tax.DataAccess;
using MAM_Sales_Tax.Models;
using MAM_Sales_Tax.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MAM_Sales_Tax.Controllers
{
    public class HomeController(IAppDbContext appDbContext, TaxCalculatorService taxCalculator) : Controller
    {

        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly TaxCalculatorService _taxCalculator = taxCalculator;

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

            _taxCalculator.PrepareTaxForDisplayList(basketItems);
            
            ViewBag.TotalPrice = TaxCalculatorService.CalculateTotalPricePlusTaxForList(basketItems);
            ViewBag.TotalTax = TaxCalculatorService.CalculateTotalTaxForList(basketItems);

            return View("WithTax", basketItems);

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
