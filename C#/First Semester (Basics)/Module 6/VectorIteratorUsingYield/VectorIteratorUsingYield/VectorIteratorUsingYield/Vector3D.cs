using System.Collections;
using System.Collections.Generic;

namespace VectorIteratorUsingYield
{
    class Vector3D : IEnumerable<double> // Интерфейс IEnumerable<T> наследник от IEnumerable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region Реализация IEnumerable<double>

        public IEnumerator<double> GetEnumerator()
        {
            yield return X;
            yield return Y;
            yield return Z;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
