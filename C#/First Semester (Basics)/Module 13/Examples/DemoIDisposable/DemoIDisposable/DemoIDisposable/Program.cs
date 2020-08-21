using System;
using System.IO;

// Программа распечатывает текущий файл
// Демонстрация IDisposable

namespace DemoIDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\Program.cs"); // Получение пути к текущему cs файлу

            PrintFile printFile = new PrintFile();
            printFile.Open(filePath);
            printFile.Print();
            printFile.Dispose();

            // Этот блок аналогичен использованию try{...} finally{printFile.Dispose();}
            //using (PrintFile printFile = new PrintFile())
            //{
            //    printFile.Open(filePath);
            //    printFile.Print();
            //} // Здесь в любом случае будет вызван метод Dispose()

            Console.ReadKey();
        }
    }

    class PrintFile : IDisposable
    {
        StreamReader stream;

        public void Open(string fileName)
        {
            stream = new StreamReader(fileName); // Открытие файла.
        }

        public void Print()
        {
            Console.WriteLine(stream.ReadToEnd());
        }

        public void Dispose()
        {
            if (stream != null)
            {
                stream.Dispose(); // Закрытие файла
                stream = null;
            }
            Console.WriteLine("From Dispose Method");
        }
    }
}
