using Tort;

var f1 = new Fraction(1, 2);
Console.WriteLine(f1.ToString());
Console.WriteLine((f1 + f1).ToString());

var f2 = new Fraction(-1, -2);
Console.WriteLine(f2.ToString());

var f3 = new Fraction(1, -2);
Console.WriteLine(f3.ToString());

var f4 = new Fraction(-1, 2);
Console.WriteLine(f4.ToString());

var f5 = new Fraction(123, 3451234);
Console.WriteLine(f5.ToString());
Console.WriteLine(f5.DecimalFraction);
Console.WriteLine((f5 + f1).ToString());

Fraction f6 = 1;
Console.WriteLine(f6.ToString());

Fraction f7 = 1.5;
Console.WriteLine(f7.ToString());

double d = f1;
Console.WriteLine(d);
