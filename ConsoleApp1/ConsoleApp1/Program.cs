using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static OmegaList newList = new OmegaList (1, 2 ,3 );
        
        static void Main(string[] args)
        {
            newList = new OmegaList(OmegaList.AddElement(5));
            newList = new OmegaList(OmegaList.AddElement(4));
            newList = new OmegaList(OmegaList.AddElement(1));
            newList = new OmegaList(OmegaList.AddElement(23));
            newList = new OmegaList(OmegaList.AddElement(34));
            newList = new OmegaList(OmegaList.AddElement(55));
            //newList = new OmegaList(OmegaList.DeleteElement(2));
            Console.WriteLine(newList);
            Console.ReadKey();
        }
        
    }
}