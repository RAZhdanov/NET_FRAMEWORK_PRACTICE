using System;
using System.Threading;

namespace BubbleSort
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Целые числа:");
            int[] ids = new int[] { 22, 11, 5, 3, 4, 2, 1, 8 };
            PrintArray(ids);
            BubbleSort(ids);
            Console.WriteLine("\nПосле сортировки:");
            PrintArray(ids);

            Console.WriteLine("\nСтроки:");
            string[] strings = new string[] { "собака", "кошка", "жираф", "верблюд", "аист", "бегемот" };
            PrintArray(strings);
            BubbleSort(strings);
            Console.WriteLine("\nПосле сортировки:");
            PrintArray(strings);

            Console.WriteLine("\nПроизвольный класс - Rectangle:");
            Rectangle[] rectangles = new Rectangle[]
            {
                new Rectangle(12, 14),
                new Rectangle(3, 5),
                new Rectangle(10, 10),
                new Rectangle(4, 2),
                new Rectangle(5, 3),
                new Rectangle(1, 1)
            };
            PrintArray(rectangles);
            BubbleSort(rectangles); // Мы реализовали IComparable<Rectangle> как сравнение площадей
            Console.WriteLine("\nПосле сортировки:");
            PrintArray(rectangles);

            Console.ReadKey();
        }

        // Сортирует пузырьком массив произвольных объектов, но реализующих интерфейс IComparable<T>
        private static void BubbleSort<T>(T[] items) where T : IComparable<T>
        {
            int count = 0;
            T temp;
            for (int i = 0; i < items.Length - 1; i++)
            {
                count = 0;
                for (int j = 0; j < items.Length - i - 1; j++)
                {
                    if (items[j].CompareTo(items[j + 1]) > 0)
                    {
                        temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        ++count;
                        // Для наглядной сортировки раскомментируйте эти строки и Console.Clear(); в методе PrintArray
                        // PrintArray(items);
                        // Thread.Sleep(300);
                    }
                }
                if (count == 0) break;
            }
        }

        // Метод, распечатывающий массив произвольных объектов. У каждого объекта вызывается метод ToString()
        private static void PrintArray<T>(T[] arrary)
        {
            // Console.Clear();
            for (int i = 0; i < arrary.Length; i++) Console.WriteLine(arrary[i]);
        }
    }
}
