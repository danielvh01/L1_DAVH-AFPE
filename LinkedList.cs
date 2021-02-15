using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using L1_DAVH_AFPE;

namespace L1_DAVH_AFPE
{

    public class LinkedList<T> : IEnumerable
    {
        Node<T> First;
        Node<T> End;
        public int Length = 0;
        
        void InsertAtStart(T value)
        {
            Node<T> node = new Node<T>();
            node.value = value;
            if(Length == 0)
            {
                First = node;
                End = node;
            }
            else
            {
                node.next = First;
                First = node;
            }
        }

        void InsertAtEnd(T value)
        {
            Node<T> node = new Node<T>();
            node.value = value;
            if (Length == 0)
            {
                First = node;
                End = node;
            }
            else
            {
                End.next = node;
                End = node;
            }
        }

        public void Insert(T value, int Position)
        {
            Node<T> newNode = new Node<T>();
            newNode.value = value;
            if (Length == 0)
            {
                First = newNode;
                End = newNode;
            }
            else
            {
                if (Position == 0)
                {
                    InsertAtStart(value);
                }
                else if (Position >= Length)
                {
                    InsertAtEnd(value);
                }
                else
                {
                    Node<T> prev = First;
                    while (newNode != null && Position - 1 < Length)
                    {
                        prev = prev.next;
                    }
                    newNode.next = prev.next;
                    prev.next = newNode;
                }
            }
        }

        void DeteleAtStart()
        {
            if(Length <= 1)
            {
                First = null;
                End = null;
            }
            else
            {
                First = First.next;
            }
        }

        void DeleteAtEnd()
        {

            if (Length <= 1)
            {
                First = null;
                End = null;
            }
            else
            {
                Node<T> node = First;
                int cont = 0;
                while(cont < Length)
                {
                    node = node.next;
                    cont++;
                }
                node.next = null;
            }
        }

        public void Delete(int position)
        {

            if (Length <= 1)
            {
                First = null;
                End = null;
            }
            else
            {
                if(position == 0)
                {
                    DeteleAtStart();
                }
                else if(position >= Length)
                {
                    DeleteAtEnd();
                }
                else
                {
                    Node<T> prev = First;
                    Node<T> node = First.next;
                    int cont = 0;
                    while(cont < position - 1)
                    {
                        prev = node;
                        node = node.next;
                        cont++;
                    }
                    prev.next = node.next;
                    node.next = null;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = First;
            while(node != null)
            {
                yield return node.value;
                node = node.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
