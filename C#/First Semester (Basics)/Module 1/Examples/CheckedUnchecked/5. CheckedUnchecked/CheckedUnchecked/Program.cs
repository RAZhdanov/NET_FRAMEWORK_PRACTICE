using System;

namespace CheckedUnchecked
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число. Для окончания работы нажмите ENTER.");
            string s = Console.ReadLine(); // Ввод строки

            while (s.Length != 0) // Если строка пустая, то выход из цикла
            {
                int i = int.Parse(s); // Преобразование строки в целое число
                try
                {
                    unchecked // Отключение проверки переполнения
                    {
                        Console.WriteLine("Short-значение, unchecked: " + (short)i);
                    }  // end of unchecked
                    checked // Включение проверки переполнения
                    {
                        Console.WriteLine("Short-значение, checked: " + (short)i);
                    }  // end of unchecked

                    Console.WriteLine("Byte-значение, unchecked: " + unchecked((byte)i));
                    Console.WriteLine("Byte-значение, checked: " + checked((byte)i));

                    // По-умолчанию проверка переполнения отключена, но ее можно включить в свойствах проекта во вкладке Build->Advanced...
                    // Однако если значение выражения может быть вычислено в процессе компиляции программы, то употребляется контекст checked
                    // Пример byte h = (byte) (255 + 100); // вызовет ошибку в процессе компиляции
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e);
                }  // end of try-catch()

                Console.WriteLine("\nВведите число. Для окончания работы нажмите ENTER.");
                s = Console.ReadLine(); // Ввод строки
            }  // end of while
        }
    }
}
