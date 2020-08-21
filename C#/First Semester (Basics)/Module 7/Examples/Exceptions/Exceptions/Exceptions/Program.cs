using System;

namespace Exceptions
{
    class Program
    {
        static void Main()
        {
            try
            {
                EnterInt();
            }
            // Эти обработчики будут вызываться только, если в методе возникли исключения, и они там не были обработаны
            catch (MustBeMoreThenZeroException e) when (e.EnteredValue < -100) // C# 6
            {
                Console.WriteLine("В методе Main поймали собственное исключение MustBeMoreThenZeroException при условии EnteredValue < -100");
                Console.WriteLine("Сообщение исключения: {0}", e.Message);
                Console.WriteLine("Дополнительное свойство введенное нами: {0}", e.EnteredValue);
            }
            catch (MustBeMoreThenZeroException e)
            {
                Console.WriteLine("В методе Main поймали собственное исключение MustBeMoreThenZeroException");
                Console.WriteLine("Сообщение исключения: {0}", e.Message);
                Console.WriteLine("Дополнительное свойство введенное нами: {0}", e.EnteredValue);
            }
            catch (Exception e) // Если в методе возникли исключения, и они не были обработаны, то мы их поймаем здесь
            {
                Console.WriteLine("Исключение поймали в методе Main");
                Console.WriteLine("Сообщение исключения: {0}", e.Message);
                if (e.InnerException != null) Console.WriteLine("Сообщение внутреннего исключения: {0}", e.InnerException.Message);
            }

            Console.ReadLine();
        }

        private static void EnterInt()
        {
            Console.WriteLine("Введите число:");
            string s = Console.ReadLine();
            int i = 0;
            try
            {
                i = int.Parse(s); // Попытка привести строку к числу
            }
            catch (OverflowException) // Переполнение (не указали переменную (она нам не нужна), но указали тип исключения)
            {
                Console.WriteLine("Огого. Многовато.");
            }
            catch (FormatException e) // Неправильный формат числа
            {
                // Для примера, генерируем наше новое исключение, а исходное передаем в качестве InnerException
                throw new Exception("Нечего буквы вводить. Число - это только циферки", e);
            }
            catch (Exception e) // отлов всех остальных исключений
            {
                Console.WriteLine("Ой, какое-то другое исключение. Сам смотри текст: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally. Он выполняется всегда.");
            }

            if (i < 0) throw new MustBeMoreThenZeroException(i); // По нашей прихоти генерируем собственное исключение, если число < 0
        }
    }
}
