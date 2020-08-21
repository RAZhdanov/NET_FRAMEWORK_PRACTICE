using System;

namespace ListDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Список int:");
            List<int> intList = new List<int>();
            intList.Add(5);
            intList.Add(12);
            intList.Add(11);
            intList.Add(45);
            intList.Print();
            int secondElement = intList[1];
            Console.WriteLine($"Второй элемент списка {secondElement}");

            Console.WriteLine("Список string:");
            List<string> stringList = new List<string>();
            stringList.Add("Собака");
            stringList.Add("Кошка");
            stringList.Add("Олень");
            Console.WriteLine("Список string содержит:");
            stringList.Print();

            Console.WriteLine("Сравнение типов");
            Console.WriteLine($"intList Type: {intList.GetType()}");
            Console.WriteLine($"stringList Type: {stringList.GetType()}");
            Console.WriteLine($"Типы одинаковые ? : {intList.GetType() == stringList.GetType()}");

            Console.WriteLine("Список Complex:");
            List<Complex> complexList = new List<Complex>();
            Complex complex1 = new Complex(12, 1);
            Complex complex2 = new Complex(2, 13);
            complexList.Add(complex1);
            complexList.Add(complex2);
            complexList.Add(new Complex(3, 15));
            complexList.Add(complex1);
            complexList.Add(new Complex(3, 6));
            complexList.Print();

            Complex complex3 = complexList[2];
            Console.WriteLine($"3-элемент списка {complex3}");
            Console.WriteLine("Удалили его");
            complexList.Remove(complex3);
            Console.WriteLine("Список после удаления");
            complexList.Print();

            Console.WriteLine("Удалили complex1 (удалился первый найденный элемент complex1)");
            complexList.Remove(complex1);
            complexList.Print();

            Console.WriteLine("Удалили new Complex(3, 6) (ничего не удалилось, ссылки разные)");
            complexList.Remove(new Complex(3, 6));
            complexList.Print();

            Console.ReadLine();
        }
    }
}

