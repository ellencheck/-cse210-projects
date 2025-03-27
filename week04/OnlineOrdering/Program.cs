using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Address objects
            Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
            Address address2 = new Address("456 Oak Rd", "Toronto", "ON", "Canada");

            // Create Customer objects
            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);

            // Create Product objects
            Product product1 = new Product("Laptop", 101, 799.99, 1);
            Product product2 = new Product("Mouse", 102, 25.50, 2);
            Product product3 = new Product("Keyboard", 103, 40.00, 1);

            // Create Order objects
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);

            // Display packing labels, shipping labels, and total costs
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}\n");

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}\n");
        }
    }
}
