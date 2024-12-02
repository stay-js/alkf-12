namespace Jatekgyar_Lib
{
    public static class JatekFactory
    {
        public static Jatek CreateJatek(string line, GyartasAdatok gyartasAdatok)
        {
            string[] parts = line.Split(';');

            if (parts[0].StartsWith('i'))
                return new InteraktivJatek(parts[0], parts[1], parts[2], parts[3..], gyartasAdatok);

            return new EgyszeruJatek(parts[0], parts[1], parts[2], gyartasAdatok);
        }
    }
}
