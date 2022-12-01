using System;
using System.Threading;

namespace RekurencyjneKolorowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[,] dane1 = {
            { 0, 1, 1, 1, 0, 0 },
            { 0, 1, 0, 1, 1, 0 },
            { 0, 1, 0, 0, 1, 0 },
            { 0, 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 }};
            Kolorowanie(dane1, 0, 0);
            Show(dane1);

            byte[,] dane2 = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
            { 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0},
            { 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0},
            { 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0},
            { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0},
            { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
            { 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0},
            { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0},
            { 0, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0},
            { 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
            { 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} };

            Kolorowanie(dane2, 8, 3);
            Show(dane2);
        }

        static byte[,] Kolorowanie(byte[,] dane, int x, int y) //x - row, y - column
        {
            if (dane[x, y] == 1) return dane;
            if (dane[x, y] == 2) return dane;
            //Show(dane);
            dane[x, y] = 2;
            //getlength(1) columns, getlength(0) rows
            if (x + 1 < dane.GetLength(0))
                dane = Kolorowanie(dane, x + 1, y);
            if (x > 0)
                dane = Kolorowanie(dane, x - 1, y);
            if (y + 1 < dane.GetLength(1))
                dane = Kolorowanie(dane, x, y + 1);
            if (y  > 0)
                dane = Kolorowanie(dane, x, y - 1);

            return dane;
        }

        static void Show(byte[,] dane)
        {
            Console.Clear();
            for(int i=0; i<dane.GetLength(0); i++)
            {
                for(int j=0;j<dane.GetLength(1); j++)
                {
                    Console.Write(dane[i,j] + " ");
                }
                Console.Write("\n");
            }
            //Thread.Sleep(2000);
        }
    }
}

