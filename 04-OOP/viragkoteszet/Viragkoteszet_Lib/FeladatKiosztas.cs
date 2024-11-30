namespace Viragkoteszet_Lib
{
    public static class FeladatKiosztas
    {
        public static List<string> Kioszt(IEnumerable<string> lines, Termekek products, Dolgozok workers)
        {
            List<string> errorList = [];

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                var worker = workers[int.Parse(parts[0])];

                if (worker is null)
                {
                    errorList.Add($"Dolgozó: {parts[0]}, Termék: {parts[1]} - A dolgozó nem található.");
                    continue;
                }

                var product = products[int.Parse(parts[1])];

                if (product is null)
                {
                    errorList.Add($"Dolgozó: {parts[0]}, Termék: {parts[1]} - A termék nem található.");
                    continue;
                }

                try
                {
                    worker.FeladatHozzaadasa(product);
                }
                catch (Exception e)
                {
                    errorList.Add($"Dolgozó: {worker.Azonosito}, Termék: {product.Azonosito} - {e.Message}");
                }
            }

            return errorList;
        }
    }
}
