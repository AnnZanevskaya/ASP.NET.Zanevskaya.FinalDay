using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Library
{
    public class CustomHashTable
    {
        private class Node
        {
            public object Value { get; private set; }
            public object Key { get; set; }
            public Node(object key, object value)
            {
                Key = key;
                value = value;
            }
        }
        private Node[] node;
        private int capasity = 1;

        public CustomHashTable()
        {
            node = new Node[capasity];
        }
        public CustomHashTable(int capasity)
        {
            if (capasity < 0) throw new ArgumentNullException("capasity");
            node = new Node[capasity];
        }
        public  void Add(Object key, Object value)
        {
            if (ReferenceEquals(key, null)
                throw new ArgumentNullException("key");
        }

    }
}
