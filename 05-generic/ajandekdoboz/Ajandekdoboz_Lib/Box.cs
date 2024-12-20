namespace Ajandekdoboz_Lib
{
    public class Box<T>(string name, int price) where T : Product
    {
        private readonly List<T> _products = [];

        public string Name { get; } = name;
        public int Price { get; } = price;

        public IEnumerable<T> Products => _products;

        public void AddProduct(T product)
        {
            if (_products.Count != 0 && _products[0].Type != product.Type)
                throw new ProductTypeMixException();

            _products.Add(product);
        }
    }
}
