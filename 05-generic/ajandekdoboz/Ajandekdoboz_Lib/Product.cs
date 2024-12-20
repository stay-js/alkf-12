namespace Ajandekdoboz_Lib
{
    public class Product(string name, ProductType type)
    {
        public string Name { get; init; } = name;
        public ProductType Type { get; set; } = type;

        public override string ToString() => $"{Name} ({Type})";
    }
}
