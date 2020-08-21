using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackProject
{
    class Stack<T> where T: class, ICloneable
    {
        private Node<T> m_TopNode;
        private int m_Count;
        
        public Stack()
        {
            m_Count = 0;
            m_TopNode = null;
        }

        public void Push(T _element) //добавляет значение в стек
        {
            if (!ReferenceEquals(_element, null))
            {
                //Прихраниваем текущий узел
                Node<T> currentNode = m_TopNode;

                Node<T> temporaryNode = new Node<T>(_element);

                if (m_Count == 0) //если стек пустой
                {
                    m_TopNode = temporaryNode;
                }
                else
                {
                    //Определяем следующий узел и устанавливаем метку last на новоустановленный узел
                    m_TopNode.PrevNode = temporaryNode;
                    m_TopNode = temporaryNode;

                    //Определяем нижележащий узел
                    m_TopNode.NextNode = currentNode;
                }
            }
                
            m_Count++;
        }

        public T Pop() //Возвращает значение из вершины стека и удаляет его из стека
        {
            Node<T> TopCurrent = m_TopNode; //Прихраниваем самый последний узел

            if (!ReferenceEquals(TopCurrent, null))
            {
                m_TopNode.PrevNode = null;
                m_TopNode = m_TopNode.NextNode;
                
            }
            else
            {
                m_TopNode = null;
                return null;
            }

            m_Count--;

            return TopCurrent.Data;
        }

        public T Top() //Возвращает значение из вершины стека, не удаляя его из стека
        {
            if (!ReferenceEquals(m_TopNode, null))
            {
                T clone = (T)m_TopNode.Data.Clone();
                return clone;
            }
            else
                return null;
        }

        public int Count() //возвращает количество значений в стеке
        {
            return m_Count;
        }

        public void Print() //just prints all elements stored in in the queue
        {
            Node<T> currentNode = m_TopNode;
            if (ReferenceEquals(currentNode, null) || m_Count == 0)
            {
                Console.WriteLine("There is no elements!");
                return;
            }

            while (!ReferenceEquals(currentNode, null))
            {
                Console.WriteLine(currentNode);
                currentNode = currentNode.NextNode;
            }
        }
    }
}
