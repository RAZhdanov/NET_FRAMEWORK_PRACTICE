using System;

namespace VisualBubbleSort
{
    public class Complex
    {
        public Complex(double re = 0, double im = 0)
        {
            Re = re;
            Im = im;
        }
        public double Re { get; set; }
        public double Im { get; set; }

        public double Abs => Math.Sqrt(Re * Re + Im * Im); // Синтаксис C# 6. Вычислимое свойство как expression body

        public override string ToString() => $"{Re} + {Im}i"; // Синтаксис C# 6. Метод как expression body
    }
}
