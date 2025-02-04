﻿namespace Jatekgyar_Lib
{
    public class Jatekok(IEnumerable<string> lines, GyartasAdatok gyartasAdatok)
    {
        private readonly List<Jatek> _jatekok = lines
            .Select(line => JatekFactory.CreateJatek(line, gyartasAdatok))
            .ToList();

        public Jatek this[string azonosito] => _jatekok.Find(x => x.Azonosito == azonosito)
            ?? throw new NemLetezoJatekException();

        public IEnumerable<Jatek> JatekTipusok => _jatekok
            .Where(x => !x.Tipus.StartsWith('k'))
            .OrderBy(x => x.Megnevezes);
    }
}
