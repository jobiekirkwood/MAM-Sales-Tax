using MAM_Sales_Tax.DataAccess;
using MAM_Sales_Tax.Models;
using MAM_Sales_Tax.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MAM_Sales_Tax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
           // List<Product> products = _appDbContext.Products.ToList();
            List<BasketItem> basketItems =
            [
                new BasketItem { ProductId = 1, Quantity = 1 },
                new BasketItem { ProductId = 2, Quantity = 1 },
                new BasketItem { ProductId = 3, Quantity = 1 },
                new BasketItem { ProductId = 4, Quantity = 2 },
            ];
             
            return View(basketItems);
        }

        [HttpPost]
        public IActionResult Index(List<BasketItem> basketItems)
        {

            return View();//todo add in strongly typed return view

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
