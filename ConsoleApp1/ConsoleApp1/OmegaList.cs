using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class OmegaList : IEnumerable<int>
    {
        private int[] list;
        int count, capacity;

        public int this[int i]
        {
            set { list[i] = value; }
            get { return list[i]; }
        }

        public int Count => list.Length;

        public OmegaList(params int[] args)
        {
            list = new int[args.Length];
            foreach (var i in list)
            {
                list[i] = args[i];
            }
        }

        public void AddElement(int number)
        {
            if (count == capacity)
            {
                capacity = capacity * 2 + 1;
                Array.Resize(ref list, capacity);
            }
            list[count] = number;
            count++;
        }
        
        public void AddRange(IEnumerable<int> numbers)
        {
            foreach (var item in numbers)
            {
                AddElement(item);
            }
        }
        public int RemoveRange(IEnumerable<int> numbers)
        {
            var countDeletedElements = 0;
            foreach (var item in numbers)
            {
                if (RemoveElement(item))
                {
                    countDeletedElements++;
                }
            }
            return countDeletedElements;
        }

        public bool RemoveElement(int value)
        {
            var ind = FindElement(list, value);

            if (ind != -1)
            {
                ShiftElement(ind);
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

        private int FindElement(int[] array, int number)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    return i;
                }
            }
            return -1;
        }

        private void ShiftElement(int ind)
        {
            for (var i = ind; i < list.Length - 1; i++)
            {
                list[i] = list[i + 1];
            }

            list[list.Length - 1] = 0;
        }

        public bool Contains(int number)
        {
            foreach (var i in list)
            {
                if(i == number)
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            var newList = new int[0];
            list = newList;
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var t in list)
                yield return t;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}