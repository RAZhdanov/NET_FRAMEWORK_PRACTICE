using System;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Неважно, как устроен класс Temperature, в каких градусах он хранит температуру
            // Использующему этот класс программисту об этом знать не нужно
            Temperature temperature = new Temperature();
            temperature.TemperatureInCelsius = 100;
            Console.WriteLine("Температура в градусах Цельсия {0}", temperature.TemperatureInCelsius);
            Console.WriteLine("Температура в градусах Фаренгейта {0}", temperature.TemperatureInFahrenheit);
            Console.WriteLine("Температура в градусах Кельвина {0}", temperature.TemperatureInKelvin);

            Console.WriteLine();

            temperature.TemperatureInFahrenheit = 100;
            Console.WriteLine("Температура в градусах Цельсия {0}", temperature.TemperatureInCelsius);
            Console.WriteLine("Температура в градусах Фаренгейта {0}", temperature.TemperatureInFahrenheit);
            Console.WriteLine("Температура в градусах Кельвина {0}", temperature.TemperatureInKelvin);

            Console.ReadLine();

        }
    }
}
