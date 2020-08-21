using System;

namespace RefValueTypes
{
    /// <summary>
    /// Класс - это Ссылочный тип.
    /// </summary>
    class ComplexClass
    {
        public float re, im;
    }

    /// <summary>
    /// Структура - это Значащий тип
    /// </summary>
    struct ComplexStruct
    {
        public float re, im;
    }
    
    class Program
    {
        // Входная точка программы
        static void Main(string[] args)
        {
            ComplexClass a, b;        // Определяем 2 переменные
            a = new ComplexClass();   // Создаем экземпляр обьекта
            // Инициализируем его поля
            a.re = 1;
            a.im = 0;
            
            b = a; // Присваиваем переменные ссылочного типа (обе переменные будут ссылаться на один и тот же объект)

            // Распечатываем значения переменных
            Console.WriteLine("Переменные a и b - ссылочного типа - class");
            Console.WriteLine("a.re = " + a.re + " a.im = " + a.im);
            Console.WriteLine("b.re = " + b.re + " b.im = " + b.im);
            Console.WriteLine("Изменяем b");
            // Изменяем b
            b.re = 5;
            b.im = 7;
            // Еще раз распечатываем значения переменных
            Console.WriteLine("a.re = " + a.re + " a.im = " + a.im);
            Console.WriteLine("b.re = " + b.re + " b.im = " + b.im);

            // ----------------------------------------------------------------------------------------------
            // То же самое, но с переменными значащего типа - struct
            ComplexStruct c, d;        // Определяем 2 переменные
            c = new ComplexStruct();   // Создаем экземпляр обьекта
            // Инициализируем его поля
            c.re = 1;
            c.im = 0;

            d = c; // Присваиваем переменные значащего типа (создается копия объекта c и присваивается переменной d)

            // Распечатываем значения переменных
            Console.WriteLine("Переменные c и d - значащего типа - struct");
            Console.WriteLine("c.re = " + c.re + " c.im = " + c.im);
            Console.WriteLine("d.re = " + d.re + " d.im = " + d.im);
            Console.WriteLine("Изменяем d");
            // Изменяем d
            d.re = 5;
            d.im = 7;
            // Еще раз распечатываем значения переменных
            Console.WriteLine("c.re = " + c.re + " c.im = " + c.im);
            Console.WriteLine("d.re = " + d.re + " d.im = " + d.im);

            Console.ReadLine(); // Ожидать нажатия ENTER
        }
    }
}