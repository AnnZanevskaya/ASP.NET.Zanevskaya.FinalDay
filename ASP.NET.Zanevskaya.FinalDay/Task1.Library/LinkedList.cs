using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        private class Node<T>
        {
            public T data;
            public Node<T> prev;
            public Node<T> next;
        }

        private Node<T> head = null;
        private Node<T> tail = null;       
        private T currentDate;
        private Comparison<T> comparer;

        public CustomLinkedList()
        {
            comparer = Comparer<T>.Default.Compare;
        }
        public CustomLinkedList(IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException("comparer is null");

            this.comparer = comparer.Compare;
        }
        public CustomLinkedList(Comparison<T> comparer)
        {
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException("comparer is null");

            this.comparer = comparer;
        }


        public void Add(T data)
        {
            Node<T> temp = new Node<T>();
            currentDate = data;
            temp.next = null;
            temp.data = data;

            if (Check())
            {
                if (!ReferenceEquals(head, null))
                {
                    temp.prev = tail;
                    tail.next = temp;
                    tail = temp;
                }
                else
                {
                    temp.prev = null;
                    head = temp;
                    tail = temp;
                }
                Count++;
            }
            
        }
        private bool Check()
        {
            Node<T> temp = head;
            while (temp != null)
            {
                if (comparer(currentDate, temp.data) != 0)
                {
                    temp = temp.next;
                }
                else return false;
            }
            return true;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return  CustomIterator().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> CustomIterator()
        {
            return CustomIterator(head);
        }
        private IEnumerable<T> CustomIterator(Node<T> current)
        {
            Node<T> temp = head;
            while (temp != null)
            {
                yield return temp.data;
                temp = temp.next;              
            }
        }
    }
}
