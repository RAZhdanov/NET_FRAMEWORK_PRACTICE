using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Задание 2.1. Комплексные числа (структуры, перегрузка операций, приведения типов, методы object)
 */
namespace ComplexApplication
{
    class CComplex
    {
        //Конструктор комплексного числа, принимающий только вещественную часть.
        public CComplex(double _Re) : this(_Re, 0)
        {
        }
        //Конструктор комплексного числа, принимающий только вещественную и мнимую части.
        public CComplex(double _Re, double _Im)
        {
            Re = _Re;
            Im = _Im;
        }

        //Также необходимо реализовать функцию создающую комплексное число по модулю и аргументу (например, static метод создания)
        public static CComplex GetComplexValueThroughModulusAndArgument(double modulus, double argument)
        {
            double Re = (Math.Cos(argument) * modulus);
            double Im = (Math.Sin(argument) * modulus);
            return new CComplex(Re, Im);
        }


        public double GetModule(double _Re, double _Im)
        {
            return Math.Sqrt(Math.Pow(_Re, 2) + Math.Pow(_Im, 2));
        }
        public double GetParameter(double _Re, double _Im)
        {
            return Math.Atan(_Im / _Re);
        }

        //Иметь "Свойства" для получения вещественной (Re) и мнимой (Im) части (чтение и установка значения)
        public double Re { get; set; }
        public double Im { get; set; }

        //Иметь Вычислимые "Свойства", возвращающие значение модуля и аргумента
        public double Module { get { return GetModule(Re, Im); } } //http://ru.solverbook.com/spravochnik/kompleksnye-chisla/argument-kompleksnogo-chisla/
        public double Parameter { get { return GetParameter(Re, Im); } } //https://www.calc.ru/argument-kompleksnogo-chisla-kalkulyator.html

        //Переопределить арифметическую операцию +
        public static CComplex operator +(CComplex lval, CComplex rval)
        {
            return new CComplex((lval.Re + rval.Re), (lval.Im + rval.Im));
        }

        //Переопределить арифметическую операцию -
        public static CComplex operator -(CComplex lval, CComplex rval)
        {
            return new CComplex((lval.Re - rval.Re), (lval.Im - rval.Im));
        }

        //Переопределить арифметическую операцию /
        public static CComplex operator /(CComplex lval_a1b1, CComplex rval_a2b2)
        {
            double dRe_numerator = (lval_a1b1.Re * rval_a2b2.Re) + (lval_a1b1.Im * rval_a2b2.Im);
            double dIm_numerator = (rval_a2b2.Re * lval_a1b1.Im) - (lval_a1b1.Re * rval_a2b2.Im);
            double dRe_and_Im_denumerator = (Math.Pow(rval_a2b2.Re, 2) + Math.Pow(rval_a2b2.Im, 2));
            return new CComplex(dRe_numerator / dRe_and_Im_denumerator, dIm_numerator / dRe_and_Im_denumerator); //заглушка
        }

        //Переопределить арифметическую операцию *
        public static CComplex operator *(CComplex lval_a1b1, CComplex rval_a2b2)
        {
            return new CComplex(((lval_a1b1.Re * rval_a2b2.Re) - (lval_a1b1.Im * rval_a2b2.Im)), ((lval_a1b1.Re * rval_a2b2.Im) + (lval_a1b1.Im * rval_a2b2.Re))); //заглушка
        }

        //Переопределить операцию равенства
        public static bool operator ==(CComplex lval, CComplex rval)
        {
            if(lval is null || rval is null)
            {
                return false;
            }

            if (lval.Equals(rval))
                return true;
            else
                return false;
        }

        //Переопределить операцию неравенства
        public static bool operator !=(CComplex lval, CComplex rval)
        {
            if (lval is null || rval is null)
            {
                return false;
            }

            if (lval == rval)
                return false;
            else
                return true;
        }

        //Переопределить операцию Equals
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (GetHashCode() == ((CComplex)obj).GetHashCode())
                //(Math.Abs((double)(Re - ((CComplex)obj).Re)) <= 0.000001) && (Math.Abs((double)(Im - ((CComplex)obj).Im)) <= 0.000001))
                return true;
            else
                return false;
        }

        //Переопределить операцию GetHashCode
        public override int GetHashCode()
        {
            return Re.GetHashCode() + Im.GetHashCode();
        }

        public override string ToString()
        {
            //Класс должен иметь возможность преобразовывать комплексное число в строку обычной записи комплексного числа.
            //Строка, должна быть "красивая"(т.е. 1 - 2i, а не 1 + -2i, или 1, а не 1 + 0i, или 2i, а не 0 + 2i, или 1 + i, а не 1 + 1i).
            //Должна быть возможность распечатки числа, как Console.WriteLine(complex).Преобразование достигается при помощи перегрузки метода ToString().
            String result;

            if (Im == 0)
            {
                result = String.Format("{0}", Re);
            }
            else if(Re == 0)
            {
                result = String.Format("{0}i", Im);
            }
            else
            {
                if(Im == 1 || Im == -1)
                {
                    result = String.Format("{0} {1} {2}", Re, (Im > 0 ? "+" : "-"), "i");
                }
                else
                {
                    result = String.Format("{0} {1} {2}i", Re, Im > 0 ? "+" : "-", Math.Abs(Im));
                }
                
            }

            return result;
        }

        //Обладать возможностью явного преобразования в вещественное число и неявного преобразования из вещественного числа. 
        //Это достигается при помощи перегрузки преобразований типов.

        //Явное преобразование в вещественное число
        public static explicit operator double (CComplex _value)
        {
            return _value.Re;
        }
        public static explicit operator float(CComplex _value)
        {
            return (float)_value.Re;
        }

        //Обладать возможностью неявного преобразования из вещественного числа (float, double)
        public static implicit operator CComplex(float _value)
        {
            return new CComplex(_value);
        }
        public static implicit operator CComplex(double _value)
        {
            return new CComplex(_value);
        }
    }
}
