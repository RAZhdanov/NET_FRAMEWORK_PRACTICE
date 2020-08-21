using System;
using System.Collections;
using System.Collections.Generic;

// Два примера итераторов по бесконечным последовательностям

namespace UnlimitedSequences
{
    class Program
    {
        static void Main()
        {
            // 1. Итерация по арифметической прогрессии

            // Обход коллекции и распечатка ее элементов
            foreach (int i in GetArithm(0, 5))
            {
                Console.WriteLine(i);
                if (i >= 1000) break; // Цикл надо ведь когда-то остановить. Последовательность ведь бесконечная
            }

            // 2. Перечисление всех нечетных чисел
            Console.WriteLine("Нечетные числа.");
            Console.WriteLine("Для начала и окончания вывода нажимайте любую кнопку (кроме Power)");
            Console.ReadKey();

            // Перечисление нечетных чисел
            OddNumbers oddNumbers = new OddNumbers();
            foreach (int i in oddNumbers)
            {
                Console.WriteLine(i);
                if (Console.KeyAvailable) break;
            }
        }

        /// <summary>
        /// Метод, возвращающий бесконечную арифметическую прогрессию
        /// </summary>
        /// <param name="beginValue">начальное значение</param>
        /// <param name="step">шаг прогрессии</param>
        private static IEnumerable<int> GetArithm(int beginValue, int step)
        {
            for (int i = 0; true; i++) // бесконечный цикл
            {
                yield return beginValue + i * step;
            }
        }
    }

    // Класс, представляющий бесконечную последовательность нечетных чисел
    public class OddNumbers : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 1; i < int.MaxValue; i = i + 2) // MaxValue - 2147483647
            {
                yield return i; // запоминает текущее значение i и возвращает его
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
