using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private static OmegaList newList = new OmegaList(5){2, 4, 2, 4, 6};
        private static List<int> originalList = new List<int>(100){2};

        static void Main(string[] args)
        {
            //newList.Add(2);
            for (var i = 0; i < newList.Count; i++)
            {
                var value = newList[i];
                Console.Write(value + " ");
            }
            Console.WriteLine();
            //newList.RemoveElement(4);
            //newList.RemoveElement(2);

            for (var i = 0; i < newList.Count; i++)
            {
                var value = newList[i];
                Console.Write(value + " ");
                
            }
            Console.WriteLine();
            var value2 = newList.Count;
            Console.WriteLine(value2 + " ");
            Console.WriteLine();

            var two = (from u in newList where u == 2 select u).Take(2);
            newList.RemoveRange(new []{4, 2});
            foreach (var item in newList)
            {
                Console.Write(item + " ");
            }
            
            //Console.WriteLine(m);
            // for (int i = 0; i < newList.Count; i++)
            // {
            //     var value = newList.GetAt(i);
            //     Console.WriteLine(value);
            // }
            //
            //
            // for (int i = 0; i < newList.Count; i++)
            // {
            //     var value = newList.GetAt(i);
            //     Console.WriteLine(value);
            // }
            //
            // newList.Clear();
            //
            // for (int i = 0; i < newList.Count; i++)
            // {
            //     var value = newList.GetAt(i);
            //     Console.WriteLine(value);
            // }

            Console.ReadKey();
        }
    }
}