using System;
using System.Collections.Generic;

// Пример работы со списком

namespace ListDemo
{
    class Program
    {
        static void Main()
        {
            List<Complex> complexList = new List<Complex>(); // обычное создание обобщенного типа
            // Добавление элементов
            complexList.Add(new Complex(4, 5));
            complexList.Add(new Complex(3, 32));
            complexList.Add(new Complex(23, 11));
            complexList.Add(new Complex(-12, 1));

            for (int i = 0; i < complexList.Count; i++) // Count - кол-во элементов в списке
            {
                Console.WriteLine(complexList[i]); // Обращение к элементам по индексу
            }

            complexList.Sort(); // Сортировка списка. Сортировка возможна благодаря тому, что Complex реализует интерфейс IComparable<Complex>
            Console.WriteLine("После сортировки:");
            for (int i = 0; i < complexList.Count; i++)
            {
                Console.WriteLine(complexList[i]);
            }

            // Инициализация коллекции при создании
            Console.WriteLine("Инициализация коллекции при создании");
            Complex complex = new Complex(4, 6);
            complexList = new List<Complex>
            {
                new Complex(5,6),
                complex,
                new Complex(234, 345)
            };
            // Цикл foreach. Цикл по всем элементам коллекции. Применим, поскольку List<T> реализует IEnumerabe
            foreach (Complex item in complexList)
            {
                Console.WriteLine(item);
            }

            // Удаление элемента
            Console.WriteLine("После удаления элементов");
            complexList.Remove(complex); // Заметьте, элемент ищется по ссылке
            complexList.Remove(new Complex(234, 345)); // Ничего не удалит. Новый объект - другой экземпляр. Он не равен объекту в списке
            foreach (Complex item in complexList)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
