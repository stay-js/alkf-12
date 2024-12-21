namespace Ajandekdoboz_Lib
{
    public class Box<T>(string name, int price) where T : Product
    {
        // Tudom, hogy a generikusságot nem így kellene használni,
        // mert így elég lenne, ha nem generikus osztályt használnék,
        // és private readonly List<T> _products = [] helyett,
        // elég lenne private readonly List<Product> _products = []...
        private readonly List<T> _products = [];

        public string Name { get; } = name;
        public int Price { get; } = price;

        public IEnumerable<T> Products => _products;

        public void AddProduct(T product)
        {
            if (_products.Count != 0 && _products[0].GetType() != product.GetType())
            {
                throw new ProductTypeMixException();
            }

            _products.Add(product);
        }
    }
}
