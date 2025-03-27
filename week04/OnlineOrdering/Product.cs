namespace OnlineOrdering
{
    public class Product
    {
        private string _name;
        private int _productId;
        private double _price;
        private int _quantity;

        public Product(string name, int productId, double price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public double TotalCost()
        {
            return _price * _quantity;
        }

        public string Name => _name;
        public int ProductId => _productId;
        public double Price => _price;
        public int Quantity => _quantity;
    }
}
