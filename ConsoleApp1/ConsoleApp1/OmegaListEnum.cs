using System;
using System.Collections;
using System.Transactions;

namespace ConsoleApp1
{
    public class OmegaListEnum : IEnumerator
    {
        private int[] list;
        private int position = -1;

        public OmegaListEnum(int[] newList)
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

        private int Current
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