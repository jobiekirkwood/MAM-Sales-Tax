using MAM_Sales_Tax.Models;
using Microsoft.EntityFrameworkCore;

namespace MAM_Sales_Tax.DataAccess
{
    public interface IAppDbContext
    {
        DbSet<ImportTaxCategory> ImportTaxCategories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<TaxCategory> TaxCategories { get; set; }
    }
}