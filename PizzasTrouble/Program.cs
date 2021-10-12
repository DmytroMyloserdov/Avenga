using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzasTrouble
{
    public class Program
    {
        private static async Task Main()
        {
            await using var jsonStream = File.Open("Pizzas.json", FileMode.Open);
            var pizzas = await JsonSerializer.DeserializeAsync<ICollection<Pizza>>(jsonStream);
            var dictionary = new Dictionary<string, int>();

            foreach (var pizza in pizzas)
            {
                Array.Sort(pizza.Toppings);
                var toppingsString = string.Join(", ", pizza.Toppings);
                if (dictionary.ContainsKey(toppingsString))
                {
                    dictionary[toppingsString]++;
                    continue;
                }

                dictionary.Add(toppingsString, 1);
            }

            var stringBuilder = new StringBuilder($"Top pizzas configurations:{Environment.NewLine}");

            var i = 0;
            foreach (var (toppings, count) in dictionary.OrderByDescending(p => p.Value).Take(20))
            {
                stringBuilder.AppendLine($"{++i}. {string.Join(", ", toppings)}. Count: {count}");
            }

            Console.WriteLine(stringBuilder);
            Console.ReadLine();
        }
    }
}