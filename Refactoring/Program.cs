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
                    new PerPoundProduct
                    {
                        ProductName = "Pulled Pork",
                        Price = 6.99m,
                        Weight = 0.5m
                    },
                    new PerItemProduct
                    {
                        ProductName = "Coke",
                        Price = 3m,
                        Quantity = 2
                    }
                }
            );

            var price = 0m;
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"ORDER SUMMARY FOR {orderCustomer}:");

            foreach (var orderProduct in orderProducts)
            {
                stringBuilder.AppendLine(orderProduct.GetProductOrderLine(out var productPrice));
                price += productPrice;
            }

            stringBuilder.AppendLine($"{Environment.NewLine}Total Price: ${price}");

            Console.WriteLine(stringBuilder);
            Console.ReadKey();
        }
    }
}

