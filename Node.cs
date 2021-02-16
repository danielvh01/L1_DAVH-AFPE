using System;
using System.Collections.Generic;
using System.Text;

namespace L1_DAVH_AFPE
{
    public class Node<T>
    {
        public Node<T> next = null;
        public Node<T> prev = null;
        public T value;
    }
}
