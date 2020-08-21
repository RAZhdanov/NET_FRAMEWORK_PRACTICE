using System;

namespace ListDemo
{
    /// <summary>
    /// Строго типизированный список объектов
    /// </summary>
    /// <typeparam name="T">любой тип</typeparam>
    public class List<T>
    {
        private Node<T> _first, _last; // ссылки на первый и последний элементы списка

        /// <summary>
        /// Добавляет элемент в конец списка
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            Node<T> temp = new Node<T>(data);
            if (_last == null)
            {
                _last = temp;
                _first = temp;
            }
            else
            {
                _last.Next = temp;
                _last = _last.Next;
            }
        }

        /// <summary>
        /// Удаляет элемент из списка (первый найденный)
        /// </summary>
        /// <param name="data">удаляемый элемент</param>
        public void Remove(T data)
        {
            if (_first == null) return;
            if (Equals(data, _first.Data))
            {
                _first = _first.Next;
                if (_first == null) _last = null;
            }
            else
            {
                Node<T> previous = _first;
                Node<T> current = _first.Next;

                while (current != null && !Equals(data, current.Data))
                {
                    previous = current;
                    current = current.Next;
                }

                if (current != null)
                {
                    previous.Next = current.Next;
                    if (_last == current) _last = previous;
                }
            }
        }

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns>Элемент с указанным индексом</returns>
        public T this[int index]
        {
            get
            {
                Node<T> element = FindElementByIndex(index);
                return element == null ? default(T) : element.Data;
            }
            set
            {
                Node<T> element = FindElementByIndex(index);
                if (element != null)
                {
                    element.Data = value;
                }
            }
        }

        /// <summary>
        /// Вычислимое свойство, количество элементов в списке
        /// </summary>
        public int Count
        {
            get
            {
                int result = 0;
                Node<T> node = _first;
                while (node != null)
                {
                    node = node.Next;
                    ++result;
                }

                return result;
            }
        }

        /// <summary>
        /// Распечатывает содержимое списка (вызывает у каждого элемента ToString())
        /// </summary>
        public void Print()
        {
            Node<T> temp = _first;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }

        private Node<T> FindElementByIndex(int index)
        {
            if (index < 0) return null;
            int currentIndex = 0;
            Node<T> current = _first;
            while (current != null && currentIndex < index)
            {
                current = current.Next;
                ++currentIndex;
            }
            return current;
        }

        // Вложенный приватный класс
        private class Node<TElement>
        {
            public Node(TElement data, Node<TElement> next = null)
            {
                Data = data;
                Next = next;
            }
            public TElement Data { get; set; }
            public Node<TElement> Next { get; set; }
        }
    }
}
