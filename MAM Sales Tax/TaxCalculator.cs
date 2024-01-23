using MAM_Sales_Tax.DataAccess;
using MAM_Sales_Tax.Models;
using MAM_Sales_Tax.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MAM_Sales_Tax
{
    public class TaxCalculator(AppDbContext appDbContext)
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public void CalculateTaxForList(List<BasketItem> basketItems)
        {
            for (int i = 0; i < basketItems.Count; i++)
            {
                basketItems[i].PriceIncludingTax = PriceIncludingTax(basketItems[i].ProductId, basketItems[i].Quantity);
            }
        }

        //could overload for quantity = 1
        public decimal PriceIncludingTax(int productId, int quantity)
        {
            Product? product = GetProductIncludingFullTax(productId);

            if (product == null)
                throw new Exception($"Tax calculation requested for unfound product with id {productId}");

            decimal taxAmount = GetTaxAmount(product.TaxCategory.Rate, product.Price);

            //NB import tax is calculated based on the price + the 'basic' tax amount
            decimal importTaxAmount = GetTaxAmount(product.ImportTaxCategory.Rate, product.Price + taxAmount);

            decimal priceAfterTax = (product.Price + importTaxAmount) * quantity;

            return priceAfterTax;
        }

        private Product? GetProductIncludingFullTax(int productId)
        {
            return _appDbContext.Products
                                            .Include(x => x.TaxCategory)
                                            .Include(x => x.ImportTaxCategory)
                                            .SingleOrDefault(x => x.Id == productId);
        }

        static decimal GetTaxAmount(decimal rate, decimal price)
        {
            decimal unroundedTax =  (rate * price) / 100;
            decimal roundedTax = Math.Round(unroundedTax / 0.05M) * 0.05M;
            return roundedTax;            
        }
    }
}
