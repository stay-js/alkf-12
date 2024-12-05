namespace Sikolcsonzo_Lib
{
    public static class SporteszkozFactory
    {
        public static Sporteszkoz Factory(string line)
        {
            string[] parts = line.Split(';');

            return parts[0] == "L"
               ? new Silec(parts[1], parts[2], int.Parse(parts[3]))
               : new Snowboard(parts[1], parts[2], int.Parse(parts[3]), parts.Length == 5);
        }
    }
}
