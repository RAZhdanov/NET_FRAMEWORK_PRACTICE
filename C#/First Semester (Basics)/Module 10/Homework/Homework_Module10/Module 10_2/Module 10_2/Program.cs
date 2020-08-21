using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
namespace Module_10_2
{

    /*
     * Задание 10.2.* (необязательное). Работа с делегатами через Reflection. Анализ загруженных сборок (Reflection, dynamic) 
        1. Распечатайте список загруженных сборок при работе вашего приложения 

        2. Напишите и вызовите метод, который динамически через Reflection вызывает 
        из отдельной сборки из задания 7 метод для поиска обратного значения функции sin(x)=0.5 
        с точностью 0,0001. 

        Распечатайте результат. 

        Средствами работы с файловой системой предусмотрите возможность отсутствия такой сборки 
        в каталоге приложения (без необходимости использования try … catch блока).
        При этом программа должна продолжать работать, просто пропустив этот шаг (и шаг 3) 
        и выдав пользователю вразумительное сообщение. 
        
        3. Напишите отдельный не статический метод, делающий такой же вызов, что и в п.2 
        только используя dynamic (метод поиска обратного числа должен быть не статическим). 
        
        Распечатайте результат. 
        
        4. Еще раз распечатайте список загруженных сборок при работе вашей программы. 
        
        Обратите внимание на состав загруженных сборок (на появление новых сборок из-за использования dynamic).
        
        Обратите внимание, ваше приложение не должно содержать ссылок на сборку с методом поиска 
        
        обратного значения. 
        Примечания:  
        
        1. Для получения загруженных в данный момент сборок используйте метод GetAssemblies() у текущего домена
        
        приложения: 
        
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies(); 
        
        2. Для динамического создания делегата произвольного типа используйте статический метод CreateDelegate() класса Delegate
        
        Delegate del = Delegate.CreateDelegate(type, method);
        
        3. Для динамического вызова делегата используйте метод DynamicInvoke() у произвольного делегата
        
        object result = del.DynamicInvoke(2, 4, 3);
        
        4. Для проверки существует ли файл на диске используйте статический метод Exists() класса System.IO.File
        
        bool isFileExists = File.Exists("Имя файла"); 
     */
    class Program
    {
        private delegate double SinDel(double a);
        static void Main(string[] args)
        {
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "DelegateProject.dll")))
            {
                //Загрузка сборки
                Assembly assembly = Assembly.Load("DelegateProject");
                //1. Распечатайте список загруженных сборок при работе вашего приложения 
                var array_of_assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly local_assembly in array_of_assemblies)
                {
                    Console.WriteLine(local_assembly.GetName());
                }

                Func<double, double> func = Math.Sin;
                /*
                *  2. Напишите и вызовите метод, который динамически через Reflection вызывает 
                   из отдельной сборки из задания 7 метод для поиска обратного значения функции sin(x)=0.5 
                   с точностью 0,0001. 
                */
                //Распечатайте результат. 
                Console.WriteLine("Y = " + Method1(assembly, func));

                /*
                    3.Напишите отдельный не статический метод, делающий такой же вызов, что и в п.2
                    только используя dynamic (метод поиска обратного числа должен быть не статическим).
                */
                //Распечатайте результат. 
                Program pr = new Program();
                Console.WriteLine("Y = " + pr.Method2(assembly, func));

                /*
                 * 4. Еще раз распечатайте список загруженных сборок при работе вашей программы. 
        
                        Обратите внимание на состав загруженных сборок (на появление новых сборок из-за использования dynamic).
        
                        Обратите внимание, ваше приложение не должно содержать ссылок на сборку с методом поиска 
        
                        обратного значения. 
                 */
                var array_of_assemblies1 = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly local_assembly in array_of_assemblies1)
                {
                    Console.WriteLine(local_assembly.GetName());
                }
            }
            else
            {
                /*
                Средствами работы с файловой системой предусмотрите возможность отсутствия такой сборки
                в каталоге приложения(без необходимости использования try … catch блока).
                При этом программа должна продолжать работать, просто пропустив этот шаг(и шаг 3)
                и выдав пользователю вразумительное сообщение.
                */
                Console.WriteLine("DelegateProject.dll does not exist!");
            }
        }
        //Reflection
        private static object Method1(Assembly assembly, Func<double, double> func)
        {
            if (assembly != null)
            {
                ////////////////////////
                //Создаем класс Program
                Type Program_type = assembly.GetType("DelegateProject.Program");
                object Program_type_instance = Activator.CreateInstance(Program_type);

                //Создаем метод CurrentPrecisionShowed
                MethodInfo CurrentPrecisionShowed_method = Program_type.GetMethod("CurrentPrecisionShowed");

                ////////////////////////
                //Создаем класс Inverter
                Type Inverter_class_type = assembly.GetType("DelegateProject.Inverter");
                object Inverter_class_type_instance = Activator.CreateInstance(Inverter_class_type);

                //Создаем метод Method, располагающийся в классе Inverter
                MethodInfo method = Inverter_class_type.GetMethod("Method");
                //Создаем событие Y_Precision_Event, располагающийся в классе Inverter
                EventInfo ev_precision = Inverter_class_type.GetEvent("Y_Precision_Event");
                Delegate d = Delegate.CreateDelegate(ev_precision.EventHandlerType, CurrentPrecisionShowed_method);

                ev_precision.AddEventHandler(Inverter_class_type_instance, d);

                return method.Invoke(Inverter_class_type_instance, new object[] { 0.5, 0.1, 1.3, func, 0.0001 });
            }
            return null;
        }

        //DLR
        private dynamic Method2(Assembly assembly, Func<double, double> func)
        {
            ////////////////////////
            //Создаем класс Program
            Type Program_type = assembly.GetType("DelegateProject.Program");
            dynamic Program_type_instance = Activator.CreateInstance(Program_type);

            //Создаем метод CurrentPrecisionShowed
            dynamic CurrentPrecisionShowed_method = Program_type_instance.GetType().GetMethod("CurrentPrecisionShowed");

            ////////////////////////
            //Создаем класс Inverter
            Type Inverter_class_type = assembly.GetType("DelegateProject.Inverter");
            dynamic Inverter_class_type_instance = Activator.CreateInstance(Inverter_class_type);

            //Создаем метод Method, располагающийся в классе Inverter
            dynamic method = Inverter_class_type_instance.GetType().GetMethod("Method");

            //Создаем событие Y_Precision_Event, располагающийся в классе Inverter
            dynamic ev_precision = Inverter_class_type_instance.GetType().GetEvent("Y_Precision_Event");
            Delegate d = Delegate.CreateDelegate(ev_precision.EventHandlerType, CurrentPrecisionShowed_method);

            //CurrentPrecisionShowed подписывается на это событие
            ev_precision.AddEventHandler(Inverter_class_type_instance, d);

            return method.Invoke(Inverter_class_type_instance, new dynamic[] { 0.5, 0.1, 1.3, func, 0.0001 });
        }
    }
}
