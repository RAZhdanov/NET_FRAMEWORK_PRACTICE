using System;
using System.IO;

namespace Serialization
{
    class Program
    {
        private static readonly string ComplexBinaryFileName = Path.Combine(Environment.CurrentDirectory, "ComplexStore.bin");
        private static readonly string ComplexSoapFileName = Path.Combine(Environment.CurrentDirectory, "ComplexStore.soap");
        private static readonly string VectorXmlFileName = Path.Combine(Environment.CurrentDirectory, "VectorStore.xml");
        private static readonly string VectorArrayXmlFileName = Path.Combine(Environment.CurrentDirectory, "VectorArrayStore.xml");

        static void Main()
        {
            // -------------------------------------------------------------------------------------
            Console.WriteLine("Демонстрация сериализации в Двоичный формат");
            IProvider<Complex> complexProvider = new ComplexBinaryProvider(ComplexBinaryFileName);
            Complex complex = new Complex(27, 14);
            SerializationDemo(complexProvider, ComplexBinaryFileName, complex);

            // -------------------------------------------------------------------------------------
            Console.WriteLine("Демонстрация сериализации в SOAP формат");
            complexProvider = new ComplexSoapProvider(ComplexSoapFileName);
            complex = new Complex(7, 5);
            SerializationDemo(complexProvider, ComplexSoapFileName, complex);

            // -------------------------------------------------------------------------------------
            Console.WriteLine("Демонстрация сериализации в XML формат");
            IProvider<Vector3D> vectorProvider = new VectorXmlProvider(VectorXmlFileName);
            Vector3D vector = new Vector3D { X = 5.0, Y = 45, Z = 14.3 };
            SerializationDemo(vectorProvider, VectorXmlFileName, vector);

            // -------------------------------------------------------------------------------------
            Console.WriteLine("Демонстрация сериализации массива в XML формат");
            IProvider<Vector3D[]> vectorArrayProvider = new VectorArrayXmlProvider(VectorArrayXmlFileName);
            Vector3D[] vectorArray = new Vector3D[]
            {
                new Vector3D(5, 10, 15),
                new Vector3D(2, 3, 23),
                new Vector3D(33, 22, 11)
            };
            SerializationDemo(vectorArrayProvider, VectorArrayXmlFileName, vectorArray);

            if (File.Exists(ComplexBinaryFileName)) File.Delete(ComplexBinaryFileName);
            if (File.Exists(ComplexSoapFileName)) File.Delete(ComplexSoapFileName);
            if (File.Exists(VectorXmlFileName)) File.Delete(VectorXmlFileName);
            if (File.Exists(VectorArrayXmlFileName)) File.Delete(VectorArrayXmlFileName);
        }

        private static void SerializationDemo<T>(IProvider<T> provider, string fileName, T value)
        {
            Console.WriteLine("Исходный объект: {0}\n", value);

            // Сериализация объекта
            provider.Save(value);

            Console.WriteLine("Получившийся файл с сериализацией объекта ({0})\n", fileName);
            PrintFile(fileName);

            // Десериализация. Восстановление сохраненного объекта
            Console.WriteLine("\nДесериализация.");
            T dererializedValue = provider.Load();
            Console.WriteLine("Восстановленный объект: {0}\n", dererializedValue);

            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
        }

        private static void SerializationDemo<T>(IProvider<T[]> provider, string fileName, T[] value)
        {
            Console.WriteLine("Исходные объекты:");
            foreach (T item in value) Console.WriteLine(item);

            // Сериализация объекта
            provider.Save(value);

            Console.WriteLine("Получившийся файл с сериализацией объекта ({0})\n", fileName);
            PrintFile(fileName);

            // Десериализация. Восстановление сохраненного объекта
            Console.WriteLine("\nДесериализация.");
            T[] dererializedValue = provider.Load();
            Console.WriteLine("Восстановленные объекты:");
            foreach (T item in dererializedValue) Console.WriteLine(item);

            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
        }

        /// <summary>
        /// Распечатка файла
        /// </summary>
        private static void PrintFile(string fileName)
        {
            Console.WriteLine(File.ReadAllText(fileName));
        }
    }
}
