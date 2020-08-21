using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9._2
{
    class Watcher
    {

        private static StreamWriter sw = null;
        public static void Run()
        {
            
            string[] args = System.Environment.GetCommandLineArgs();

            //If a directory is not specified, exit program
            if(args.Length != 3)
            {
                //Display the proper way to call the program
                Console.WriteLine("Usage: Watcher.exe (directory)");
                return;
            }

            string path = args[1];
            string log_filename = args[2];

            //Create a new FileSystemWatcher and set its properties
            FileSystemWatcher watcher = new FileSystemWatcher();
            


            using (sw = new StreamWriter(log_filename))
            {
                sw.WriteLine("Date and Time:\tName:\tChangeType:");

                watcher.Path = path;
                /* Watch for changes in LastAccess and LastWrite times, and
                    the renaming of files or directories. */

                watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite | NotifyFilters.FileName;

                //Only watch *.cs files
                watcher.Filter = "*.cs";

                //Add event handlers
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);

                //Begin watching
                watcher.EnableRaisingEvents = true;

                //Wait for the user to quit the program
                Console.WriteLine("Press \'q\' to quit the sample.");

                while (Console.Read() != 'q') ;
            }
        }

        //Define the event handlers
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            //Specify what is done when a file is changed, created, or deleted
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    sw.WriteLine($"{DateTime.Now:dd-MM-yyyy HH:mm:ss.fff}. {e.Name}. {e.ChangeType}.");
                    break;
                case WatcherChangeTypes.Deleted:
                    sw.WriteLine($"{DateTime.Now:dd-MM-yyyy HH:mm:ss.fff}. {e.Name}. {e.ChangeType}.");
                    break;
                case WatcherChangeTypes.Changed:
                    sw.WriteLine($"{DateTime.Now:dd-MM-yyyy HH:mm:ss.fff}. {e.Name}. {e.ChangeType}.");
                    break;
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            //Specify what is done when a file is renamed
            sw.WriteLine($"{DateTime.Now:dd-MM-yyyy HH:mm:ss.fff}. {e.Name}. {e.ChangeType}.");
        }
    }
}
