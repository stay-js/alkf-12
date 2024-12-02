namespace Jatekgyar_Lib
{
    public class GyartasAdatok(IEnumerable<string> lines)
    {
        private readonly List<GyartasAdat> _gyartasAdatok = lines.Select(line =>
        {
            string[] parts = line.Split(';');
            return new GyartasAdat(parts[0], parts[1], int.Parse(parts[2]));
        }).ToList();

        public IEnumerable<string> ElerhetoGyartasAzonositok => _gyartasAdatok
            .Select(x => x.Azonosito)
            .Order();

        public GyartasAdat this[string azonosito] => _gyartasAdatok
            .Find(x => x.Azonosito == azonosito) ?? throw new NemLetezoJatekException();
    }
}
