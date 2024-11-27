using System.ComponentModel.DataAnnotations;

namespace Masodfoku_Lib
{
    public class MasodfokuKifejezes(double a, double b, double c)
    {
        public double A { get; } = a;
        public double B { get; } = b;
        public double C { get; } = c;

        public double Discriminant => Math.Pow(B, 2) - (4 * A * C);

        public override string ToString() => $"{A}x^2+{B}x+{C}";

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

        public override int GetHashCode() => HashCode.Combine(A.GetHashCode(), B.GetHashCode(), C.GetHashCode());
        
        public override bool Equals(object? obj)
        {
            if (obj is not MasodfokuKifejezes x) return false;

            return Math.Max(A, x.A) % Math.Min(A, x.A) == 0
                && Math.Max(B, x.B) % Math.Min(B, x.B) == 0
                && Math.Max(C, x.C) % Math.Min(C, x.C) == 0;
        }
    }
}
