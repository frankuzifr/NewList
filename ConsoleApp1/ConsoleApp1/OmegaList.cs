
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class OmegaList
    {
        private static int[] newList = new int[0];

        public static int Count => newList.Length;

        public OmegaList(params int[] args)
        {
            newList = new int[args.Length];
            foreach (var i in newList)
            {
                newList[i] = args[i];
            }
        }

        public static int[] AddElement(int number)
        {
            var oneMoreList = new int[newList.Length + 1];
            newList.CopyTo(oneMoreList, 0);
            oneMoreList[oneMoreList.Length - 1] = number;
            newList = oneMoreList;
            return newList;
        }

        public static int[] DeleteElement(int num)
        {
            for (int i = num; i < newList.Length; i++)
            {
                if(i != newList.Length - 1)
                newList[i] = newList[i + 1];
            }
            var oneMoreList = new int[newList.Length - 1];
            newList.CopyTo(oneMoreList, 0);

            newList = oneMoreList;
            return newList;
        }

        public static bool Contains(int number)
        {
            foreach (int i in newList)
            {
                return newList[i] == number;
            }

            return false;
        }

        public static int[] Clear()
        {
            newList = null;
            return newList;
        }

    }
}