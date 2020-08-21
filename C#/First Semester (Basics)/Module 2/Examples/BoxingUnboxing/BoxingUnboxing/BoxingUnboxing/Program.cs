using System;

namespace BoxingUnboxing
{
    // Проблемы Boxing / Unboxing
    // https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/types/boxing-and-unboxing
    class Program
    {
        static void Main()
        {
            int i = 123;

            // Создается новый объект в куче и значение копируется
            object o = i;

            i = 456; // Значение в o при этом не меняется
            int j = (int) o;

            // Изменения i не повлияли на o
            Console.WriteLine("i = {0}", i);
            Console.WriteLine("o = {0}", o);
            Console.WriteLine("j = {0}", j);

            Print(i); // незаметный боксинг

            Console.ReadLine();
        }

        public static void Print(object obj)
        {
            Console.WriteLine("Незаметный боксинг при вызове Print. obj = {0}", obj);
        }
    }
}
