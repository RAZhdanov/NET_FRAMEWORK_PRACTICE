using System;

namespace ListDemo
{
    class Complex : IComparable<Complex>
    {
        public double Re { get; set; }
        public double Im { get; set; }
        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }
        public override string ToString()
        {
            return $"{Re} + {Im}i";
        }

        // Реализация интерфейса IComparable<Complex>
        public int CompareTo(Complex other)
        {
            if (Re.Equals(other.Re)) return 0;
            else if (other.Re < Re) return 1;
            else return -1;
        }
    }
}