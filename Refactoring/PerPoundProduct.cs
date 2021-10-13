namespace Refactoring
{
    public class PerPoundProduct : Product
    {
        public decimal Weight { get; set; }
        
        public PerPoundProduct()
        {
            PricingMethod = PricingMethod.PerPound;
        }

        public override string GetProductOrderLine(out decimal productPrice)
        {
            productPrice = Weight * Price;
            return
                $"{ProductName} ${productPrice} ({Weight} pounds at ${Price} per pound)";
        }
    }
}
