using System;
using Vectors;  // Указали пространство имен из одноименного модуля Vectors.dll. Перед этим на него установили ссылку (references) в проекте (в Solution Explorer)

namespace VectorsDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Program Started");
            // Создание векторов. Статический конструктор типа Vector3D уже выполнится до этого места
            Vector3D v1 = new Vector3D(5, 7, 9);
            Console.WriteLine("Создали вектор v1 = {0}", v1); // Здесь у v1 вызовется переопределенный метод ToString()

            Console.WriteLine("Пример работы свойств");
            Console.WriteLine("v1.Length = " + v1.Length);
            Console.WriteLine("Задание свойств X = 12, Y = 13");
            v1.X = 12;
            v1.Y = 13;
            // v1.Z = 67; Ошибка. Поле только для чтения
            Console.WriteLine("v1 = {0}", v1);
            Console.WriteLine("Чтение свойств");
            Console.WriteLine("X = {0}, Y = {1}, Z = {2}", v1.X, /* v1.Y */"ошибка", v1.Z); // Нельзя читать свойство Y

            Console.WriteLine("Пример работы индексаторов");
            Console.WriteLine("v1[1] = {0}, v1[2] = {1}, v1[3] = {2}", v1[1], v1[2], v1[3]);
            // Console.WriteLine("v1['X'] = {0}, v1['Y'] = {1}, v1['Z'] = {2}", v1['X'], v1['Y'], v1['Z']); // Ошибка. Нельзя читать (не реализовано get)
            v1['X'] = 43;   // Индекс - символ
            // v1[2] = 37;  // Ошибка. Только для чтения (не реализовано set)
            v1["Z"] = 67;   // Индекс - строка
            Console.WriteLine("Задание v1['X'] = 43,  v1[\"Z\"] = 67");
            Console.WriteLine("v1[\"X\"] = {0}, v1[\"Y\"] = {1}, v1[\"Z\"] = {2}", v1["X"], v1["Y"], v1["Z"]);


            Vector3D v2 = new Vector3D(2, 5); // Реально вызывается Vector3D(2, 5, 0); Третий параметр по умолчанию
            Console.WriteLine("Создали вектор v2 = {0}", v2);

            Vector3D v3 = v1 + v2;
            Console.WriteLine("Сложили векторы v1{0} + v2{1} = {2}", v1, v2, v3);
            Console.WriteLine("Унарный минус -v1 = {0}", -v1);
            Console.WriteLine("Сумма трех векторов v1{0} + v2{1} + v3{2} = {3}", v1, v2, v3, Vector3D.Sum(v1, v2, v3)); // Вызов статического метода

            // Операции сравнения
            Console.WriteLine("Сравнение векторов");
            Console.WriteLine("v1{0} = v2{1} ? {2}", v1, v2, v1 == v2);
            Console.WriteLine("v1{0} = null ? {1}", v1, v1 == null);
            Console.WriteLine("Одинаковые вектора равны (вектора, не объекты) ? {0}", new Vector3D(5, 7, 9) == new Vector3D(5, 7, 9));

            // Преобразование типов
            Vector3D v4 = 7; // Используется реализованное НЕЯВНОЕ приведение типов (impicit)
            Console.WriteLine("Создали вектор v4 = {0}", v4);
            double f = (double)v1; // Используется реализованное ЯВНОЕ приведение типов (explicit)
            Console.WriteLine("Преобразовали вектор v1{0} в число = {1}", v1, f);

            // Создание объекта с помощью вызова статического метода (создание вектора по сферическим координатам)
            Vector3D sv = Vector3D.CreateBySphericalCoordinates(10, Math.PI / 4, Math.PI / 4);
            Console.WriteLine("Вектор, созданный по сферическим координатам: {0}", sv);

            // Статическое свойство только для чтения, реализованное в стиле C# 6
            Vector3D e = Vector3D.EVector;
            Console.WriteLine("Единичный вектор: {0}", e);

            // Пример передачи параметров по именам
            Vector3D v5 = new Vector3D(fx: 5, fz: 7, fy: 6);
            // Комбинированный подход
            Vector3D v6 = new Vector3D(5, fz: 7, fy: 6); // fx - задается по позиции, остальные по имени.
            Vector3D v7;
            // Пример использования параметров out, ref.
            Console.WriteLine("Пример передачи параметров по значению (обычно), по ссылке ref и out");
            Console.WriteLine("До передачи");
            Console.WriteLine("v5 = {0}", v5);
            Console.WriteLine("v6 = {0}", v6);
            ReturnVector(v5, ref v6, out v7);
            Console.WriteLine("После передачи");
            Console.WriteLine("v5 = {0}", v5);
            Console.WriteLine("v6 = {0}", v6);
            Console.WriteLine("v7 = {0}", v7);

            Console.WriteLine("Нажмите Enter для выхода");

            Console.ReadLine();
        }
        private static void ReturnVector(Vector3D A, ref Vector3D B, out Vector3D C)
        {
            A['X'] = 10;
            B['X'] = 10;
            C = new Vector3D(0, fy: 0); // Комбинированный подход передачи параметров: fx - задается по позиции, fy по имени, fz по умолчанию
            C['X'] = 10;
        }
    }
}
