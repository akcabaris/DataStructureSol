﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DataStructures.Arrray.Generic
{
    public class Array<T> : ICloneable, IEnumerable<T>
    {
        private int position;
        public int Count => position;
        protected T[] InnerArray { get; set; }

        // it's readonly
        public int Length => InnerArray.Length;
        public Array(int defaultSize = 2)
        {
            position = 0;
            InnerArray = new T[defaultSize]; //fixed size
        }

        // this(sourceArray.Length) gonna call the constructor method  
        public Array(params T[] sourceArray) : this(sourceArray.Length)
        {
            /*
            for(int i = 0; i<sourceArray.Length; i++)
            {
                InnerArray[i] = sourceArray[i];
            }
            */
            System.Array.Copy(sourceArray, InnerArray, sourceArray.Length);

        }

        public Array(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public T GetValue(int index)
        {
            // same !(index >= 0 && index < InnerArray.Length)
            if (index < 0 || index >= InnerArray.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            return InnerArray[index];

        }

        public virtual void SetValue(T value, int index)
        {
            if (index < 0 || index >= InnerArray.Length)
                throw new ArgumentOutOfRangeException();
            if (value == null)
                throw new ArgumentNullException();

            InnerArray[index] = value;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < InnerArray.Length; i++)
            {
                if (GetValue(i).Equals(value))
                {
                    return i;
                }
            }
            return -1; // O(n)
        }


        public void Add(T value)
        {
            if (position == Length)
            {
                DoubleArray();
            }
            if (position < Length)
            {
                InnerArray[position] = value;
                position++;
                return;
            }

        }
        private void DoubleArray()
        {
            // It should be wrapped in a try-catch because 0there might not be enough memory
            try
            {
                var temp = new T[InnerArray.Length * 2];
                System.Array.Copy(InnerArray, temp, InnerArray.Length);
                InnerArray = temp;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public T Remove()
        {
            if (position >= 0)
            {
                var temp = InnerArray[position - 1];
                position--;
                if (position == InnerArray.Length / 4)
                {
                    HalfArray();

                }
                return temp;
            }

            throw new Exception();
        }

        private void HalfArray()
        {
            try
            {
                var temp = new T[InnerArray.Length / 2];
                System.Array.Copy(InnerArray, temp, InnerArray.Length / 2);
                InnerArray = temp;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(InnerArray, position);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] _array;
        private int index;
        private int _count;

        public ArrayEnumerator(T[] array, int count)
        {
            _array = array;
            index = -1;
            _count = count;
        }
        public T Current => _array[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _array = null;
        }

        public bool MoveNext()
        {
            if(index < _count - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
