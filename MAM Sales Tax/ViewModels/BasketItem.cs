namespace MAM_Sales_Tax.ViewModels
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public string ProductName { get; set; }
        public decimal PricePlusTax
        {
            get
            {
                return Price + Tax;
            }
        }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }


    }
}
