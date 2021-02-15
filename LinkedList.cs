using System;
using System.Collections.Generic;
using System.Text;

namespace L1_DAVH_AFPE
{

    public class LinkedList : IEnumerable<out T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            var node = First;
            while(node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
