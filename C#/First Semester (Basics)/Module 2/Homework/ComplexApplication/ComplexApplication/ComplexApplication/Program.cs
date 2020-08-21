using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComplexApplication
{
    //http://www.msudotnet.ru/Lectures/Lecture2/Task2.pdf


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task #1");

            //Также необходимо реализовать функцию создающую комплексное число по модулю и аргументу (например, static метод создания)
            CComplex myCmplx = CComplex.GetComplexValueThroughModulusAndArgument(8.0622, -0.51914); //должно получиться примерно 7 - 4i


            //Демонстрация неявного приведения из вещественного числа в комплексное
            CComplex a1 = 650.4;
            CComplex b1 = new CComplex(650, -8);

            //Демонстрация явного приведения в вещественное число
            double value = (double)b1;

            //Демонстрация работоспособности перегруженного оператора сравнения
            if (a1 == b1)
            {
                Console.WriteLine("equal!");
            }
            else
                Console.WriteLine("not equal!");

            //Демонстрация корректной распечатки комплексного числа
            Console.WriteLine(b1);

            //Не помню, зачем это сделал, но тут я почему-то решил вывести хеш-коды этих объектов
            Console.WriteLine("HashCodes of complex variables {0} and {1}", a1.GetHashCode(), b1.GetHashCode());


            //А теперь задание №2. Мне кажется, что комментарии тут излишни.
            Console.WriteLine("Task #2");
            Body3D [] body3D = { new CSphere(25.3), new CTetrahedron(46.5), new CParallelepipedon(36.1,42.1,38.1) };
            foreach(var param in body3D)
            {
                Console.WriteLine(param);
            }
        }
    }
}
