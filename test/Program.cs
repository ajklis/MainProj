using System;
using System.IO;
using Functions;
/*
using static System.Console;
using static Functions.BasicFunctions;
using static Functions.ArrayFunctions;
using static Functions.StringFunctions;
*/
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> List = new CustomList<int>(new int[] {1,2,3,4});
            List.ShowList();

        }

        
    }
}

