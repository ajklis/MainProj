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
            string text = "Ala ma \nkota";
            string[] words = StringFunctions.ReturnAsArray(text);
            foreach (string s in words)
                Console.WriteLine(s);
        }
    }
}

