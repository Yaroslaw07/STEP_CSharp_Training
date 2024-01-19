using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _Stack
{
    public class Stack<T> : IEnumerable<T>,ICollection<T>
    {
        public bool IsReadOnly => false;


        public int Count { get; private set; }

        public Node<T> Tail { get; set; }

        public Stack() { }

        public Stack(T Value) 
        {
            Tail = new Node<T>(Value);
            Count = 1;
        }

        public Stack(IEnumerable<T> values)
        {
            IEnumerator<T> enumerator = values.GetEnumerator();

            if (enumerator.MoveNext())
            {
                Tail = new Node<T>(enumerator.Current);
                Count = 1;
            }
            else
            {
                return;
            }

            while (enumerator.MoveNext())
            {
                Node<T> newNode = new Node<T>(enumerator.Current);
                newNode.Previous = Tail;
                Tail = newNode;

                Count++;
            }
        }

        public T Pop()
        {
            if (Count < 0)
                throw new IndexOutOfRangeException("Index out of range");
            T value = Tail.Value;

            Tail = Tail.Previous;
            Count--;

            return value;
        }

        public T Top()
        {
            if (Count < 0)
                throw new IndexOutOfRangeException("Index out of range");
            return Tail.Value;
        }


        public void Push(T item)
        {
            Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            Node<T> NewNode = new Node<T>(Tail, item);
            Tail = NewNode;
            Count++;
        }

        public void Clear()
        {
            Tail = null;
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
            Stack<T> tmp = this.Reverse();
            Node<T> currentNode = tmp.Tail;
            if (currentNode == null) return;

            while (arrayIndex < array.Length && Count - arrayIndex >= 0)
            {
                array[arrayIndex] = tmp.Pop();
                arrayIndex++;
            }
        }

        public Stack<T> Reverse()
        {
            var result = new Stack<T>();

            foreach (var item in this)
            {
                result.Add(item);
            }
            return result;
        }

        public bool Remove(T item)
        {
            Node<T> current = Tail;

            if (current.Value.Equals(item))
            {
                Tail = current.Previous;
                Count--;
                return true;
            }

            Node<T> previous = Tail;

            current = current.Previous;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    previous.Previous = current.Previous;
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Previous;
            }

            return false;
        }
    }


    public class Enumerator<T> : IEnumerator<T>
    {
        private Stack<T> list = null;
        private Node<T> currentNode = null;
        private int index = -1;

        public Enumerator(Stack<T> linkedList)
        {
            list = linkedList;
        }

        public bool MoveNext()
        {
            currentNode = index < 0 ? list.Tail : currentNode.Previous;
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

        public Node<T> Previous { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public Node(Node<T> previous, T value)
        {
            Value = value;
            Previous = previous;
        }
    }
}

