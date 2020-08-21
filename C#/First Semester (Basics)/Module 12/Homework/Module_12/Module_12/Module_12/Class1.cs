using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module_12
{
    class Class1
    {
        private FileStream fileStream = null;
        private StreamWriter streamWriter = null;
        private PersonsProvider provider = null;
        private Queue<Person[]> queue = null;

        private int m_max_quantity_of_arrays_in_queue;

        private int m_pack_limit_of_people;

        private object obj = new object();

        private Person[] people = null, tmp = null;

        public Class1(int max_quantity_of_people_in_queue, int pack_limit_of_people)
        {
            fileStream = new FileStream("123_concurrent.txt", FileMode.Create);
            streamWriter = new StreamWriter(fileStream);

            provider = new PersonsProvider();
            queue = new Queue<Person[]>();
            m_pack_limit_of_people = pack_limit_of_people;

            m_max_quantity_of_arrays_in_queue = max_quantity_of_people_in_queue / m_pack_limit_of_people;
        }

        //Метод для первого потока, который читает информацию порциями
        public void Producer()
        {
            Console.WriteLine($"Enter in producer method where threadId = { Thread.CurrentThread.ManagedThreadId }");

            int i = 1;
            int count = 0;
            do
            {
                people = provider.GetPersons(i, m_pack_limit_of_people); //Идентификатор нам известен. Извлекаем данные.

                lock (obj)
                {
                    //Проверяем не произошло ли превышение предельно допустимого количества в очереди, где m_max_quantity_of_arrays_in_queue - это некая константа
                    if (queue.Count < m_max_quantity_of_arrays_in_queue)
                        queue.Enqueue(people);

                    i += m_pack_limit_of_people; //данная переменная представляет собой текущий идентификатор, отображающий с какого именно момента нужно отображать данные
                }

                lock(obj)
                {
                    count = queue.Count;
                }

                while(count >= m_max_quantity_of_arrays_in_queue)
                {
                    lock (obj)
                    {
                        //Если мы достигли предельно допустимого значения по количеству элементов, то крутимся в цикле до тех пор, пока количество не уменьшится до допустимого
                        if (queue.Count < m_max_quantity_of_arrays_in_queue)
                        {
                            queue.Enqueue(people);
                            break;
                        }
                    }
                }
            }
            while (people.Length != 0);
            Console.WriteLine($"Exit from producer where threadId = {Thread.CurrentThread.ManagedThreadId}");
        }

        //Метод для второго потока, который сохраняет информацию в текстовый файл. 
        public void Consumer()
        {
            Console.WriteLine($"Enter in consumer method where threadId = {Thread.CurrentThread.ManagedThreadId}");
            while(true)
            {
                lock (obj) //Лочим object
                {
                    tmp = queue.Count != 0 ? queue.Dequeue() : null;
                }

                if (tmp != null)
                {
                    if (tmp.Length > 0)
                    {
                        foreach (Person person in tmp)
                        {
                            streamWriter.WriteLine(person);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

            }

            streamWriter.Dispose();
            Console.WriteLine($"Exit from consumer where threadId = {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
