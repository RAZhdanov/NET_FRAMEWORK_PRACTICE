using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/*
 * Задание 8. Поиск значения обратной функции (делегаты, анонимные методы, лямбда выражения, события) 
 
    Создайте класс, содержащий метод, который для переданной на вход произвольной строго монотонной на отрезке [a,b] функции 
    y=f(x) численно находит x= f -1(y) по заданному y и с заданной точностью ε. При этом класс должен информировать вызывающий код
    о достигнутой на данный момент точности вычисления y с помощью генерации события. 
    Итого, метод должен принимать вход следующие параметры: 
    • Отрезок [a,b] • функцию f(x), строго монотонную на заданном отрезке 
    • Значение y, для которого будет производиться численное вычисление x = f-1(y). Причем известно, что y лежит в диапазоне [f(a), f(b)]. 
    • ε – погрешность, с которой достаточно найти x 
    Метод должен возвращать значение x = f-1(y) 
    Класс должен содержать событие, которое должен генерировать метод поиска обратной функции 
    Алгоритм численного вычисления x = f-1(y) может быть произвольным, например, делением отрезка пополам. 
 
    Используя полученный метод, найдите значения x, при которых: 
    1. 0.5 = sin(x) на отрезке [0.1, 1.3] с точностью 0,0001 //0.4797
    2. 8 = x2 + sin(x-2) на отрезке [2.5, 3.5] с точностью 0,0001 
    3. Произвольной функции на ваше усмотрение 

    При вычислениях, вызывающий код должен распечатывать на экране ход выполнения вычислений (достигнутую точность на данный момент). 
    Задавайте входную функцию для метода, как делегат, анонимный метод и как лямбда выражение. 
 */
namespace DelegateProject
{

    class Program
    {
        private static void CurrentPrecisionShowed(object sender, VisualInverseFunction visualInverseFunction)
        {
            DisplayPrecision(visualInverseFunction.m_precision);
            Thread.Sleep(300); // Задержка на 300 мс, чтобы можно было заметить результат на экране
        }
        private static void DisplayPrecision(double precision)
        {
            Console.WriteLine("Current precision is: " + precision);
        }
        static void Main(string[] args)
        {
            //1. 0.5 = sin(x) на отрезке [0.1, 1.3] с точностью 0,0001
            Console.WriteLine("Function is: [0.5 = sin(x)] with the range from 0.1 to 1.3 with the following precision 0,0001");

            Inverter inverted_function1 = new Inverter();
            Func<double, double> func1 = Math.Sin; //as a function
            inverted_function1.Y_Precision_Event += CurrentPrecisionShowed;
            double dbl_y1 = inverted_function1.Method(0.5, 0.1, 1.3, func1, 0.0001);
            Console.WriteLine("Y = " + dbl_y1);
            Console.WriteLine("To continue press ENTER, please");
            Console.WriteLine();

            Console.ReadLine();


            //2. 8 = x2 + sin(x - 2) на отрезке[2.5, 3.5] с точностью 0,0001
            Console.WriteLine("Function is: [8 = x^2 + sin(x - 2)] with the range from 2.5 to 3.5 with the following precision 0,0001");
            Inverter inverted_function2 = new Inverter();
            Func<double, double> func2 = delegate (double x) //as an anonymous function
            {
                return Math.Pow(x, 2) + Math.Sin(x - 2);
            };
            inverted_function2.Y_Precision_Event += CurrentPrecisionShowed;
            double dbl_y2 = inverted_function2.Method(8, 2.5, 3.5, func2, 0.0001);
            Console.WriteLine("Y = " + dbl_y2);
            Console.WriteLine("To continue press ENTER, please");
            Console.WriteLine();
            Console.ReadLine();


            //3. Произвольная функция на ваше усмотрение 
            Console.WriteLine("Function is: [51 = 22x^2 + 62x - 2] with the range from 0 to 100000 with the following precision 0,0001");
            Inverter inverted_function3 = new Inverter();
            Func<double, double> func3 = x => 22 * Math.Pow(x, 2) + 62 * x - 2; //as a lambda function
            inverted_function3.Y_Precision_Event += CurrentPrecisionShowed;
            double dbl_y3 = inverted_function3.Method(51, 0, 100000, func3, 0.0001);
            Console.WriteLine("Y = " + dbl_y3);
            Console.WriteLine("To continue press ENTER, please");
            Console.WriteLine();
            Console.ReadLine();
        }

    }
}
