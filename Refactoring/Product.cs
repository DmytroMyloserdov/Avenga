namespace Refactoring
{
    public abstract class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public PricingMethod PricingMethod { get; set; }

        public abstract string GetProductOrderLine(out decimal productPrice);
    }
}
