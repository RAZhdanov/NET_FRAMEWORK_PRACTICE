using System;

// Делегаты как параметры функций

namespace Integral
{
    class Program
    {
        static void Main()
        {
            Integrator integrator = new Integrator();

            // Интегрирование с использованием своего делегата
            double result = integrator.Integrate(1, 10, 1000, new Integrator.RealFunc(Program.Square));
            Console.WriteLine($"Результат интегрирования x*x: {result}");
            result = integrator.Integrate(1, 10, 1000, Program.Square);
            Console.WriteLine($"Тот же результат, используя краткую запись: {result}");
            result = integrator.Integrate(1, 10, 1000, x => x * x);
            Console.WriteLine($"Тот же результат, используя лямбда выражение: {result}");

            // Интегрирование с использованием стандартного .NET делегата Func<T, TRes>
            result = integrator.IntegrateUsingStandartDelegate(1, 10, 1000, new Func<double, double>(Program.Square));
            Console.WriteLine($"\nРезультат интегрирования x*x: {result}");
            result = integrator.IntegrateUsingStandartDelegate(1, 10, 1000, Square);
            Console.WriteLine($"Тот же результат, используя краткую запись: {result}");
            result = integrator.IntegrateUsingStandartDelegate(1, 10, 1000, x => x * x);
            Console.WriteLine($"Тот же результат, используя лямбда выражение: {result}");

            //  Интегралы разных функций
            result = integrator.Integrate(0, Math.PI / 2, 1000, Math.Sin);
            Console.WriteLine($"\nРезультат интегрирования sin(x): {result}");
            result = integrator.Integrate(1, 10, 1000, x => 10 * x + 12);
            Console.WriteLine($"Результат интегрирования 10x+12: {result}");
            result = integrator.Integrate(1, 10, 1000, x => Math.Log(x) * 27 + 45);
            Console.WriteLine($"Результат интегрирования 27ln(x)+45: {result}");

            Console.ReadKey();
        }

        private static double Square(double x)
        {
            return x * x;
        }
    }
}
