using System;
using System.IO;
using System.Reflection;

/*
 Пример динамической работы со сборками.
 * Файл Vectors.dll специально добавлен в проект, и копируется каждый раз в папку с exe программы. Для удобства.
 * На него нигде нет ссылок. Vectors.dll добавлен для удобства демонстрации.
 * Не заблуждайтесь, что в программе есть информация об этом файле.
 * Можете чуть-чуть изменить код и вводить имя Любой .NET сборки, например, заданной в качестве параметра командной строки.
 */

namespace DynamicExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Vectors.dll")))
            {
                // Загрузка сборки
                Assembly assembly = Assembly.Load("Vectors");

                //Получаем тип Vectors.Vector3D
                Type type = assembly.GetType("Vectors.Vector3D");

                // Динамическое создание объектов
                object vector1 = Activator.CreateInstance(type, 5, 7, 9); // Не можем привести к типу Vector3D, поскольку ничего об этом типе не знаем
                object vector2 = Activator.CreateInstance(type, 3, 4, 5);

                // Вызов известного статического метода (Здесь сложение)
                MethodInfo miAdd = type.GetMethod("op_Addition");
                object vector3 = miAdd.Invoke(null, new object[] { vector1, vector2 }); // операция сложения - статический метод, поэтому первый параметр null

                // Вызов метода уровня экземпляра (т.е. не статический)
                MethodInfo mi = type.GetMethod("ToString");
                Console.WriteLine(mi.Invoke(vector1, null));
                Console.WriteLine(mi.Invoke(vector2, null));
                Console.WriteLine(mi.Invoke(vector3, null));
                // На самом деле метод ToString() есть у всех объектов, и поэтому также будет верно Console.WriteLine(vector1); Но здесь в качестве примера подойдет и ToString()

                // Для анализа кол-ва загруженных сборок (анализируйте без Visual Studio (без Debug) - Ctrl F5. Это необходимо, поскольку студия загружает ряд дополнительных сборок для отладки).
                Console.WriteLine("Кол-во загруженных сборок: {0}", AppDomain.CurrentDomain.GetAssemblies().Length);
                // Использование динамической типизации (разрешение типа во время выполнения, а не во время компиляции)
                DynamicDemo(type);
                // Из-за dynamic происходит загрузка еще нескольких сборок .NET (анализируйте без Visual Studio (без Debug) - Ctrl F5. Это необходимо, поскольку студия загружает ряд дополнительных сборок для отладки).
                Console.WriteLine("Кол-во загруженных сборок: {0}", AppDomain.CurrentDomain.GetAssemblies().Length);

            }
            else Console.WriteLine("Сборка Vectors.dll не найдена");
            Console.ReadKey();
        }

        private static void DynamicDemo(Type type)
        {
            // Использование динамической типизации (разрешение типа во время выполнения, а не во время компиляции)
            dynamic dynVector1 = Activator.CreateInstance(type, 11, 12, 13);
            dynamic dynVector2 = Activator.CreateInstance(type, 111, 222, 333);
            dynVector1.X = 22; // Динамическое разрешение свойства - X
            dynVector2 = dynVector1 + dynVector2; // Динамическое разрешение операции +
            double length = dynVector1.Length; // Динамическое разрешение свойства - Length. Нет приведения типов
            Console.WriteLine("Длина первого вектора: {0}", length);
            Console.WriteLine("Первый вектор: {0}", dynVector1);
            Console.WriteLine("Второй вектор: {0}", dynVector2);
        }
    }
}
