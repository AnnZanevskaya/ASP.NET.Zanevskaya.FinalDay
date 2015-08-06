using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Library
{
    public class BinaryTree<T>: IEnumerable<T>
    {
        public int Count { get; private set; }
        private class Node
        {
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
        }
        private Comparison<T> comparer;
        private Node root;
        public BinaryTree()
        {
            comparer = Comparer<T>.Default.Compare;
        }
        public BinaryTree(IComparer<T> comparer)
        {
           if (ReferenceEquals(comparer, null)) throw new ArgumentNullException("comparer is null");

           this.comparer = comparer.Compare;
        }
        public BinaryTree(Comparison<T> comparer)
        {
            if(ReferenceEquals(comparer, null)) throw new ArgumentNullException("comparer is null");

            this.comparer = comparer;
        }

        public void Add(T data)
        {
            Count++;
            Node node = new Node();
            node.Data = data;

            if (root == null)
                root = node;
            else
            {
                Node current = root;
                Node parent = null;

                while (current != null)
                {
                    parent = current;
                    if (comparer(data, current.Data) == 0)
                    {
                        Count--; return;
                    }
                    if (comparer(data, current.Data) > 0)
                        current = current.Right;
                    else
                         current = current.Left;
                }

                if (comparer(data, parent.Data) >  0)
                    parent.Right = node;
                else
                    parent.Left = node;               
            }
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            return PreOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> PreOrder()
        {
            return PreOrder(root);
        }
        public IEnumerable<T> PostOrder()
        {
            return PostOrder(root);
        }
        public IEnumerable<T> InOrder()
        {
            return InOrder(root);
        }
        private IEnumerable<T> PreOrder(Node current)
        {            
            yield return current.Data;
            if (current.Left != null)
            {
                foreach (var item in PreOrder(current.Left))
                    yield return item;
            }
            if (current.Right != null)
            {
                foreach (var item in PreOrder(current.Right))
                    yield return item;
            }
        }
        private IEnumerable<T> PostOrder(Node current)
        {
            if (current.Left != null)
            {
                foreach (var item in PostOrder(current.Left))
                    yield return item;
            }
            if (current.Right != null)
            {
                foreach (var item in PostOrder(current.Right))
                    yield return item;
            }
            yield return current.Data;
        }

        private IEnumerable<T> InOrder(Node current)
        {
            if (current.Left != null)
            {
                foreach (var item in InOrder(current.Left))
                    yield return item;
            }
            yield return current.Data;
            if (current.Right != null)
            {
                foreach (var item in InOrder(current.Right))
                    yield return item;
            }
        }


    }
}
