using System;
using System.Collections.Concurrent; //Для желающих: Дополнительно реализуйте алгоритм сохранения с использование стандартной коллекции  BlockingCollection<T>
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading; //В учебных целях нельзя использовать коллекции из пространства имен System.Collections.Concurrent
using System.Threading.Tasks;
using DAL;

namespace Module_12 //Многопоточное получение и сохранение данных. (Многопоточность. Синхронизация потоков).
{
    /// <summary>
    /// Реализуйте двухпоточное сохранение большого объема данных: 
    /// - один поток читает данные порциями, 
    /// - второй сохраняет в текстовый файл. 
    /// 
    /// Примечание: 
    /// Размер сохраняемого текстового файла будет порядка 700 Mb.
    /// Для работы модуля – DAL.dll в этой же папке должен лежать прилагаемый файл Names.txt
    /// </summary>
    class Program
    {
        /// <summary>
        /// Ограничения: 
        /// 1. В учебных целях нельзя использовать коллекции из пространства имен System.Collections.Concurrent. 
        /// 
        /// 2. Суммарное количество объектов класса Person в очереди не должно превышать 100 000 экземпляров.
        /// 
        /// Например, если очередь ограничена 100 элементами Person[],
        /// то каждый элемент очереди – массив Person[] – должен быть ограничен 1000. 
        /// 
        /// Если очередь ограничена 1000 элементами Person[], 
        /// то каждый элемент очереди – массив Person[] – должен быть ограничен 100. 
        /// 
        /// Если очередь ограничена 100 000 элементами, 
        /// то каждый элемент очереди – объект класса Person.
        /// 
        /// Выбор соотношения этих параметров лежит на разработчике. Выбор должен быть обоснован. 
        /// 
        /// Для удобства максимальная длина очереди и размер блока в очереди должны задаваться константами.
        /// 
        /// Для желающих:  
        /// 
        /// Дополнительно реализуйте алгоритм сохранения с использование стандартной коллекции  BlockingCollection<T>
        /// 
        /// </summary>
        /// 
        static void Main(string[] args)
        {
            const int max_quantity_of_people_in_queue = 100000;

            //1. если очередь ограничена 100 элементами Person[], то каждый элемент очереди – массив Person[] – должен быть ограничен 1000.
            //2. если очередь ограничена 1000 элементами Person[], то каждый элемент очереди – массив Person[] – должен быть ограничен 100.
            //3. если очередь ограничена 100 000 элементами, то каждый элемент очереди – объект класса Person.
            const int pack_limit_of_people = 10000;

            //Вычислим количество массивов, которые могут храниться в очереди
            const int max_quantity_of_arrays_in_queue = max_quantity_of_people_in_queue / pack_limit_of_people;


            //1.Напишем однопоточную программу
            using (FileStream fileStream = new FileStream("123_not_concurrent.txt", FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    PersonsProvider provider = new PersonsProvider();
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    {///START!!!!!!!!!!!!!!
                        int i = 1;
                        while (true)
                        {
                            Person[] people = provider.GetPersons(i, pack_limit_of_people); //(получил блок, сохранил, получил - сохранил и т.д.) 
                            foreach (Person person in people)
                            {
                                streamWriter.WriteLine(person);
                            }

                            if (people.Length == 0)
                            {
                                break;
                            }
                            i += pack_limit_of_people;
                        }
                    }///STOP!!!!!!!!!!!!!!
                    stopWatch.Stop();
                    Console.WriteLine($"Время работы алгоритма в однопоточном режиме составляет {stopWatch.ElapsedMilliseconds} мс");
                }
            }



            //2.Напишем программу, работающую в многопоточном режиме
            Stopwatch stopWatch_conc = new Stopwatch();
            stopWatch_conc.Start();
            {///START!!!!!!!!!!!!!!
                Class1 class1 = new Class1(max_quantity_of_people_in_queue, pack_limit_of_people);

                Thread thread_producer = new Thread(new ThreadStart(class1.Producer));
                Thread thread_consumer = new Thread(new ThreadStart(class1.Consumer));

                thread_producer.Start();
                thread_consumer.Start();
                thread_consumer.Join();
            }///STOP!!!!!!!!!!!!!!
            stopWatch_conc.Stop();
            Console.WriteLine($"Время работы алгоритма в многопоточном режиме составляет {stopWatch_conc.ElapsedMilliseconds} мс");


            /*
             * Для желающих: Дополнительно реализуйте алгоритм сохранения с использование стандартной коллекции  BlockingCollection<T>
             */
            BlockingCollection<Person[]> bQueueCollection = new BlockingCollection<Person[]>(max_quantity_of_arrays_in_queue);
            Stopwatch stopWatch_conc_BlockingCollection = new Stopwatch();
            stopWatch_conc_BlockingCollection.Start();

            using (FileStream fileStream = new FileStream("123_concurrent_BlockingCollection.txt", FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    PersonsProvider provider1 = new PersonsProvider();
                    Task.Factory.StartNew(() =>
                    {
                        int i = 1;
                        while (true)
                        {
                            Person[] people = provider1.GetPersons(i, pack_limit_of_people);
                            bQueueCollection.Add(people);
                            i += pack_limit_of_people;
                            if (people.Length == 0)
                            {
                                break;
                            }
                        }
                        bQueueCollection.CompleteAdding();
                    });


                    Task consumerThread = Task.Factory.StartNew(() =>
                    {
                        foreach (Person[] people in bQueueCollection.GetConsumingEnumerable())
                        {
                            foreach (Person person in people)
                            {
                                streamWriter.WriteLine(person);
                            }
                        }
                    });


                    Task.WaitAll(consumerThread);
                }
            }

            if (bQueueCollection.IsCompleted)
            {
                stopWatch_conc_BlockingCollection.Stop();
            }
            Console.WriteLine($"Время работы алгоритма в многопоточном режиме с коллекцией BlockingCollection составляет {stopWatch_conc_BlockingCollection.ElapsedMilliseconds} мс");
        }
    }
}
