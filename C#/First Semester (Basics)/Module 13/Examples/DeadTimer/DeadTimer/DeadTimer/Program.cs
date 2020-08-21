using System;
using System.Threading;

namespace DeadTimer
{
    class Program
    {
        // Разное поведение в Debug и Release режимах (точнее зависит от настройки Optimize Code в настойках проекта -> Build)
        static void Main(string[] args)
        {

            Timer timer = new Timer(o => Console.WriteLine(DateTime.Now), null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            // timer больше не используется и может быть собран сбощиком мусора
            Console.WriteLine("Таймер запущен");
            Console.ReadLine();

            GC.Collect();
            Console.WriteLine("Мусор собран");
            // В целях отладки в Debug режиме GC не удалит Timer

            Console.ReadLine();
        }
    }
}
