using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexApplication
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> NextNode { get; set; }
        public Node<T> PrevNode { get; set; }

        public Node(T _data)
        {
            NextNode = null;
            PrevNode = null;
            Data = _data;
        }
        public override string ToString()
        {
            return String.Format("{0}", Data);
        }
    }
}
