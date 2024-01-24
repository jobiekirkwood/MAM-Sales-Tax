using MAM_Sales_Tax.Models;
using Microsoft.EntityFrameworkCore;

namespace MAM_Sales_Tax.DataAccess
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<TaxCategory> TaxCategories { get; set; }
        public DbSet<ImportTaxCategory> ImportTaxCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxCategory>()
                .HasData(
                          new TaxCategory { Id = 1, Name = "Uncategorised0", Rate = 0 },
                          new TaxCategory { Id = 2, Name = "Uncategorised10", Rate = 10 },
                          new TaxCategory { Id = 3, Name = "Books", Rate = 0 },
                          new TaxCategory { Id = 4, Name = "Food", Rate = 0 },
                          new TaxCategory { Id = 5, Name = "Medical", Rate = 0 }
                          );

            modelBuilder.Entity<ImportTaxCategory>()
                .HasData(
                         new ImportTaxCategory { Id = 1, Name = "Uncategorised0", Rate = 0 },
                         new ImportTaxCategory { Id = 2, Name = "Uncategorised5", Rate = 5 }
                         );

            modelBuilder.Entity<Product>()
                .HasData(new Product { Id = 1, Name = "Book", Price = 12.49M, TaxCategoryId = 3, ImportTaxCategoryId = 1 },
                new Product { Id = 2, Name = "Music CD", Price = 14.99M, TaxCategoryId = 2, ImportTaxCategoryId = 1 },
                new Product { Id = 3, Name = "Chocolate Bar", Price = 0.85M, TaxCategoryId = 4, ImportTaxCategoryId = 1 },
                new Product { Id = 4, Name = "Imported Box of Chocolates", Price = 10.00M, TaxCategoryId = 4, ImportTaxCategoryId = 2 },
                new Product { Id = 5, Name = "Imported Bottle of Perfume", Price = 47.50M, TaxCategoryId = 2, ImportTaxCategoryId = 2 },
                new Product { Id = 6, Name = "Imported Bottle of Perfume", Price = 27.99M, TaxCategoryId = 2, ImportTaxCategoryId = 2 },
                new Product { Id = 7, Name = "Bottle of Perfume", Price = 18.99M, TaxCategoryId = 2, ImportTaxCategoryId = 1 },
                new Product { Id = 8, Name = "Packet of Paracetemol", Price = 9.75M, TaxCategoryId = 5, ImportTaxCategoryId = 1 },
                new Product { Id = 9, Name = "Imported Box of Chocolates", Price = 11.25M, TaxCategoryId = 4, ImportTaxCategoryId = 2 }
                );


        }
    }
}
