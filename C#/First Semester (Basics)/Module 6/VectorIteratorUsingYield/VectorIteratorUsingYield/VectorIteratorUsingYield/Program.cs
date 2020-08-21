using System;

namespace VectorIteratorUsingYield
{
    class Program
    {
        static void Main()
        {
            Vector3D vector = new Vector3D(5, 6, 7);

            // Обращение с Vector3D как с последовательностью
            foreach (double item in vector)
            {
                Console.WriteLine(item);
            }

            // За кулисами цикл foreach делает следующее
            //IEnumerator enumerator = ((IEnumerator)vector).GetEnumerator();
            //enumerator.Reset();
            //while (enumerator.MoveNext())
            //{
            //    double item = (double)enumerator.Current;
            //    // Тело цикла
            //    Console.WriteLine(item);
            //}

            Console.ReadLine();
        }
    }
}
