using System;

namespace Funkcje
{
    public class OperacjeBitowe
    {
        public static string ZwrocBinarnie(ulong liczba)
        {
            string output = "";
            string liczba_ = ZwrocBinarnieZZerami(liczba);
            bool koniec0 = false;
            for (int i = 0; i < liczba_.Length; i++)
            {
                if (!koniec0 && liczba_[i] == '1') koniec0 = true;
                if (koniec0) output += liczba_[i];
            }
            return output;
        }

        public static string ZwrocBinarnieZZerami(ulong liczba)
        {
            string output = "";
            if (liczba == 0) return "0";
            for (int i = 0; i < 32; i++)
            {
                output = (liczba & 1) + output;
                liczba = liczba >> 1;
            }
            return output;

        }

        public static int IleJedynek(ulong liczba)
        {
            int output = 0;
            for (int i = 0; i < 64; i++)
            {
                if ((liczba & 1) == 1) output++;
                liczba = liczba >> 1;
            }

            return output;
        }

        public static int IleJedynekRek(ulong liczba)
        {
            int tu = 0, rek;
            if (liczba == 0) return 0;
            if ((liczba & 1) == 1) tu = 1;
            rek = IleJedynekRek(liczba >> 1);
            return tu + rek;
        }

        public static uint UstawBit(uint stara_liczba, int index, int wart)
        {
            uint wart_ = (stara_liczba >> index) & 1;
            uint liczba = 1;
            liczba = liczba << index;
            if (wart == wart_)
                return stara_liczba;
            else if (wart_ == 0)
                return stara_liczba | liczba;
            else
                return stara_liczba & ~liczba;
        }

        public static uint ZwrocLiczbeNaBitach(uint rej, int pocz, int kon)
        {
            int len = kon - pocz + 1;
            uint temp = 0;
            for (int i = 0; i < len; i++)
            {
                temp = temp << 1;
                temp++;
            }
            //Console.WriteLine("temp binarnie:\n" + ZwrocBinarnieZZerami(temp));
            temp = temp << pocz;
            uint liczba = rej & temp;
            liczba = liczba >> pocz;
            return liczba;
        }

        public static uint TemperaturaWody(uint rejestr)
        {
            return ZwrocLiczbeNaBitach(rejestr, 7, 11);
        }
    }
}

