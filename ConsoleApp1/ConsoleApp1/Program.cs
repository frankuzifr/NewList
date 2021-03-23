using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private static OmegaList newList = new OmegaList();
        private static List<int> originalList = new List<int>(100);

        static void Main(string[] args)
        {
            newList.AddElement(2);
            //newList.AddRange(new[] {0, 2, 7});
            //newList.AddRange(new List<int>{1, 2,76});
            newList.AddElement(4);
            //newList.AddElement(6);

            
            /*foreach (var item in originalList)
            {
                originalList.Add(item);
            }*/
            newList.AddElement(7);
            for (var i = 0; i < newList.Count; i++)
            {
                var value = newList[i];
                Console.Write(value + " ");
            }
            Console.WriteLine();
            
            //newList.RemoveRange(new List<int>{0, 2});
            //newList.RemoveElement(4);
            //newList.RemoveElement(7);
            newList.RemoveElement(4);
            newList.RemoveElement(7);
            //newList.RemoveElement(2);
            
            //newList.AddElement(7);
            //var m = newList.RemoveRange(new[] {2, 76});
            for (var i = 0; i < newList.Count; i++)
            {
                var value = newList[i];
                Console.Write(value + " ");
            }
            Console.WriteLine();
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