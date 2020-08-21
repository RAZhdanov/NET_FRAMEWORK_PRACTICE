using System;
using System.Collections;
using System.Collections.Generic;

namespace VectorIterator
{
    // Класс Энумератор, созданный для Vector3D
    class VectorEnumerator : IEnumerator<double>
    {
        private readonly Vector3D _vector;
        private int _index; // Индекс нужен, чтобы запоминать текущую позицию

        public VectorEnumerator(Vector3D vector)
        {
            this._vector = vector;
        }

        public double Current
        {
            get
            {
                switch (_index)
                {
                    case 1: return _vector.X;
                    case 2: return _vector.Y;
                    case 3: return _vector.Z;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (_index > 2) return false; // дошли до конца коллекции, возвращаем false (не можем продвинуться дальше)
            _index++;
            return true;
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Dispose()
        {
        }
    }
}