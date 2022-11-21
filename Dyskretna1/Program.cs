using System;

namespace Dyskretna1
{
    class Program
    {
        /*
         * 
         * Suma wszystkich pól w przecięciu n figur ( razem z polem które do żadnej figury nie należy
         * 
         */

        static void Main(string[] args)
        {
            Console.WriteLine(Newton(4, 3));
            for (int i=2; i<15; i++)
            {
                Console.WriteLine(i + ": " + Func1(i));
            }

            //int temp = Func1(3);
        }


        static int Func1(int n)
        {
            int output = 0;
            for (int i = 1; i <= n; i++)
            {
                output += Newton(n, i);
                //Console.WriteLine(n + " " + i + ": " + Newton(n, i));
            }
            return ++output;
        }

        static int Silnia(int n)
        {
            int a = 1;
            for (int i = 2; i <= n; i++) 
                a *= i;
            return a;
        }

        static int Silnia(int n, int k)
        {
            int a = 1;
            for (int i = k + 1 ; i <= n; i++) 
                a *= i;
            return a;
        }

        //static int PartSilnia()

        static int Newton(int n, int k)
        {
            if (n == k || k == 0)
                return 1;
            else if (k == 1 || k == n-1)
                return n;
            //int M = Math.Max(k, n - k);
            return Silnia(n) / (Silnia(n - k) * Silnia(k));
        }
    }
}

