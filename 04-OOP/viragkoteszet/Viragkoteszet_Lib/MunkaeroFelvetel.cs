namespace Viragkoteszet_Lib
{
    public static class MunkaeroFelvetel
    {
        public static Dolgozo[] Felvetel(IEnumerable<string> line)
        {
            return line.Select<string, Dolgozo>(line =>
            {
                string[] parts = line.Split(';');
                if (parts[2] == "v") return new Viragkoto(int.Parse(parts[0]), parts[1]);
                return new Gyakornok(int.Parse(parts[0]), parts[1], parts[3..].Select(int.Parse).ToArray());
            }).ToArray();
        }
    }
}
