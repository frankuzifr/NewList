using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class OmegaList<T> : IEnumerable
    {
        private T[] list;
        int count, capacity;

        public T this[int i]
        {
            set { list[i] = value; }
            get { return list[i]; }
        }

        public int Count => count;

        public OmegaList(int capacity = 0)
        {
            capacity = this.capacity;
            Array.Resize(ref list, capacity);
        }   

        public void Add(T number)
        {
            if (count == capacity)
            {
                capacity = capacity * 2 + 1;
                Array.Resize(ref list, capacity);
            }
            list[count] = number;
            count++;
        }
        
        public void AddRange(IEnumerable<T> numbers)
        {
            foreach (var item in numbers)
            {
                Add(item);
            }
        }
        

        public bool Remove(T value)
        {
            var ind = FindElement(list, value);

            if (ind != -1)
            {
                
                ShiftElements(ind);
                if ((capacity - 1) / 2 == count)
                {
                    capacity = (capacity - 1) / 2;
                    Array.Resize(ref list, capacity);
                }
                count--;
                return true;
                
            }
            else
            {
                return false;
            }
        }

        private int FindElement(T[] array, T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (Equals(array[i], element))
                {
                    return i;
                }
            }
            return -1;
        }

        private void ShiftElements(int ind)
        {
            for (var i = ind; i < Count - 1; i++)
            {
                list[i] = list[i + 1];
            }
        }

        public int RemoveRange(IEnumerable<T> numbers)
        {
            var countDeletedElements = 0;
            foreach (var item in numbers)
            {
                if (Remove(item))
                {
                    countDeletedElements++;
                }
            }
            return countDeletedElements;
        }
        
        public bool Contains(T number)
        {
            foreach (var i in list)
            {
                if(Equals(i, number))
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            Array.Resize(ref list, 0);
            count = 0;
            capacity = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return list[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}