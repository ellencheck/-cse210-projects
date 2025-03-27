using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _products = new List<Product>();
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double GetTotalCost()
        {
            double totalCost = 0;
            foreach (var product in _products)
            {
                totalCost += product.TotalCost();
            }
            return totalCost;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in _products)
            {
                label += $"{product.Name} (x{product.Quantity})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{_customer.Name}\n{_customer.Address.FullAddress()}";
        }
    }
}
