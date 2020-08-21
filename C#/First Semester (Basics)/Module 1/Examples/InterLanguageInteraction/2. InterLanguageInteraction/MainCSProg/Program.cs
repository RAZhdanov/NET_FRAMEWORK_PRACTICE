using System;
using VBLibrary.VBCalculator;

namespace MainCSProg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание и использование типа написанного на другом языке
            Calculator сalculator = new Calculator();
            Console.WriteLine("Создание и использование типа, написанного на другом языке\nСложение 2+6 = {0}", сalculator.Add(2, 6));

            // Использование типа отнаследованного от типа, написанного на другом языке
            AdvancedCalculator advancedCalculator = new AdvancedCalculator();
            Console.WriteLine("Использование типа, отнаследованного от класса, написанного на другом языке\nСложение 3+8 = {0}", advancedCalculator.Add(3, 8));
            Console.WriteLine("Использование типа, отнаследованного от класса, написанного на другом языке\nВычитание 27-13 = {0}", advancedCalculator.Sub(27, 13));

            Console.ReadKey();
        }
    }

    // Наследование от типа, написанного на другом языке
    class AdvancedCalculator : Calculator
    {
        public int Sub(int x, int y)
        {
            return x - y;
        }
    }
}
