using System;
using System.Collections.Generic;
using System.Reflection;

/*
 Пример динамической работы со сборками.
 * Файл Vectors.dll специально добавлен в проект, и копируется каждый раз в папку с exe программы. Для удобства.
 * На него нигде нет ссылок. Vectors.dll добавлен для удобства демонстрации.
 * Не заблуждайтесь, что в программе есть информация об этом файле.
 * Можете чуть-чуть изменить код и вводить имя Любой .NET сборки, например, заданной в качестве параметра командной строки.
 */

namespace PrintMetaInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Загрузка сборки
            Assembly asm = Assembly.ReflectionOnlyLoad("Vectors"); 
            // Поскольку в программе используются только метаданные и не создаются типы, и не вызывается код, 
            // то можно использовать легкий метод ReflectionOnlyLoad() вместо Load(): 
            //Assembly asm = Assembly.Load("Vectors");
            
            Console.WriteLine("Загружена сборка {0}", asm.FullName);
            Console.WriteLine();

            // Распечатываем все типы в сборке
            PrintTypes(asm);

            //Получаем тип Vectors.Vector3D
            Type type = asm.GetType("Vectors.Vector3D");

            // Распечатываем информацию о его конструкторах
            PrintConstructors(type);

            // Распечатываем информацию о его методах
            PrintMethods(type);

            // Распечатываем информацию о его свойствах
            PrintProperties(type);

            // И так далее
            // FieldInfo[] fis = type.GetFields();
            // EventInfo[] eis = type.GetEvents();

            Console.ReadLine();
        }

        /// <summary>
        /// Распечатка типов в сборке
        /// </summary>
        /// <param name="asm">сборка</param>
        private static void PrintTypes(Assembly asm)
        {
            Type[] ts = asm.GetTypes();
            Console.WriteLine("Типы, определенные в сборке:");
            foreach (Type t in ts)
            {
                Console.WriteLine("{0}.{1}", t.Namespace, t.Name); // Это равнозначно t.FullName
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Распечатка конструкторов типа
        /// </summary>
        /// <param name="type">тип</param>
        private static void PrintConstructors(Type type)
        {
            ConstructorInfo[] cis = type.GetConstructors();
            Console.WriteLine("Тип {0} имеет {1} конструктора", type.Name, cis.Length);
            int i = 1;
            foreach (ConstructorInfo ci in cis)
            {
                List<string> parameterTypes = new List<string>();
                // Определение параметров конструктора
                ParameterInfo[] pis = ci.GetParameters();
                if (pis != null && pis.Length > 0)
                {
                    foreach (var pi in pis)
                    {
                        parameterTypes.Add(pi.ParameterType.FullName);
                    }
                    Console.WriteLine("{0}. Имеет {1} параметра: {2}", i++, pis.Length, string.Join(", ", parameterTypes));
                }
                else Console.WriteLine("{0}. Конструктор не имеет параметров", i++);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Распечатка методов типа
        /// </summary>
        /// <param name="type">тип</param>
        private static void PrintMethods(Type type)
        {
            MethodInfo[] mis = type.GetMethods();
            Console.WriteLine("Тип {0} имеет следующие методы:", type.Name);

            foreach (MethodInfo mi in mis)
            {
                List<string> parameterTypes = new List<string>();
                // Определение параметров метода
                ParameterInfo[] pis = mi.GetParameters();
                if (pis != null)
                {
                    foreach (var pi in pis)
                    {
                        parameterTypes.Add(pi.ParameterType.Name);
                    }
                }
                // Модификаторы метода
                string accessModifier = (mi.IsPublic) ? "public" : (mi.IsPrivate) ? "private" : "";
                string isStatic = mi.IsStatic ? "static " : string.Empty;
                string isVirtual = mi.IsVirtual ? "virtual " : string.Empty;
                Console.WriteLine("{0} {1}{2}{3} {4}({5})", accessModifier, isStatic, isVirtual, mi.ReturnType.Name, mi.Name, string.Join(", ", parameterTypes));
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Распечатка свойств типа
        /// </summary>
        /// <param name="type">тип</param>
        private static void PrintProperties(Type type)
        {
            PropertyInfo[] pis = type.GetProperties();
            Console.WriteLine("Тип {0} имеет следующие свойства:", type.Name);

            foreach (PropertyInfo pi in pis)
            {
                Console.WriteLine("{0} {1} {{ {2}{3}}}", pi.PropertyType.Name, pi.Name, pi.CanRead ? "get; " : string.Empty, pi.CanWrite ? "set; " : string.Empty);
            }
            Console.WriteLine();
        }
    }
}
