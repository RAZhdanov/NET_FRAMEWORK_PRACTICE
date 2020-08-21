using System;
using System.Collections.Generic;
using System.Text;

// Пример работы со строками и StringBuilder

namespace Strings
{
    class Program
    {
        static string CreateSqlCommandString(IEnumerable<int> ids)
        {
            string result = "select CustomerName from Customers where CustomerID in (";
            foreach (int id in ids)
            {
                result += id.ToString() + ", "; // Каждый раз создается новый экземпляр класса string
            }
            result = result.Remove(result.Length - 2, 2); // Создается новый экземпляр класса string
            result += ")"; // Создается новый экземпляр класса string
            return result;
        }

        static string CreateSqlCommandStringUsingStringBuilder(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder(); // Класс динамически изменяемой строки
            sb.Append("select CustomerName from Customers where CustomerID in (");
            foreach (int id in ids)
            {
                sb.AppendFormat("{0}, ", id);
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(")");
            return sb.ToString();
        }

        static string CreateSqlCommandStringUsingJoin(IEnumerable<int> ids)
        {
            return string.Format("select CustomerName from Customers where CustomerID in ({0})", string.Join(", ", ids));
        }

        static string CreateSqlCommandStringUsingJoinAndStringInterpolation(IEnumerable<int> ids)
        {
            return $"select CustomerName from Customers where CustomerID in ({string.Join(", ", ids)})"; // C# 6 (Visual Studio 2015)
        }

        static void Main()
        {
            // Сравнение строк (посимвольное, а не по ссылке)
            string hi = "hello";
            string hi2 = "hello";
            Console.WriteLine("Строки hi=\"{0}\" и hi2=\"{1}\" равны ? {2}\n", hi, hi2, hi == hi2);

            // Методы класса string не меняют саму строку
            string hi3 = hi.Remove(hi.Length - 1, 1);
            Console.WriteLine("hi3=\"{0}\", а hi не изменилась и равна \"{1}\"\n", hi3, hi);

            // Работа с сильно изменяемыми строками 
            int[] ids = new int[] { 10, 12, 13, 14 };
            // Так делать не нужно
            string command = CreateSqlCommandString(ids);
            Console.WriteLine(command);

            // Построения SQL строки с использованием класса StringBuilder
            command = CreateSqlCommandStringUsingStringBuilder(ids);
            Console.WriteLine(command);

            // Альтернативный вариант построения SQL строки (string.Join())
            command = CreateSqlCommandStringUsingJoin(ids);
            Console.WriteLine(command);

            // Альтернативный вариант построения SQL строки, используя string.Join() и интерполяцию строк (C# 6)
            command = CreateSqlCommandStringUsingJoinAndStringInterpolation(ids);
            Console.WriteLine(command);

            Console.ReadKey();

            // P.S. Пожалуйста, реально, никогда не используйте такие варианты построения SQL запросов. Используйте SqlParameter (ADO.NET)
        }
    }
}
