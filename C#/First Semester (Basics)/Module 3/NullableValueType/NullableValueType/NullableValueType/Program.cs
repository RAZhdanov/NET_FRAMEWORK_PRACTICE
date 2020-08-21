using System;

// Пример работы с типами-значениями, допускающими неопределенное значение (Nullable<T>):

namespace NullableValueType
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите число:");
            string s = Console.ReadLine();
            Nullable<int> i = TryParse(s); // можно указать тип как  Nullable<int>, а можно как в возвращаемом параметре метода - int?
            if (i.HasValue) Console.WriteLine("Вы ввели число {0}", i); // Если число задано, то распечатываем его. Можно указать i.Value
            int j = i ?? -1; // если i не задано, то i ?? -1 вернет -1. Т.е. значение по умолчанию. Иначе j = i.Value;
            Console.WriteLine("j = {0}", j);

            Console.ReadLine();
        }

        static int? TryParse(string s)
        {
            if (int.TryParse(s, out int result)) return result; // int автоматически преобразуется в int?
            return null;
        }
    }
}
