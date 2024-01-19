using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    public class Doubly_LinkedList<T> : IEnumerable<T>,ICollection<T>
    {
        public Node<T> Head{ get; set; }

        public Node<T> Tail { get; set; }

        public int Count { get; protected set; }

        public bool IsReadOnly => false;

        public Doubly_LinkedList() { Count = 0;}

        public Doubly_LinkedList(T headValue)
        {
            Head = new Node<T>(headValue);
            Tail = Head;
            Count = 1;
        }

        public Doubly_LinkedList(IEnumerable<T> values)
        {
            IEnumerator<T> enumerator = values.GetEnumerator();

            if (enumerator.MoveNext())
            {
                Head = new Node<T>(enumerator.Current);
                Tail = Head;

                Count = 1;
            }
            else
            {
                return;
            }

            

            while (enumerator.MoveNext())
            {
                Node<T> newNode = new Node<T>(enumerator.Current);
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;

                Count++;
            }
        }



        public void Add(T item)
        {
            Node<T> currentHead = Head;
            Node<T> newHead = new Node<T>(item, currentHead);
            currentHead.Previous = newHead;
            Head = newHead;
            Count++;
        }

        public void Clear()
        {
            Head = Tail = null;
        }

        public bool Contains(T item)
        {
            foreach (T collectionItem in this)
            {
                if (collectionItem.Equals(item)) return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> currentNode = Head;
            if (currentNode == null) return;

            while (arrayIndex < array.Length && Count - arrayIndex >= 0)
            {
                array[arrayIndex] = currentNode.Value;
                currentNode = currentNode.Next;
                arrayIndex++;
            }
        }

        

        public bool Remove(T item)
        {
            Node<T> current = Head;

            if (current.Value.Equals(item))
            {
                Head = current.Next;
                Head.Previous = null;
                Count--;
                return true;
            }

            Node<T> previous = Head;
            Node<T> tmp;

            current = current.Next;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    tmp = current.Next;
                    previous.Next = tmp;
                    tmp.Previous = previous;
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public Doubly_LinkedList<T> Reverse()
        {
            var result = new Doubly_LinkedList<T>();

            foreach (var item in this)
            {
                result.Add(item);
            }
            return result;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public class Enumerator<T> : IEnumerator<T>
    {
        private Doubly_LinkedList<T> list = null;
        private Node<T> currentNode = null;
        private int index = -1;

        public Enumerator(Doubly_LinkedList<T> linkedList)
        {
            list = linkedList;
        }

        public bool MoveNext()
        {
            currentNode = index < 0 ? list.Head : currentNode.Next;
            index++;
            return currentNode != null;
        }

        public void Reset()
        {
            currentNode = null;
            index = -1;
        }

        public T Current => currentNode.Value;

        object IEnumerator.Current => Current;

        public void Dispose() { }
    }

    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }

        public Node(Node<T> previous,T value)
        {
            Value = value;
            Previous = previous;
        }

        public Node(Node<T> previous, T value, Node<T> next)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }
    }
}
