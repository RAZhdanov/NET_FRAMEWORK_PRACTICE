using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueProject
{
    class Program
    {
        /* Задание
         * Реализуйте очередь в виде списка, содержащую комплексные числа
         * Реализуйте методы
         * •void Enqueue(Complex с) –помещает число в очередь (в конец) 
         * •Complex Dequeue( )–получает число из начала очереди и удаляет его из очереди 
         * •Complex Peek( )–возвращает число, находящееся в начале очереди 
         * •intCount( )–возвращает кол-во элементов в очереди 
         * •void Print( ) -метод, распечатывающий содержимое очереди.
         * Где Complex –класс комплексных чисел, со свойствами Re и Im и переопределённым методом ToString()
         */

        static void Main(string[] args)
        {
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
            for (int i = 0; i < 5; i++)
            {
                CComplex element = queue.Dequeue();
                if (!ReferenceEquals(element, null))
                    Console.WriteLine(element + "->Dequeue");
            }

            Console.WriteLine("Then we could print all elements again (should be five out of ten)");
            queue.Print(); //Print all elements stored in the queue collection!

            Console.WriteLine("At this step, lets show at the display the top queue element!");
            Console.WriteLine("Top queue element is: {0}", queue.Peek());


            Console.WriteLine("We can also display the overall quantity of elements stored in this queue");
            Console.WriteLine("Overall quantity is: {0}", queue.Count());
        }
    }
}
