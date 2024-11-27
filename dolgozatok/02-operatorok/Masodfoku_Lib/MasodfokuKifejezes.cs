namespace Masodfoku_Lib
{
    public class MasodfokuKifejezes(double a, double b, double c)
    {
        public double A { get; } = a;
        public double B { get; } = b;
        public double C { get; } = c;

        public double Discriminant => Math.Pow(B, 2) - (4 * A * C);

        public double GCD => GreatestCommonDivisor(GreatestCommonDivisor(A, B), C);

        public override string ToString() => $"{A}x^2+{B}x+{C}";

        public override int GetHashCode() => HashCode.Combine(
            (A / GCD).GetHashCode(),
            (B / GCD).GetHashCode(),
            (C / GCD).GetHashCode()
            );

        public override bool Equals(object? obj)
        {
            if (obj is not MasodfokuKifejezes x) return false;

            return Math.Abs((A / GCD) - (x.A / x.GCD)) < 1e-9
                && Math.Abs((B / GCD) - (x.B / x.GCD)) < 1e-9
                && Math.Abs((C / GCD) - (x.C / x.GCD)) < 1e-9;
        }

        public static MasodfokuKifejezes operator +(MasodfokuKifejezes a, MasodfokuKifejezes b)
        {
            return new MasodfokuKifejezes(a.A + b.A, a.B + b.B, a.C + b.B);
        }

        public static MasodfokuKifejezes operator -(MasodfokuKifejezes a, MasodfokuKifejezes b)
        {
            return new MasodfokuKifejezes(a.A - b.A, a.B - b.B, a.C - b.B);
        }

        public static bool operator ==(MasodfokuKifejezes a, MasodfokuKifejezes b) => a.Equals(b);
        public static bool operator !=(MasodfokuKifejezes a, MasodfokuKifejezes b) => !a.Equals(b);

        private static double GreatestCommonDivisor(double a, double b)
        {
            while (b > 1e-9)
            {
                (a, b) = (b, a % b);
            }

            return Math.Abs(a);
        }
    }
}
