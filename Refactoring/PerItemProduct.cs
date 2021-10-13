namespace Refactoring
{
    public class PerItemProduct : Product
    {
        public int Quantity { get; set; }

        public PerItemProduct()
        {
            PricingMethod = PricingMethod.PerItem;
        }

        public override string GetProductOrderLine(out decimal productPrice)
        {
            productPrice = Quantity * Price;
            return $"{ProductName} ${productPrice} ({Quantity} items at ${Price} each)";
        }
    }
}
