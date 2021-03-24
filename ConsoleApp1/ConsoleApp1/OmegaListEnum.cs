using System;
using System.Collections;
using System.Transactions;

namespace ConsoleApp1
{
    public class OmegaListEnum<T> : IEnumerator
    {
        private T[] list;
        private int position = -1;

        public OmegaListEnum(T[] newList)
        {
            list = newList;
        }

        public bool MoveNext()
        {
            position++;
            return (position < list.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        private T Current
        {
            get
            {
                try
                {
                    return list[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}