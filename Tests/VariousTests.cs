using MAM_Sales_Tax;
using MAM_Sales_Tax.Controllers;
using MAM_Sales_Tax.DataAccess;
using MAM_Sales_Tax.Models;
using MAM_Sales_Tax.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace Tests
{

    public class TaxCalculatorServiceTests
    {
        [Fact]
        public void CalculateTax_ReturnsCorrectTax()
        {
            // Arrange
            Product product = new()
            {
                Price = 11.25M,
                TaxCategory = new TaxCategory { Rate = 0 },
                ImportTaxCategory = new ImportTaxCategory { Rate = 5 }
            };

            decimal expectedTax = 0.60M;

            // Act
            decimal actualTax = TaxCalculatorService.CalculateTax(product);

            // Assert
            Assert.Equal(expectedTax, actualTax);
        }

        [Fact]
        public void CalculateTotalPricePlusTaxForList_ReturnsCorrectSum()
        {
            // Arrange
            List<BasketItem> basketItems = new()
        {
            new BasketItem { Price = 12.49M, Tax = 0 },
            new BasketItem { Price = 14.99M, Tax = 1.5M },
            new BasketItem { Price = 0.85M, Tax = 0 }
        };

            decimal expectedTotal = 29.83M;

            // Act
            decimal actualTotal = TaxCalculatorService.CalculateTotalPricePlusTaxForList(basketItems);

            // Assert
            Assert.Equal(expectedTotal, actualTotal);
        }

       
    }

}