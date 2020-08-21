using System;

namespace ParameterPassing
{
    #region Класс и Структура (ссылочный тип и тип значение), представляющие комплексное число
    class ComplexClass
    {
        public double Re { get; set; }
        public double Im { get; set; }
        public override string ToString()
        {
            return $"{Re} + {Im}i";
        }
    }
    struct ComplexStruct
    {
        public double Re { get; set; }
        public double Im { get; set; }
        public override string ToString()
        {
            return $"{Re} + {Im}i";
        }
    }
    #endregion

    public class Program
    {
        static void Main()
        {
            // Демонстрация передачи параметров по значению (по умолчанию)
            ShowParameterPassingByValue();
            // Демонстрация передачи параметров по ссылке
            ShowParameterPassingByReference();

            Console.ReadKey();
        }

        #region Демонстрация передачи параметра по значению

        static void ShowParameterPassingByValue()
        {
            Console.WriteLine("Передача параметров по значению (по умолчанию)");
            Console.WriteLine("Class");
            ComplexClass complexClass = new ComplexClass { Re = 1, Im = 1 };
            Console.Write("До передачи в метод {0}, ", complexClass);
            ParameterTest(complexClass);
            Console.WriteLine("после изменения значения {0}", complexClass);

            complexClass = new ComplexClass { Re = 1, Im = 1 };
            Console.Write("До передачи в метод {0}, ", complexClass);
            ParameterTestNew(complexClass);
            Console.WriteLine("после new в методе {0}", complexClass);

            Console.WriteLine("\nStruct");

            ComplexStruct complexStruct = new ComplexStruct { Re = 1, Im = 1 };
            Console.Write("До передачи в метод {0}, ", complexStruct);
            ParameterTest(complexStruct);
            Console.WriteLine("после изменения значения {0}", complexStruct);

            complexStruct = new ComplexStruct { Re = 1, Im = 1 };
            Console.Write("До передачи в метод {0}, ", complexStruct);
            ParameterTestNew(complexStruct);
            Console.WriteLine("после new в методе {0}", complexStruct);
        }

        static void ParameterTest(ComplexClass complex)
        {
            complex.Re = complex.Im = 2;
        }

        static void ParameterTestNew(ComplexClass complex)
        {
            complex = new ComplexClass { Re = 3, Im = 3 };
        }

        static void ParameterTest(ComplexStruct complex)
        {
            complex.Re = complex.Im = 2;
        }

        static void ParameterTestNew(ComplexStruct complex)
        {
            complex = new ComplexStruct { Re = 3, Im = 3 };
        }

        #endregion

        #region Демонстрация передачи параметра по ссылке

        static void ShowParameterPassingByReference()
        {
            // Обратите внимание при вызове метода также указывается ref, как и в описании метода
            Console.WriteLine("\nПередача параметров по ссылке (ref)");
            Console.WriteLine("Class");
            ComplexClass complexClass = new ComplexClass { Re = 1, Im = 1 };
            Console.Write("До передачи в метод {0}, ", complexClass);
            ParameterTestByReference(ref complexClass);                 // ref !!!!
            Console.WriteLine("после изменения значения {0}", complexClass);

            complexClass = new ComplexClass { Re = 1, Im = 1 };
            Console.Write("До передачи в метод {0}, ", complexClass);
            ParameterTestNewByReference(ref complexClass);              // ref !!!!
            Console.WriteLine("после new в методе {0}", complexClass);

            Console.WriteLine("\nStruct");

            ComplexStruct complexStruct = new ComplexStruct { Re = 1, Im = 1 };
            Console.Write("До передачи в метод {0}, ", complexStruct);
            ParameterTestByReference(ref complexStruct);                // ref !!!!
            Console.WriteLine("после изменения значения {0}", complexStruct);

            complexStruct = new ComplexStruct { Re = 1, Im = 1 };
            Console.Write("До передачи в метод {0}, ", complexStruct);
            ParameterTestNewByReference(ref complexStruct);             // ref !!!!
            Console.WriteLine("после new в методе {0}", complexStruct);
        }

        static void ParameterTestByReference(ref ComplexClass complex)       // ref !!!!
        {
            complex.Re = complex.Im = 2;
        }

        static void ParameterTestNewByReference(ref ComplexClass complex)    // ref !!!!
        {
            complex = new ComplexClass { Re = 3, Im = 3 };
        }

        static void ParameterTestByReference(ref ComplexStruct complex)      // ref !!!!
        {
            complex.Re = complex.Im = 2;
        }

        static void ParameterTestNewByReference(ref ComplexStruct complex)   // ref !!!!
        {
            complex = new ComplexStruct { Re = 3, Im = 3 };
        }

        #endregion
    }
}
