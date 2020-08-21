using System;
using System.Collections;
using System.Collections.Generic;

// Пример того, как может быть реализована ReadOnlyCollection<T>
// Гипотетический пример. Реально все может быть несколько сложнее

namespace ReadOnlyCollectionsDemo
{
    class MyReadOnlyCollection<T> : IList<T>
    {
        public MyReadOnlyCollection(IList<T> collection)
        {
            innerCollection = collection ?? new List<T>();
        }

        private IList<T> innerCollection;

        public int Count
        {
            get { return innerCollection.Count; }
        }

        public int IndexOf(T item)
        {
            return innerCollection.IndexOf(item);
        }

        void IList<T>.Insert(int index, T item)
        {
            throw new NotImplementedException("Коллекция доступна только для чтения");
        }

        void IList<T>.RemoveAt(int index)
        {
            throw new NotImplementedException("Коллекция доступна только для чтения");
        }

        public T this[int index]
        {
            get
            {
                return innerCollection[index];
            }
            set
            {
                throw new NotImplementedException("Коллекция доступна только для чтения");
            }
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException("Коллекция доступна только для чтения");
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException("Коллекция доступна только для чтения");
        }

        public bool Contains(T item)
        {
            return innerCollection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            innerCollection.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException("Коллекция доступна только для чтения");
        }

        #region Implementation of IEnumerable<T>

        public IEnumerator<T> GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
