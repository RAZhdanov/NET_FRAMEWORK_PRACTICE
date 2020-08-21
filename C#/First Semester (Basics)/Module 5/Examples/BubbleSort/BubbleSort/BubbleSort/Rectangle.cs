using System;

namespace BubbleSort
{
    // Произвольный класс - Прямоугольник, с реализованным интерфейсом IComparable<T>
    class Rectangle : IComparable<Rectangle>
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double Height { get; } // Readonly Property. Может быть установлено только в конструкторе С# 6
        public double Width { get; } // Readonly Property. Может быть установлено только в конструкторе С# 6

        private double Square { get { return Height * Width; } }

        public override string ToString()
        {
            return $"Прямоугольник {Height}x{Width}. Площадь {Square}"; // С# 6
        }

        // Реализуем сравнение двух прямоугольников как сравнение их площадей
        public int CompareTo(Rectangle other)
        {
            return Square.CompareTo(other.Square);
        }
    }
}
