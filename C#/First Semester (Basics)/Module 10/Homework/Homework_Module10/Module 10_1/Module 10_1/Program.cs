using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
//Комплексные вычисления (Reflection, dynamic)
//1. Если в каталоге программы присутствует сборка из домашнего задания 2.1
//(комплексные числа), то, используя Reflection и эту сборку, необходимо:
// - не используя dynamic, вычислить значение выражения:
//      z = ((x + y)^2) / 27; 
//            x = 2 + 3i; 
//            y = 14(cos(п/4)+isin(п/4))
//т.е. одно комплексное число задано в обычном виде, а второе в тригонометрическом

// - Распечатать результат в обычном виде и в виде модуля аргумента (тригонометрическом виде)

// - Используя dynamic, вычислить
//      c = ( (a^2  +  b^2)^2 ) / 3b, где a = 4 + i; b = 2(cos(п/3)+isin(п/3))
//т.е. одно комплексное число задано в обычном виде, а второе в тригонометрическом

// Распечатать результат в обычном виде и в виде модуля и аргумента (тригонометрическом виде)

//2. Если в каталоге программы отсутствует сборка из домашнего задания 2.1, то:
// - Необходимо сообщить об этом пользователю
// - Используя стандартную .NET структуру System.Numerics.Complex, без Reflection, вычислить:
//      d = 34 + e^f, где e = 1 + 2i; f = 3(cos(п/8)+isin(п/8)), при этом Complex уже обладает
//всеми необходимыми методами для работы с комплексными числами, например, FromPolarCoordinates(), Pow() и т.д.
// - Вывести результат пользователю
// Для созданий комплексных чисел в тригонометрическом виде используйте статический метод,
// создающий комплексное число по модулю и аргументу (был в домашнем задании)

//Обратите внимание, ваше приложение не должно содержать ссылок на сборку из домашнего задания 2.1.


namespace Module_10_1
{
    class Program
    {
        public static Complex GetComplexValueThroughModulusAndArgument(Complex val)
        {
            double Re = (Math.Cos(val.Imaginary) * val.Real);
            double Im = (Math.Sin(val.Imaginary) * val.Real);
            return new Complex(Re, Im);
        }
        static void Main(string[] args)
        {
            /*
             * Если в каталоге программы присутствует сборка из домашнего задания 2.1
             * (комплексные числа), то, используя Reflection и эту сборку, необходимо:
             * - не используя dynamic, вычислить значение выражения:
                  z = ((x + y)^2) / 27; 
                        x = 2 + 3i; 
                        y = 14(cos(п/4)+isin(п/4))
                т.е. одно комплексное число задано в обычном виде, а второе в тригонометрическом
             */

            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "ComplexApplication.dll")))
            {
                //Загрузка сборки
                Assembly assembly = Assembly.Load("ComplexApplication");

                //Получаем тип ComplexApplication.CComplex
                Type type = assembly.GetType("ComplexApplication.CComplex");

                //Динамическое создание объектов
                object x = null;
                object y = null;
                //Вызов известного статического метода (Здесь умножение)
                MethodInfo miMultiplication = type.GetMethod("op_Multiply");

                {
                    //x = 2 + 3i; 
                    x = Activator.CreateInstance(type, 2, 3);

                    //y = (cos(п/4)+isin(п/4))
                    y = miMultiplication.Invoke(null, new object[] { Activator.CreateInstance(type, 14), Activator.CreateInstance(type, Math.Cos(Math.PI / 4), Math.Sin(Math.PI / 4)) }); // операция умножения - статический метод, поэтому первый параметр null
                }

                //(x + y) - Вызов известного статического метода (Здесь сложение) 
                MethodInfo miAddition = type.GetMethod("op_Addition");
                object x_add_y = miAddition.Invoke(null, new object[] { x, y });

                //((x + y)^2)
                object sub_z = miMultiplication.Invoke(null, new object[] { (x_add_y), (x_add_y) });

                //((x + y)^2) / 27 - Вызов известного статического метода (Здесь деление)
                MethodInfo miDivision = type.GetMethod("op_Division");
                object z = miDivision.Invoke(null, new object[] { sub_z, Activator.CreateInstance(type, 27) });


                //////////////////////////////////////////////////////////
                // - Распечатать результат в обычном виде и в виде модуля аргумента (тригонометрическом виде)
                //в обычном виде
                MethodInfo mi = type.GetMethod("ToString");
                Console.WriteLine(mi.Invoke(z, null));

                //В тригонометрическом виде
                PropertyInfo modulus_pr = type.GetProperty("Module");
                PropertyInfo argument_pr = type.GetProperty("Parameter");

                MethodInfo minfo_modulus_and_argument = type.GetMethod("GetComplexValueThroughModulusAndArgument", new[] { type });

                Console.WriteLine($"{modulus_pr.GetValue(z)}*(cos({argument_pr.GetValue(z)}) + isin({argument_pr.GetValue(z)})) или просто " +
                    $"{minfo_modulus_and_argument.Invoke(null, new object[] { z })}");



                // - Используя dynamic, вычислить
                //      c = ( (a^2  +  b^2)^2 ) / 3b, где a = 4 + i; b = 2(cos(п/3)+isin(п/3))
                //т.е. одно комплексное число задано в обычном виде, а второе в тригонометрическом

                //Позволяет отключить проверку типов в процессе компиляции
                //DLR (Dynamic Runtime Language)
                dynamic a = Activator.CreateInstance(type, 4, 1);
                dynamic b = miMultiplication.Invoke(null, new object[]
                {
                    Activator.CreateInstance(type, 2),
                    Activator.CreateInstance(type, Math.Cos(Math.PI/3), Math.Sin(Math.PI/3))
                });

                dynamic c = (((a * a) + (b * b)) * ((a * a) + (b * b))) / (3 * b);

                // Распечатать результат в обычном виде и в виде модуля и аргумента (тригонометрическом виде)
                Console.WriteLine(c); //В обычном виде

                dynamic module = c.Module;
                dynamic argument = c.Parameter;

                Console.WriteLine($"{module}*(cos({argument}) + isin({argument})) или просто { minfo_modulus_and_argument.Invoke(null, new object[] { c })}"); //В тригонометрическом виде
            }
            //Если в каталоге программы отсутствует сборка из домашнего задания 2.1, то:
            else
            {
                //Необходимо сообщить об этом пользователю
                Console.WriteLine("В каталоге программы отсутствует сборка из домашнего задания 2.1");

                //Используя стандартную .NET структуру System.Numerics.Complex, без Reflection, вычислить:

                //d = 34 + e ^ f, где e = 1 + 2i; f = 3(cos(п / 8) + isin(п / 8)), при этом Complex уже обладает
                //всеми необходимыми методами для работы с комплексными числами, например, FromPolarCoordinates(), Pow() и т.д.
                System.Numerics.Complex e = new Complex(1, 2);

                System.Numerics.Complex f = new Complex((3 * Math.Cos(Math.PI/8)), (3 * Math.Sin(Math.PI/8)));
                System.Numerics.Complex d = 34 + System.Numerics.Complex.Pow(e, f);

                //Вывести результат пользователю
                Console.WriteLine(d);

            }
        }
    }
}
