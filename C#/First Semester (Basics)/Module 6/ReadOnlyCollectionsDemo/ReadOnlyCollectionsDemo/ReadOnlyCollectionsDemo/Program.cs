using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// Демонстрация коллекции, доступной только для чтения - ReadOnlyCollection<T>

namespace ReadOnlyCollectionsDemo
{
    class Program
    {
        static void Main()
        {
            WordLibrary library = new WordLibrary();
            Console.WriteLine("Исходное содержимое коллекции");
            List<string> words = library.Words;
            Console.Write("library.Words: ");
            PrintCollection(library.Words);

            // несмотря на то, что свойство WordLibrary.Words доступно только для чтения, коллекцию можно изменить
            // Нарушение инкапсуляции
            words.Add("New Extra Word");
            Console.WriteLine("\nНесмотря на то, что свойство WordLibrary.Words доступно только для чтения,\nколлекцию можно изменить.");
            Console.Write("library.Words: ");
            PrintCollection(library.Words); // изменится сама коллекция

            Console.WriteLine("\nReadOnlyCollection<T> - коллекция только для чтения");
            ReadOnlyCollection<string> readOnlyWords = library.ReadOnlyWords;
            // А коллекция ReadOnlyCollection<string> не позволяет изменять коллекцию. Нет методов изменяющих коллекцию. 
            // readOnlyWords.Add("Что-то"); // Нет такого метода
            // Однако некоторые методы можно вызвать через интерфейсы (явная реализация интерфейса)
            // Если вызвать ((IList<string>)readOnlyWords).Add("Что-то") - то метод вызовет исключение
            Console.WriteLine("Вызов метода Add через интерфейс:");
            try
            {
                ((IList<string>)readOnlyWords).Add("Что-то");
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("NotSupportedException: {0}", e.Message);
            }

            Console.WriteLine("\nReadOnlyCollection<T> - обертка. Всегда содержит актуальную коллекцию"); // ReadOnlyCollection<T> -  wrapper - обертка
            Console.Write("readOnlyWords: ");
            PrintCollection(readOnlyWords);
            Console.WriteLine("После изменения самой коллекции library.Words:");
            library.Words.Add("One more word");
            Console.Write("readOnlyWords: ");
            PrintCollection(readOnlyWords); // Распечатка запомненной ранее коллекции
            Console.WriteLine("Обратите внимание:");
            Console.WriteLine("не было еще одного обращения к свойству объекта library.ReadOnlyWords, \nа коллекция, в запомненной переменной, изменилась");

            // Своя коллекция только для чтения
            MyReadOnlyCollection<string> myReadOnlyWords = library.MyReadOnlyWords;
            Console.WriteLine("\nСвоя коллекция только для чтения"); // Наша MyReadOnlyCollection<T> -  wrapper - обертка
            Console.Write("myReadOnlyWords: ");
            PrintCollection(myReadOnlyWords);
            Console.WriteLine("После изменения самой коллекции library.Words:");
            library.Words.Add("Next word");
            Console.Write("myReadOnlyWords: ");
            PrintCollection(myReadOnlyWords); // Распечатка запомненной ранее коллекции

            Console.ReadKey();
        }

        static void PrintCollection(IList<string> stringList)
        {
            Console.WriteLine(string.Join("; ", stringList));
        }
    }

    class WordLibrary
    {
        public WordLibrary()
        {
            words = new List<string> { "Hello", "Bye", "Go" };
        }
        private List<string> words;

        public List<string> Words
        {
            get
            {
                return words;
            }
        }

        public ReadOnlyCollection<string> ReadOnlyWords
        {
            get
            {
                return new ReadOnlyCollection<string>(words);
            }
        }

        // Пример своей реализации коллекции только для чтения
        public MyReadOnlyCollection<string> MyReadOnlyWords
        {
            get
            {
                return new MyReadOnlyCollection<string>(words);
            }
        }
    }
}
