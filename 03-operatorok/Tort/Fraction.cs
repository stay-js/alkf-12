namespace Tort
{
    internal class Fraction
    {
        public int Numerator { get; init; }
        public int Denominator { get; init; }

        public string DecimalFraction => ((double)Numerator / Denominator).ToString();

        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            int gcd = GCD(numerator, denominator);
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        public override string ToString() => Denominator == 1
            ? Numerator.ToString()
            : $"{Numerator}/{Denominator}";

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;

            return new Fraction(numerator, denominator);
        }

        public static Fraction operator +(Fraction a, int b)
        {
            return new Fraction(a.Numerator + b * a.Denominator, a.Denominator);
        }

        public static Fraction operator +(int a, Fraction b)
        {
            return new Fraction(b.Numerator + a * b.Denominator, b.Denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;

            return new Fraction(numerator, denominator);
        }

        public static Fraction operator -(Fraction a, int b)
        {
            return new Fraction(a.Numerator - b * a.Denominator, a.Denominator);
        }

        public static Fraction operator -(int a, Fraction b)
        {
            return new Fraction(b.Numerator - a * b.Denominator, b.Denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator *(Fraction a, int b)
        {
            return new Fraction(a.Numerator * b, a.Denominator);
        }

        public static Fraction operator *(int a, Fraction b)
        {
            return new Fraction(b.Numerator * a, b.Denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0) throw new DivideByZeroException();

            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static Fraction operator /(Fraction a, int b)
        {
            if (b == 0) throw new DivideByZeroException();

            return new Fraction(a.Numerator, a.Denominator * b);
        }

        public static Fraction operator /(int a, Fraction b)
        {
            if (b.Numerator == 0) throw new DivideByZeroException();

            return new Fraction(b.Numerator, b.Denominator * a);
        }

        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

        public override bool Equals(object? obj) => obj is Fraction fraction
            && Numerator == fraction.Numerator
            && Denominator == fraction.Denominator;

        public static bool operator ==(Fraction a, Fraction b) => a.Numerator == b.Numerator
            && a.Denominator == b.Denominator;

        public static bool operator !=(Fraction a, Fraction b) => a.Numerator != b.Numerator
            || a.Denominator != b.Denominator;

        public static bool operator >(Fraction a, Fraction b) =>
            (double)a.Numerator / a.Denominator > (double)b.Numerator / b.Denominator;
        public static bool operator <(Fraction a, Fraction b) =>
            (double)a.Numerator / a.Denominator < (double)b.Numerator / b.Denominator;

        public static bool operator >=(Fraction a, Fraction b) =>
            (double)a.Numerator / a.Denominator >= (double)b.Numerator / b.Denominator;
        public static bool operator <=(Fraction a, Fraction b) =>
            (double)a.Numerator / a.Denominator <= (double)b.Numerator / b.Denominator;

        public static implicit operator Fraction(int x) => new(x, 1);

        public static implicit operator Fraction(double x)
        {
            int denominator = 1;

            while (x % 1 != 0)
            {
                x *= 10;
                denominator *= 10;
            }

            return new Fraction((int)x, denominator);
        }

        public static implicit operator double(Fraction x) => (double)x.Numerator / x.Denominator;

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }

            return Math.Abs(a);
        }
    }
}
