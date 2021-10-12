using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    internal class Program
    {
        private static void Main()
        {
            var (orderCustomer, orderProducts) = new Tuple<string, List<Product>>("John Doe",
                new List<Product>
                {
                    new Product
                    {
                        ProductName = "Pulled Pork",
                        Price = 6.99m,
                        Weight = 0.5m,
                        PricingMethod = PricingMethod.PerPound,
                    },
                    new Product
                    {
                        ProductName = "Coke",
                        Price = 3m,
                        Quantity = 2,
                        PricingMethod = PricingMethod.PerItem
                    }
                }
            );

            var price = 0m;
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"ORDER SUMMARY FOR {orderCustomer}:");

            foreach (var orderProduct in orderProducts)
            {
                stringBuilder.AppendLine(GetProductLine(orderProduct, out var productPrice));
                price += productPrice;
            }

            stringBuilder.AppendLine($"{Environment.NewLine}Total Price: ${price}");

            Console.WriteLine(stringBuilder);
            Console.ReadKey();
        }

        private static string GetProductLine(Product orderProduct, out decimal productPrice)
        {
            productPrice = 0m;
            if (orderProduct.PricingMethod == PricingMethod.PerPound && orderProduct.Weight.HasValue)
            {
                productPrice = orderProduct.Weight.Value * orderProduct.Price;
                return
                    $"{orderProduct.ProductName} ${productPrice} ({orderProduct.Weight} pounds at ${orderProduct.Price} per pound)";
            }

            if (orderProduct.PricingMethod == PricingMethod.PerItem && orderProduct.Quantity.HasValue)
            {
                productPrice = orderProduct.Quantity.Value * orderProduct.Price;
                return
                    $"{orderProduct.ProductName} ${productPrice} ({orderProduct.Weight} items at ${orderProduct.Price} each)";
            }

            return null;
        }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal? Weight { get; set; }
        public int? Quantity { get; set; }
        public PricingMethod PricingMethod { get; set; }
    }

    public enum PricingMethod
    {
        PerPound,
        PerItem
    }
}

