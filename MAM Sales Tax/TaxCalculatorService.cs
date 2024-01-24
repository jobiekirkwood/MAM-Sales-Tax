using MAM_Sales_Tax.DataAccess;
using MAM_Sales_Tax.Models;
using MAM_Sales_Tax.ViewModels;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MAM_Sales_Tax
{
    public class TaxCalculatorService(AppDbContext appDbContext)
    {
        private const decimal roundingTolerance = 0.05M; 
        private readonly AppDbContext _appDbContext = appDbContext;

        public void PrepareTaxForDisplayList(List<BasketItem> basketItems)
        {
            for (int i = 0; i < basketItems.Count; i++)
            {
                Product? product = GetProductIncludingFullTaxDetails(basketItems[i].ProductId);

                if (product == null)
                    throw new Exception($"Tax calculation requested for unfound product with id {basketItems[i].ProductId}");
                
                basketItems[i].Price = product.Price;
                basketItems[i].ProductName = product.Name;

                basketItems[i].Tax = CalculateTax(product);
            }
        }

        
        private static decimal CalculateTax(Product product)
        {          
            decimal taxAmount = GetTaxAmount(product.TaxCategory.Rate, product.Price);

            decimal importTaxAmount = GetTaxAmount(product.ImportTaxCategory.Rate, product.Price);

            decimal totalTaxAmount = taxAmount + importTaxAmount;

            return totalTaxAmount;
        }

        private Product? GetProductIncludingFullTaxDetails(int productId)
        {
            return _appDbContext.Products
                                            .Include(x => x.TaxCategory)
                                            .Include(x => x.ImportTaxCategory)
                                            .SingleOrDefault(x => x.Id == productId);
        }

        static decimal GetTaxAmount(decimal rate, decimal price)
        {
            decimal unroundedTax =  (rate * price) / 100;
            decimal roundedTax = Math.Ceiling(unroundedTax / roundingTolerance) * roundingTolerance;
            return roundedTax;            
        }

        internal void FindProductNameForItems(List<BasketItem> basketItems)
        {
            for (int i = 0; i < basketItems.Count; i++)
            {
                basketItems[i].ProductName = GetProductIncludingFullTaxDetails(basketItems[i].ProductId).Name;
            }
        }

        internal static decimal CalculateTotalPricePlusTaxForList(List<BasketItem> basketItems)
        {
            return basketItems.Sum(x => x.PricePlusTax);
        }

        internal static dynamic CalculateTotalTaxForList(List<BasketItem> basketItems)
        {
            return basketItems.Sum(x => x.Tax);
        }
    }
}
