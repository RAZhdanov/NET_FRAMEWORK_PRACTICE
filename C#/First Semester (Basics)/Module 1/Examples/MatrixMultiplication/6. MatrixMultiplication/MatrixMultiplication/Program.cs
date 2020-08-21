using System;
using System.Diagnostics;

namespace MatrixMultiplication
{
    class Program
    {
        const int N = 300; // Размер матриц
        static void Main(string[] args)
        {
            double[,] a, b, c; // Определение прямоугольных массивов
            // Создание массивов
            a = new double[N, N];
            b = new double[N, N];
            c = new double[N, N];
            // Заполнение матриц
            Random random = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    a[i, j] = random.NextDouble();
                    b[i, j] = random.Next();
                }
            // Простое засечение времени
            Stopwatch sw = Stopwatch.StartNew(); // Запускает таймер
            // Умножение матриц
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    double cc = 0;
                    for (int k = 0; k < N; k++)
                        cc += a[i, k] * b[k, j];
                    c[i, j] = cc;
                }
            sw.Stop(); // Останавливает таймер
            long duration = sw.ElapsedMilliseconds; // Количество миллисекунд
            Console.WriteLine("Время умножения " + duration + " мс");
            Console.ReadLine();
        }
    }
}
