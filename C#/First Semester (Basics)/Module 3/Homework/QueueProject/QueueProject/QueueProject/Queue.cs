﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueProject
{
    class Queue<T> where T : class
    {
        private Node<T> m_firstNode; //ссылка на начало
        private Node<T> m_lastNode; //ссылка на конец
        private int m_count; //счетчик, отображающий количество элементов в очереди

        public Queue()
        {
            m_firstNode = null;
            m_lastNode = null;
            m_count = 0;
        }

        public void Enqueue(T _element) //enqueue complex value at the end of queue
        {
            if (!ReferenceEquals(_element, null))
            {
                //Прихраниваем текущий узел
                Node<T> currentNode = m_lastNode;

                Node<T> temporaryNode = new Node<T>(_element);

                if (m_count == 0)
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
            if(!ReferenceEquals(m_firstNode, null))
            {
                m_firstNode.PrevNode = null;
                m_firstNode = firstNode.NextNode;
            }
            else
            {
                m_firstNode = m_lastNode = null;
                return null;
            }

            m_count--;
            //А самый первый элемент мы вернет, после чего мы про него забудем на веки вечные
            return firstNode.Data;
        }

        public T Peek() //get the value which is located at the beginning of the queue
        {
            if (!ReferenceEquals(m_firstNode, null))
                return m_firstNode.Data;
            else
            {
                Console.WriteLine("There is no elements!");
                return null;
            }
        }

        public int Count() //returns the quantity of objects in the queue.
        {
            return m_count;
        }

        public void Print() //just prints all elements stored in in the queue
        {
            Node<T> currentNode = m_firstNode;
            if(ReferenceEquals(currentNode, null) || m_count == 0)
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
