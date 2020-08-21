using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexApplication
{

    class Queue<T>
    {
        private Node<T> m_firstNode; //ссылка на начало
        private Node<T> m_lastNode; //ссылка на конец
        private int m_count; //счетчик, отображающий количество элементов в очереди

        public Queue()
        {
            m_count = 0;
        }

        public void Enqueue(T _element) //enqueue complex value at the end of queue
        {
            if(!ReferenceEquals(_element, null))
            {
                //Прихраниваем текущий узел
                Node<T> currentNode = m_lastNode;

                Node<T> temporaryNode = new Node<T>(_element);

                if(m_count == 0)
                {
                    m_firstNode = m_lastNode = temporaryNode;
                }
                else
                {
                    //Определяем следующий узел и устанавливаем метку last на новоустановленный узел
                    m_lastNode.NextNode = temporaryNode;
                    m_lastNode = temporaryNode;

                    //Определяем предыдущий узел
                    currentNode.NextNode.PrevNode = currentNode;

                }
                m_count++;
            }
        }

        public T Dequeue() //get the value from the queue and delete it
        {
            //Прихраниваем первый узел
            Node<T> firstNode = m_firstNode;

            //Переведи указатель first на следующий
            m_firstNode = m_firstNode.NextNode;

            m_count--;
            //А самый первый элемент мы вернет, после чего мы про него забудем на веки вечные
            return firstNode.Data;
        }

        public T Peek() //get the value which is located at the beginning of the queue
        {
            return m_firstNode.Data;
        }

        public int Count() //returns the quantity of objects in the queue.
        {
            return m_count;
        }

        public void Print() //just prints all elements stored in in the queue
        {
            Node<T> currentNode = m_firstNode;
            
            while (!ReferenceEquals(currentNode, null))
            {
                Console.WriteLine(currentNode);
                currentNode = currentNode.NextNode;
            }
        }
    }
}
