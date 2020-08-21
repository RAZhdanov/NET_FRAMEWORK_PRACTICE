using System;
using System.Collections;

// Демонстрация класса ArrayList
namespace ArrayListDemo
{
    class Program
    {
        static void Main()
        {
            // Массив object с автоматически увеличивающимся размером
            ArrayList array = new ArrayList();
            // Добавление элемента в массив
            array.Add(123);
            array.Add("Hello");
            array.Add(DateTime.Now);
            // Сортировка массива объектов.
            // А как сортировать произвольные объекты ?
            // Для этого написали свой IComparer, который, для примера, сравнивает 2 произвольных объекта как 2 строки текстового представления объектов
            array.Sort(new ObjectAsStringComparer());
            // Распечатка массива (также можно применять цикл foreach)
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i].ToString());
            }

            Console.ReadKey(); // Чтобы консольное окно сразу не закрылось
        }
    }

    class ObjectAsStringComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return x.ToString().CompareTo(y.ToString());
        }
    }        
}
