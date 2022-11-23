///<SuppressTfmSupportBuildWarnings>true</SuppressTfmSupportBuildWarning>

using System;
using System.Drawing;

namespace WykrywanieZaznaczen
{
    class Point
    {
        public int x, y;
        public Point(int xP, int yP)
        {
            x = xP;
            y = yP;
        }
    }

    class Zaznaczenie
    {
        private Point LewyGorny, PrawyDolny;
        Zaznaczenie(int x, int y, int width, int height)
        {
            LewyGorny = new Point(x, y);
            PrawyDolny = new Point(x + width, y + height);
        }

        public string ZwrocPozycjeZaznaczenia()
        {
            string output = "" + LewyGorny.x + " " + PrawyDolny.x + " " +
                LewyGorny.y + " " + PrawyDolny.y;
            return output;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = "obrazek.png";
            string path_ = "obrazek_zaz.png";
            Bitmap obrazek = new Bitmap(path);
            Bitmap obrazek_ = new Bitmap(path_);

            for (int i = 0; i < obrazek.Width; i++)
            {
                for (int j = 0; j < obrazek.Height; j++)
                {
                    Color col = obrazek.GetPixel(i, j);
                    Color col_ = obrazek_.GetPixel(i, j);
                    if (!col.Equals(col_))
                    {
                        Console.WriteLine(col_.R + " " + col_.G + " " + col_.B);
                        i = int.MaxValue;
                        j = int.MaxValue;
                    }
                }
            }
        }
    }
}



