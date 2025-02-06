using Ajandekdoboz_Lib;

await File.WriteAllTextAsync("hibalista.txt", string.Empty);

var giftBoxes = ReadGiftBoxes("data.csv");

Console.WriteLine("Ajándékdobozok:");

foreach (var box in giftBoxes)
{
    Console.WriteLine($"\nAjándékdoboz: {box.Name}, Ár: {box.Price} Ft");
    Console.WriteLine("Termékek:\n\t- " + string.Join("\n\t- ", box.Products));
}

static List<Box<Product>> ReadGiftBoxes(string filePath)
{
    var boxes = new List<Box<Product>>();

    if (!File.Exists(filePath))
    {
        Console.WriteLine("A fájl nem található: " + filePath);
        return boxes;
    }

    string input = File.ReadAllText(filePath);

    foreach (string box in input.Split("\n\n"))
    {
        string[] lines = box.Split('\n');
        string[] boxParts = lines[0].Split(';');
        var currentBox = new Box<Product>(boxParts[0], int.Parse(boxParts[1]));

        bool validBox = true;

        foreach (string product in lines.Skip(1))
        {
            string[] parts = product.Split(';');

            try
            {
                currentBox.AddProduct(parts[1] switch
                {
                    "c" => new Cosmetics(parts[0]),
                    "f" => new Food(parts[0]),
                    "s" => new Sweets(parts[0]),
                    "w" => new Wine(parts[0]),
                    _ => throw new InvalidProductTypeException()
                });
            }
            catch (ProductTypeMixException e)
            {
                File.AppendAllText("hibalista.txt",
                    $"{string.Join(" - ", box.Split("\n"))} - {e.Message}");

                validBox = false;
                break;
            }
        }

        if (validBox) boxes.Add(currentBox);
    }
    return boxes;
}
