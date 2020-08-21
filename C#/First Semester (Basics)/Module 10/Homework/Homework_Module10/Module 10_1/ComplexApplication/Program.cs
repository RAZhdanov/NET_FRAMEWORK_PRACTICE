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
            Console.WriteLine("Homework #1: The implementation of Complex and Body3D classes");

            Console.WriteLine("Task #1: The implementation of Complex class");
            //Также необходимо реализовать функцию создающую комплексное число по модулю и аргументу (например, static метод создания)
            CComplex myCmplx = CComplex.GetComplexValueThroughModulusAndArgument(-0.9184811, 11.370183309); //должно получиться примерно 7 - 4i


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
            Console.WriteLine("Task #2: abstract Body3D class and implementation of polymorphism");
            Body3D [] body3D = { new CSphere(25.3), new CTetrahedron(46.5), new CParallelepipedon(36.1,42.1,38.1) };
            foreach(var param in body3D)
            {
                Console.WriteLine(param);
            }

            Console.WriteLine("Homework #3: Queue implementation");
            Console.WriteLine("Lets input 10 complex numbers into this queue and print all of them");
            Queue<CComplex> queue = new Queue<CComplex>(); //Lets enqueue 10 different elements. For easiness all complex numbers are differ with each other by their Im component.
            queue.Enqueue(new CComplex(10, 1));
            queue.Enqueue(new CComplex(10, 2));
            queue.Enqueue(new CComplex(10, 3));
            queue.Enqueue(new CComplex(10, 4));
            queue.Enqueue(new CComplex(10, 5));
            queue.Enqueue(new CComplex(10, 6));
            queue.Enqueue(new CComplex(10, 7));
            queue.Enqueue(new CComplex(10, 8));
            queue.Enqueue(new CComplex(10, 9));
            queue.Enqueue(new CComplex(10, 10));

            queue.Print(); //Print all elements stored in the queue collection!

            Console.WriteLine("After that we are able to dequeue five elements from the queue. Printed elements are mentioned below");
            for(int i = 0; i < 5; i++)
            {
                CComplex element = queue.Dequeue();
                Console.WriteLine(element);
            }

            Console.WriteLine("Then we could print all elements again (should be five out of ten)");
            queue.Print(); //Print all elements stored in the queue collection!

            Console.WriteLine("At this step, lets show at the display the top queue element!");
            Console.WriteLine("Top queue element is: {0}", queue.Peek());


            Console.WriteLine("We can also display the overall quantity of elements stored in this queue");
            Console.WriteLine("Overall quantity is: {0}", queue.Count());



            CComplex element_x = new CComplex(2,3);
            CComplex element_y = new CComplex(Math.Cos(Math.PI / 4), Math.Sin(Math.PI / 4));
            element_y = 14 * element_y;

            CComplex z = ((element_x+ element_y) * (element_x + element_y)) / 27;
            CComplex myCmplx1 = CComplex.GetComplexValueThroughModulusAndArgument(z);
        }
    }
}
