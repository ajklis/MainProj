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
            uint n = 5;
            Console.WriteLine(BinaryOperations.ReturnBinary(n));
            Console.WriteLine(BinaryOperations.ReturnBinaryWithoutZeros(n));
        }
    }
}

