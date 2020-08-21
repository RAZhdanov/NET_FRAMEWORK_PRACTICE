using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace VisualBubbleSort
{
    class Program
    {
        static void Main()
        {
            // Сортировка целых чисел по убыванию
            Random random = new Random();
            int[] ids = new int[10];
            for (int i = 0; i < ids.Length; i++) ids[i] = random.Next(1000);
            PrintArrayWithHighlighting(ids);
            Console.WriteLine("Для начала сортировки нажмите ENTER");
            Console.ReadLine();

            BubbleSorter<int> intSorter = new BubbleSorter<int>();
            intSorter.ElementMoved += SorterOnElementMoved;
            intSorter.Sort(ids, (x, y) => x < y); // Сортировка целых чисел по убыванию
            Console.WriteLine("Сортировка целых чисел завершена");
            Console.ReadLine();

            // Сортировка комплексных чисел по возрастанию модуля
            Console.WriteLine("Сортировка комплексных чисел по возрастанию модуля");
            List <Complex> complexs = new List<Complex>();
            for (int i = 0; i < 10; i++) complexs.Add(new Complex(random.Next(1000), random.Next(1000)));
            PrintArrayWithHighlighting(complexs);
            Console.WriteLine("Для начала сортировки нажмите ENTER");
            Console.ReadLine();

            BubbleSorter<Complex> complexSorter = new BubbleSorter<Complex>();
            complexSorter.ElementMoved += SorterOnElementMoved;
            complexSorter.Sort(complexs, (x, y) => x.Abs > y.Abs); // Сортировка комплексных чисел по возрастанию модуля
            Console.WriteLine("Сортировка комплексных чисел по возрастанию модуля завершена");
            Console.ReadLine();

            // Сортировка комплексных чисел по убыванию вещественной части
            Console.WriteLine("Сортировка тех же комплексных чисел по убыванию вещественной части");
            PrintArrayWithHighlighting(complexs);
            Console.WriteLine("Для начала сортировки нажмите ENTER");
            Console.ReadLine();

            complexSorter.Sort(complexs, (x, y) => x.Re < y.Re); // Сортировка комплексных чисел по убыванию вещественной части
            Console.WriteLine("Сортировка комплексных чисел по убыванию вещественной части завершена");
            Console.ReadLine();
        }

        private static void SorterOnElementMoved<T>(object sender, MovedElementEventArgs<T> movedElementEventArgs)
        {
            PrintArrayWithHighlighting(movedElementEventArgs.Collection, movedElementEventArgs.MovedElementIndexes);
            Thread.Sleep(300); // Задержка на 300 мс, чтобы можно было заметить результат на экране
        }

        private static void PrintArrayWithHighlighting<T>(IList<T> collection, int[] highlightingIndexes = null)
        {
            Console.Clear();

            for (int i = 0; i < collection.Count; i++)
            {
                if (highlightingIndexes?.Contains(i) ?? false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(collection[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine(collection[i]);
                }
            }
        }
    }
}
