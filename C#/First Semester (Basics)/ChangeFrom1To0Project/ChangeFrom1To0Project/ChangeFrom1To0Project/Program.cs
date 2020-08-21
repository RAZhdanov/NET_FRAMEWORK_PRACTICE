using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeFrom1To0Project
{
    //Домашнее задание: Не трогая метод Main получить на выходе 0
    //Решение задачи:
    //1) Компилируем данный проект

    //2) Открываем Developer Command Prompt и прописываем ту директорию, где располагается получившийся exe-файл;

    //3) Прописываем команду "ildasm ChangeFrom1To0Project.exe /output:ChangeFrom1To0Project.il" (получим дизассемблированный il-файл)

    //4) Открываем получившийся файл при помощи блокнота, ищем секцию CLASS MEMBERS DECLARATION, ищем строчку IL_0001:  ldstr "1", где производим замену c "1" на "0"

    //5) Создадим в текущей папке другую подпапку (например, Crack).

    //6) Далее производим обратную операцию ассемблирования, где выходной файл поместим в подпапку Crack, прописывая команду: ilasm ChangeFrom1To0Project.il /output:Crack\ChangeFrom1To0Project.exe

    //7) На выходе получим exe-файл, где распечатываться уже будет не 1, а 0.

    //8) Скопируем получившийся файл на уровень выше, где находятся старый скомпилированный файл от нашего основного проекта, и произведем замену exe'шников.

    //9) Теперь при запуске приложения из проекта на консоле будет распечатываться 0

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1");
            Console.ReadKey();
        }
    }
}
