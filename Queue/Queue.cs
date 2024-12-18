﻿
using DataStructures.Queue.Contracts;
using System.Collections;

namespace Queue
{
    public class Queue<T> : IQueue<T>
    {
        private readonly Queue<T> _queue;

        public int Count => _queue.Count;

        public T Dequeue()
        {
            return _queue.Dequeue();
        }

        public void Enqueue(T value)
        {
            _queue.Enqueue(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        public T Peek()
        {
            return _queue.Peek();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
