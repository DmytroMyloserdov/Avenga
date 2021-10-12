using System.Text.Json.Serialization;

namespace PizzasTrouble
{
    public class Pizza
    {
        [JsonPropertyName("toppings")]
        public string[] Toppings { get; set; }
    }
}