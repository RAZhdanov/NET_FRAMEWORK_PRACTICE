using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackProject
{

    /* Задание
        Реализуйте Стек 
        Стек должен быть обобщенным типом
        Методы 
        • void Push(T);- добавляет значение в стек 
        • T Pop();-возвращает значение из вершины стека и удаляет его из стека 
        • T Top();-возвращает значение из вершины стека, не удаляя его из стека 
        • int Count();-возвращает количество значений в стеке
        В основном классе создайте обобщенный метод, создающий и заполняющий стек некоторым количеством объектов со значениями по умолчанию 
        Создайте код для “тестирования”вашего стека
        Потребуйте от типа T, чтобы он реализовывал ICloneable и реализуйте T Top()так, чтобы он возвращал копию объекта, а не сам объект 
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework #4: Stack implementation");
            Console.WriteLine("Lets input 10 complex numbers into this stack and print all of them");
            Stack<CComplex> stack = new Stack<CComplex>(); //Lets push 10 different elements. For easiness all complex numbers are differ with each other by their Im component.
            stack.Push(new CComplex(10, 1));
            stack.Push(new CComplex(10, 2));
            stack.Push(new CComplex(10, 3));
            stack.Push(new CComplex(10, 4));
            stack.Push(new CComplex(10, 5));
            stack.Push(new CComplex(10, 6));
            stack.Push(new CComplex(10, 7));
            stack.Push(new CComplex(10, 8));
            stack.Push(new CComplex(10, 9));
            stack.Push(new CComplex(10, 10));

            stack.Print(); //Print all elements stored in the stack collection!

            Console.WriteLine("After that we are able to pop five elements from the stack. Printed elements are the following");
            for (int i = 0; i < 5; i++)
            {
                CComplex element = stack.Pop();
                if (!ReferenceEquals(element, null))
                    Console.WriteLine(element + " ->Pop ");
            }

            Console.WriteLine("Then we could print all elements again (should be five out of ten)");
            stack.Print(); //Print all elements stored in the stack collection!

            Console.WriteLine("At this step, lets show at the display the top stack element!");
            Console.WriteLine("Top stack element is: {0}", stack.Top());


            Console.WriteLine("We can also display the overall quantity of elements stored in this stack");
            Console.WriteLine("Overall quantity is: {0}", stack.Count());

        }
    }
}
