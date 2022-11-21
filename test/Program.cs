using System;
using System.IO;
using static Functions.BasicFunctions;
using static Functions.ArrayFunctions;
using static Functions.StringFunctions;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Ala ma \nkota";
            string[] words = ReturnWords(text);
            foreach (string s in words)
                Console.Write(s + ";\n");
        }
    }
}

