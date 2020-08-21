using System;
using System.Diagnostics;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration of multidimentional 2d-arrays
            double[,] a, b, res; // Определение прямоугольных массивов         

            try
            {
                int nA_length = int.Parse(args[0]);
                int nB_length = int.Parse(args[1]);

                if(nA_length != nB_length)
                {
                    Console.WriteLine("Размеры матриц должны быть связаны!");
                    return;
                }
                    
                //1. MULTIPLICATION OF MULTIDIMENTIONAL 2D-ARRAYS
                // Создание массивов
                a = new double[nA_length, nB_length];
                b = new double[nA_length, nB_length];
                res = new double[nA_length, nB_length];
                // Заполнение матриц
                Random random = new Random();
                for (int i = 0; i < nA_length; i++)
                    for (int j = 0; j < nB_length; j++)
                    {
                        a[i, j] = random.NextDouble();
                        b[i, j] = random.Next();
                    }
                // Простое засечение времени
                Stopwatch sw = Stopwatch.StartNew(); // Запускает таймер
                                                     // Умножение матриц
                for (int i = 0; i < nA_length; i++)
                    for (int j = 0; j < nB_length; j++)
                    {
                        double cc = 0;
                        for (int k = 0; k < nB_length; k++)
                            cc += a[i, k] * b[k, j];
                        res[i, j] = cc;
                    }
                sw.Stop(); // Останавливает таймер

                double duration = (2 * (sw.ElapsedTicks * sw.ElapsedTicks * sw.ElapsedTicks)) / (sw.Elapsed.TotalSeconds);


                Console.WriteLine("Время умножения " + sw.ElapsedMilliseconds + " мс");
                Console.WriteLine("Время умножения " + duration + " GFLOPS");


                //2. MULTIPLICATION OF JAGGED ARRAYS

                //Declaration of Jagged arrays
                double[][] p, q, pq_res;
                p = new double[nA_length][];
                q = new double[nA_length][];
                pq_res = new double[nA_length][];
                for (uint i = 0; i < nA_length; i++)
                {
                    p[i] = new double[nB_length];
                    q[i] = new double[nB_length];
                    pq_res[i] = new double[nB_length];
                }

                //Initialization of Jagged arrays
                for(uint i = 0; i < nA_length; i++)
                {
                    for(uint j = 0; j < nB_length; j++)
                    {
                        p[i][j] = random.NextDouble();
                        q[i][j] = random.Next();
                    }
                }

                //Multiplication of Jagged arrays
                // Простое засечение времени
                Stopwatch sw1 = Stopwatch.StartNew(); // Запускает таймер
                                                     // Умножение матриц
                for (int i = 0; i < nA_length; i++)
                    for (int j = 0; j < nB_length; j++)
                    {
                        double cc = 0;
                        for (int k = 0; k < nB_length; k++)
                            cc += p[i][k] * q[k][j];
                        pq_res[i][j] = cc;
                    }
                sw1.Stop(); // Останавливает таймер
                double duration1 = (2 * (sw.ElapsedTicks * sw.ElapsedTicks * sw.ElapsedTicks)) / (sw.Elapsed.TotalSeconds);


                Console.WriteLine("Время умножения " + sw1.ElapsedMilliseconds + " мс");
                Console.WriteLine("Время умножения " + duration1 + " GFLOPS");

                Console.ReadLine();
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
