using System;

namespace Serialization
{
    // Специфическая реализация класса комплексных чисел. 
    // Сделана для демонстрации. 
    // Такая реализация может быть полезна, если в коде очень часто происходит обращение к Abs, Re, Im на чтение, но редко происходит изменение вещественного числа.
    // В этом случае такая реализация даст более высокую производительность, но за счет расхода памяти на хранение _abs и расходов на синхронизацию _abs

    [Serializable]
    public class Complex
    {
        private double _re;
        private double _im;
        [NonSerialized]
        private double _abs;

        public Complex(double re = 0, double im = 0)
        {
            _re = re;
            _im = im;
            SyncAbs();
        }

        public double Re
        {
            get { return _re; }
            set
            {
                _re = value;
                SyncAbs();
            }
        }
        public double Im
        {
            get { return _im; }
            set
            {
                _im = value;
                SyncAbs();
            }
        }

        public double Abs
        {
            get { return _abs; }
        }

        private void SyncAbs()
        {
            _abs = Math.Sqrt(Re * Re + Im * Im);
        }

        public override string ToString()
        {
            return $"{Re} + {Im}i"; // Синтаксис C# 6
        }
    }
}
