using System;
// Пример класса. 
// Класс утрирован с целью демонстрации. Такой Вектор никто использовать не будет

namespace Vectors
{
    /// <summary>
    /// Класс представляет трехмерный вектор в декартовом пространстве
    /// </summary>
    public class Vector3D
    {
        // #region ....  #endregion - задает удобную при просмотре группировку кода (+/- можно свернуть участок кода).
        #region Приватные поля

        /// <summary>
        /// Координаты вектора X, Y, Z
        /// </summary>
        private double _fx, _fy, _fz;

        #endregion

        #region Конструкторы

        // Статический конструктор. Вызывается до создания первого экземпляра объекта
        static Vector3D() // Всегда без модификатора доступа
        {
            Console.WriteLine("Выполняется статический конструктор Vector3D");
        }

        /// <summary>
        /// Конструктор. Задает координаты вектора при создании
        /// </summary>
        /// <param name="fx">Координата X</param>
        /// <param name="fy">Координата Y</param>
        /// <param name="fz">Координата Z. По умолчанию - 0.</param>
        public Vector3D(double fx, double fy, double fz = 0)
        {
            _fx = fx;
            _fy = fy;
            _fz = fz;
        }

        /// <summary>
        /// Конструктор. Задает вектор с одинаковыми координатами по всем осям
        /// </summary>
        /// <param name="f">значение по координатам</param>
        public Vector3D(double f) : this(f, f, f) { } // Вызов другого конструктора. Этого достаточно, поэтому сам конструктор не содержит тела

        #endregion

        #region Свойства

        /// <summary>
        /// Координата X
        /// </summary>
        public double X
        {
            get { return _fx; }
            set
            {
                _fx = value;
                Console.WriteLine("X set");
            }
        }

        /// <summary>
        /// Координата Y. Можно только установить и нельзя читать (для примера)
        /// </summary>
        public double Y
        {
            set
            {
                _fy = value;
                Console.WriteLine("Y set");
            }
        }

        /// <summary>
        /// Координата Z. Свойство только для чтения. Можно только читать и нельзя установить.
        /// </summary>
        public double Z
        {
            get { return _fz; }
        }

        /// <summary>
        /// Длина вектора. Вычислимое свойство
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(_fx * _fx + _fy * _fy + _fz * _fz); // Math - пространство имен с математическими функциями. Sqrt - кв.корень
            }
        }

        /// <summary>
        /// Единичный вектор
        /// Статическое свойство только для чтения
        /// </summary>
        public static Vector3D EVector { get; } = new Vector3D(1, 0, 0);

        #endregion

        #region Переопределение индексатора

        /// <summary>
        /// Переопределение индексатора (доступного только на чтение)
        /// </summary>
        /// <param name="i">номер координаты</param>
        /// <returns>значение координаты</returns>
        public double this[int i]
        {
            get  // Вызывается при чтении значения. Например, double f = vectorPeremen[1];
            {
                switch (i)
                {
                    case 1: return _fx;
                    case 2: return _fy;
                    case 3: return _fz;
                    default:
                        Console.WriteLine("Invalid Index");
                        return double.NaN;
                }
            }
        }
        /// <summary>
        /// Переопределение индексатора (доступного только на установку, и не доступного на чтение)
        /// </summary>
        /// <param name="koord">Символ координаты в виде символа</param>
        /// <returns>значение координаты</returns>
        public double this[char koord]
        {
            set // Вызывается при установке значения. Например, vectorPeremen['X'] = f;
            {
                switch (koord)
                {
                    case 'X': // Обратите внимание ' - одинарная кавычка - символ
                        {
                            _fx = value; // value - ключевое слово, обозначающее переданное значение
                            break;
                        }
                    case 'Y':
                        {
                            _fy = value;
                            break;
                        }
                    case 'Z':
                        {
                            _fz = value;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Index");
                            break;
                        }
                }
            }
        }
        /// <summary>
        /// Переопределение индексатора (доступного и на чтение и на установку)
        /// </summary>
        /// <param name="koord">Символ координаты в виде строки</param>
        /// <returns>значение координаты</returns>
        public double this[string koord]
        {
            get // Вызывается при чтении значения. Например double f = vectorPeremen["X"];
            {
                switch (koord)
                {
                    case "X": return _fx; // Обратите внимание " - двойная кавычка - строка
                    case "Y": return _fy;
                    case "Z": return _fz;
                    default:
                        Console.WriteLine("Invalid Index");
                        return double.NaN;
                }
            }
            set // Вызывается при установке значения. Например, vectorPeremen["X"] = f;
            {
                switch (koord)
                {
                    case "X":
                        {
                            _fx = value;
                            break;
                        }
                    case "Y":
                        {
                            _fy = value;
                            break;
                        }
                    case "Z":
                        {
                            _fz = value;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Index");
                            break;
                        }
                }
            }
        }

        #endregion

        #region Переопределение операций

        /// <summary>
        /// Покоординатное сложение 2-ух векторов
        /// </summary>
        /// <param name="a">Первый вектор</param>
        /// <param name="b">Второй вектор</param>
        /// <returns>Сумма векторов</returns>
        public static Vector3D operator +(Vector3D a, Vector3D b) // переопределяет также +=
        {
            if (a is null || b is null) return null; // C# 7
            return new Vector3D(a._fx + b._fx, a._fy + b._fy, a._fz + b._fz);
        }

        /// <summary>
        /// Покоординатное вычитание 2-ух векторов
        /// </summary>
        /// <param name="a">Первый вектор</param>
        /// <param name="b">Второй вектор</param>
        /// <returns>Разность векторов</returns>
        public static Vector3D operator -(Vector3D a, Vector3D b) // переопределяет также -=
        {
            if (a is null || b is null) return null; // C# 7
            return new Vector3D(a._fx - b._fx, a._fy - b._fy, a._fz - b._fz);
        }

        /// <summary>
        /// Переопределение УНАРНОГО -
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D a)
        {
            if (a is null) return null; // C# 7
            return new Vector3D(-a._fx, -a._fy, -a._fz);
        }

        #endregion

        #region Переопределение операций сравнения

        public static bool operator ==(Vector3D a, Vector3D b)
        {
            if (ReferenceEquals(a, null)) // не == null, а именно object.ReferenceEquals(a, null)
            {
                return ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }

        public static bool operator !=(Vector3D a, Vector3D b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return _fx.GetHashCode() ^ _fy.GetHashCode() ^ _fx.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3D vector) // если obj - null, то тоже вернет false // C# 7
            {
                return _fx == vector._fx && _fy == vector._fy && _fz == vector._fz;
            }

            return false;

        }

        #endregion

        #region Операторы приведения типов

        /// <summary>
        /// Задание ЯВНОГО преобразования типа Vector3D в число double
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>Решили, что пусть такое преобразование возвращает длину вектора</returns>
        public static explicit operator double(Vector3D v)
        {
            if (v is null) return double.NaN; // C# 7
            return v.Length;
        }

        /// <summary>
        /// Задание НЕЯВНОГО преобразования числа типа int в Vector3D
        /// </summary>
        /// <param name="x">Вектор</param>
        /// <returns>Возвращает вектор данной длинны вдоль координаты X</returns>
        public static implicit operator Vector3D(int x)
        {
            return new Vector3D(x, 0, 0);
        }

        #endregion

        #region Просто методы

        /// <summary>
        /// Суммирует несколько векторов. Статический метод.
        /// </summary>
        /// <param name="vectors">Векторы</param>
        /// <returns>Сумма векторов</returns>
        public static Vector3D Sum(params Vector3D[] vectors) // Переменное число параметров
        {
            Vector3D result = new Vector3D(0);
            foreach (Vector3D v in vectors)
                result += v; // Операция переопределена. Суммирование векторов!
            return result;
        }

        /// <summary>
        /// Создает вектор по сферическим координатам, если параметры заданы верно
        /// https://ru.wikipedia.org/wiki/%D0%A1%D1%84%D0%B5%D1%80%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B0%D1%8F_%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0_%D0%BA%D0%BE%D0%BE%D1%80%D0%B4%D0%B8%D0%BD%D0%B0%D1%82
        /// </summary>
        /// <param name="r">Длинна вектора</param>
        /// <param name="phi"> Угол между осью X и проекцией вектора на плоскость XY </param>
        /// <param name="th"> Угол между осью Z и вектором</param>
        /// <returns>Вектор</returns>
        public static Vector3D CreateBySphericalCoordinates(double r, double phi, double th)
        {
            if (r < 0) return null;
            if (phi < 0 || phi > Math.PI * 2) return null;
            if (th < 0 || th > Math.PI) return null;

            return new Vector3D(r * Math.Cos(phi) * Math.Sin(th),
                                r * Math.Sin(phi) * Math.Sin(th),
                                r * Math.Cos(th));
        }


        /// <summary>
        /// Переопределение метода базового типа System.Object
        /// </summary>
        /// <returns>Строковое представление вектора</returns>
        public override string ToString()
        {
            return string.Format("( {0}; {1}; {2} )", _fx, _fy, _fz);
        }

        #endregion
    }
}
