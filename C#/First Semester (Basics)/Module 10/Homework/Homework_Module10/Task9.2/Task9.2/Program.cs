using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task9._2
{
    /*Задача 9.2. Наблюдение за файловой системой (События, файлы, каталоги)
     * Написать систему слежения за папкой, в которой содержатся файлы с кодом (*.cs).
     * Система должна запускаться из консоли, в качестве параметра ей передается путь папки и имя логфайла.
     * Система должна реагировать на создание новых файлов с кодом,
     * а также на изменение и удаление уже существующих,
     * и должна заносить в лог-файл и выводить на консоль информацию об изменениях. 
     * Например: 
     *   Date,        Time: Name:         Change Type:
     *   26 Sep 2007, 13:11 HelloWorld.cs CREATED 
     *   26 Sep 2007, 13:13 HelloWorld.cs CHANGED 
     *   26 Sep 2007, 13:15 HelloWorld.cs DELETED 
     *   
     *   Примечание: для слежения за работой файловой системы можно использовать класс FileSystemWatcher из System.IO.
     *   Для реакции на события в файловой системе можно использовать обработчики событий и механизм обработки событий .NET. 
     */

    class Program
    {
        static void Main(string[] args)
        {
            Watcher.Run();
        }
    }
}
