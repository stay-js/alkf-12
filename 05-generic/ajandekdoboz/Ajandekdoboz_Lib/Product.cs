namespace Ajandekdoboz_Lib
{
    public class Product(string name)
    {
        public string Name { get; init; } = name;

        public override string ToString() => Name;
    }
}
