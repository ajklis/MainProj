using System;
using System.IO;

namespace Szyfrowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            string alfabet = WczytajAlfabet(null);
            int len = alfabet.Length;
            
            Console.WriteLine("Podaj lokalizacje pliku z tekstem: ");
            string path = Console.ReadLine();

            Console.WriteLine("Przesuniecie: ");
            string temp = Console.ReadLine();
            int przesuniecie = Convert.ToInt32(temp);

            string tekst;
            StreamReader sr = new StreamReader(path);
            tekst = sr.ReadToEnd();
            sr.Close();

            Console.WriteLine("Odczytane i odszyfrowane:");
            //wszystkie znaki ktore nie sa w alfabet.txt sa zamieniane na -, wszystkie spacje zostaja

            string odszyfrowane = "";

            for (int i = 0; i < tekst.Length; i++)
            {
                char c = tekst[i];
                int index = CzyZawiera(c, alfabet);
                if (c == ' ' || c == '\n') odszyfrowane += tekst[i];
                else if (index != -1)
                {
                    int p = index - przesuniecie;
                    if (p < 0) p += len;
                    if (p >= len) p -= len;
                    odszyfrowane += alfabet[p];
                }
                    
                else
                    odszyfrowane += '-';
            }
            Console.WriteLine(odszyfrowane);

            Console.WriteLine("Odczytane i zaszyfrowane:");

            string zaszyfrowane = "";

            for (int i = 0; i < tekst.Length; i++)
            { 
                char c = tekst[i];
                int index = CzyZawiera(c, alfabet);
                if (c == ' ' || c == '\n') zaszyfrowane += tekst[i];
                else if (index != -1)
                {
                    int p = index + przesuniecie;
                    if (p < 0) p += len;
                    if (p >= len) p -= len;
                    zaszyfrowane += alfabet[p];
                }
                else
                    zaszyfrowane += '-';
            }
            Console.WriteLine(zaszyfrowane);
        }

        //alfabet ma wszystkie znaki w jednej linii, nie są oddzielone spacjami
        static string WczytajAlfabet(string path)
        {
            if (path == null)path = "alfabet.txt";

            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();
            sr.Close();

            return line;
        }

        static int CzyZawiera(char c, string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (c == s[i]) return i;
            return -1;
        }
    }
}

