using DataStructures.LinkedList.SinglyLinkedList;
using DataStructures.Stack.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> _list;

        public LinkedListStack()
        {
            _list = new SinglyLinkedList<T>();
        }

        public LinkedListStack(IEnumerable<T> collection) : this()
        {
            foreach (T item in collection)
            {
                Push(item);
            }
        }
        public int Count => _list.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        // The Peek() method returns the last added element (Head) of the stack. 
        // This is because the Push() method uses AddFirst() to add elements at the head of the list, meaning the new element always becomes the head. 
        // This ensures the stack follows the Last In, First Out (LIFO) principle, where the most recently added element is the first to be removed.

        public T Peek()
        {
            return Count == 0 ? default(T) : _list.Head.Value;
        }

        public T Pop()
        {
            if(Count == 0)
            {
                throw new Exception("Empty Stack");
            }
            var result = _list.RemoveFirst();
            return result;
        }

        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
