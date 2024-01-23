﻿namespace DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public TaxCategory TaxCategory { get; set; }
        public int TaxCategoryId { get; set; }
        public ImportTaxCategory ImportTaxCategory { get; set; }
        public int ImportTaxCategoryId { get; set; }
    }
}
