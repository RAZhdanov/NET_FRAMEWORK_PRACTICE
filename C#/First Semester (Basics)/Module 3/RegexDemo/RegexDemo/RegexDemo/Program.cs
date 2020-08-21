using System;
using System.Text.RegularExpressions;

// Демонстрация работы с регулярными выражениями

namespace RegexDemo
{
    class Program
    {
        static void Main()
        {
            Console.Write("\nВведите номер телефона: ");
            string phoneNumber = Console.ReadLine();

            // Соответствие строго 111-11-11
            const string pattern1 = @"^\d{3}-\d{2}-\d{2}$";

            // Соответствие вариантам 
            // 111-11-11
            // 111-1111 
            // (111) 111-11-11
            // (111)-111-11-11
            // (111)111-11-11
            // 111-111-11-11
            // (111)-111-1111  
            const string pattern2 = @"^(\(?\d{3}\)?[ -]?)?\d{3}-\d{2}-?\d{2}$";

            // аналог pattern1, но без указания начала и окончания строки
            const string pattern3 = @"\d{3}-\d{2}-\d{2}";

            // Работа с экземпляром класса Regex
            Regex regex = new Regex(pattern1);
            Console.WriteLine("Номер соответствует регулярному выражению ?");
            Console.WriteLine(pattern1);
            Console.WriteLine(regex.IsMatch(phoneNumber));

            // Работа со статическим методом класса Regex
            Console.WriteLine("\nНомер соответствует регулярному выражению ?");
            Console.WriteLine(pattern2);
            Console.WriteLine(Regex.IsMatch(phoneNumber, pattern2));

            // Выделим все вхождения паттерна pattern3 в веденную строку (введите, например, 111-11-11-222-22-22-3333-33-33)
            Console.WriteLine($"\nВхождения паттерна {pattern3} в веденную строку:");
            foreach (Match match in Regex.Matches(phoneNumber, pattern3))
            {
                Console.WriteLine(match.Value);
            }

            Console.ReadKey();
        }
    }
}
