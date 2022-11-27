using System;

namespace Rekurencja_test
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        //suma wszystkich liczb mniejszych od n podzielnych przez 3 i niepodzielnych przez 7

        static int func(int n)
        {
            int tu = 0, rek;
            if (n == 0)
                return 0;
            if (n % 3 != 0)
            {
                n -= n % 3;
                //Console.WriteLine($"niepodzielne przez 3, zmieniam n na {n}");
                if (n % 7 != 0)
                    tu = n;
                //Console.WriteLine($"tu = {tu} dla n = {n}");
                n += 3;
            }
            else
            {
                //Console.WriteLine($"wykonuje dla n = {n}");
                if ((n - 3) % 7 != 0)
                    tu = n - 3;
                //Console.WriteLine($"tu = {tu} dla n = {n}");
            }
                
            //Console.WriteLine($"teraz funckja dla {n-3}");
            //rek
            rek = func(n - 3);
            
            return tu + rek;
        }
        //3 + 6 + 9 + 12 + 15 + 18 + /21/ = 63
    }
}

