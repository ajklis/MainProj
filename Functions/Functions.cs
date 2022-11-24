/* żeby dodać funkcje do projektu:
 * prawym przyciskiem na projekt -> dodaj -> odwołanie
 * tam zaznaczyć "Functions" 
 * ewentualnie można dodać sam plik .dll, który powstaje po kompilacji bazy klas
 */



using System;
using System.Drawing;
using System.IO;

namespace Functions
{
    public static class BasicFunctions
    { 
        /// <summary>
        /// Zwraca silnie liczby
        /// </summary>
        /// <param name="n"></param>
        /// <returns>n!</returns>
        public static long Factorial(int n) 
        {
            long output = 1;
            for (int i = 1; i <= n; i++)
                output *= i;
            return output;
        }

        /// <summary>
        /// Zwraca wartość dwumianu Newtona dla n nad k, n >= k
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns>n!/(k!(n-k)!</returns>
        public static long BinominalCoefficient(int n, int k) 
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

    }

    public static class ArrayFunctions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>Reversed array</returns>
        public static T[] ReverseFast<T>(T[] arr)
        {
            //int[] output = arr;

            for (int i = 0; i < arr.Length / 2; i++)
            {
                T temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = temp;
            }

            return arr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns>Reversed array</returns>
        public static T[] Reverse<T>(T[] arr)
        {
            T[] output = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                output[i] = arr[arr.Length - 1 - i];
            }
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="values"></param>
        /// <returns>Expanded array with set of values</returns>
        public static T[] ExpandArray<T>(T[] arr, T[] values)
        {
            T[] output = new T[arr.Length + values.Length];

            for (int i = 0; i < arr.Length; i++)
                output[i] = arr[i];
            for (int i = arr.Length; i < arr.Length + values.Length; i++)
                output[i] = values[i - arr.Length];

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="val"></param>
        /// <returns>Expanded array with one value</returns>
        public static T[] ExpandArray<T>(T[] arr, T val)
        {
            T[] output = new T[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
                output[i] = arr[i];
            output[arr.Length] = val;

            return output;
        }

    }

    public static class StringFunctions
    { 
        public static string[] ReturnAsArray(string input)
        {
            string[] output = new string[0];
            string temp = "";
            for (int i = 0; i < input.Length; i++) 
            {
                char c = input[i];
                if (c != ' ' && c != '\n' && c != '\t')
                    temp += c;
                else
                {
                    if (temp != "")
                        output = ArrayFunctions.ExpandArray(output, temp);
                    temp = "";
                }
            }
            if (temp != "")
                output = ArrayFunctions.ExpandArray(output, temp);
            return output;
        } 
    }

    public static class FileOperations
    {
        /// <summary>
        /// Reads whole file at path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>string</returns>
        public static string ReadAll(string path)
        {
            StreamReader sr = new StreamReader(path);
            string output = sr.ReadToEnd();
            sr.Close();
            return output;
        }

        /// <summary>
        /// Reads whole file at path, white symbols separate words that are put into array
        /// </summary>
        /// <param name="path"></param>
        /// <returns>string[]</returns>
        public static string[] ReadAll_(string path)
        {
            StreamReader sr = new StreamReader(path);
            string output = sr.ReadToEnd();
            sr.Close();
            return StringFunctions.ReturnAsArray(output);
        }
    }

    public static class ImageOperations
    {
        // bitmap and similar things
        // !!!! NOT SUPPORTED ON MAC !!!
        public static Color AverageColor(string imagePath)
        {
            Bitmap bitmap = new Bitmap(imagePath);
            long R = 0, G = 0, B = 0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {
                    Color temp = bitmap.GetPixel(i, j);
                    R += temp.R;
                    G += temp.G;
                    B += temp.B;
                }
            }
            int PixelCount = bitmap.Width * bitmap.Height;
            int aR = (int)(R / PixelCount);
            int aG = (int)G / PixelCount;
            int aB = (int)B / PixelCount;
            return Color.FromArgb(aR,aG,aB);
            
        }
    }

    public static class BinaryOperations
    {
        public static string ReturnBinary(uint n)
        {
            int n_size = 32;
            string output = "";
            for (int i = 0; i < n_size; i++) 
            {
                output = (n & 1) + output;
                n = n >> 1;
            }
            return output;
        }

        public static string ReturnBinaryWithoutZeros(uint n)
        {
            int n_size = 32;
            string output = "";
            for (int i = 0; i < n_size && n != 0; i++)
            {
                output = (n & 1) + output;
                n = n >> 1;
            }
            return output;
        }
    }
}





