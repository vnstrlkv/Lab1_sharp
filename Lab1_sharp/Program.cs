using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
//2.7. Поменять местами значения элементов двухмерно¬го массива вещественных чисел, симметричных относитель¬но побочной диагонали.
namespace Lab1_sharp
{
    class Program
    {

        static string DeleteSpace (string str)
        {
            string result = "";
            char[] tmp = str.ToCharArray();
            char[] tmp2 = new char[tmp.GetLength(0)];
            int k = 0;
            for (int i = 0; i != tmp.GetLength(0); i++)
            {
                if (tmp[i] == ' ' && tmp[i + 1] == ' ')
                    continue;
                tmp2[k] = tmp[i];
                k++;
            }
            result = CharArrayToString(tmp2);
            return (result);
        }

      static string CharArrayToString(char[] ar)
        {
            string result = "";
            for (int i = 0; i < ar.Length; i++) result += ar[i];
            return (result);
        }



        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        static void PrintArray<T>(ref T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write("{0,10:0.0}", array[i, j]);
                Console.WriteLine();
            }
        }


       static int FindMatchAmount(string str, string strpat)
        {
            Regex pat = new Regex(strpat);
            Match match = pat.Match(str);
            int amount=0;
           
           while (match.Success)
            {
              int c= match.Index;
                if (c==0 || str[c-2]=='.' || str[c-1]=='\n')
                    amount++;
                    match = match.NextMatch();                
            }
            return (amount);
        }

        static void ArrayMirror()
        {
            double[,] array = new double[5, 5];
            Random rand = new Random();
            var max = 50;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array.SetValue(rand.Next(max) * rand.NextDouble(), i, j);
                }
            Console.WriteLine("Исходный массив");
            PrintArray<double>(ref array);

            for (int i = 1; i < array.GetLength(0); i++)
                for (int j = 0; j <= i - 1; j++)
                {
                    Swap<double>(ref array[i, j], ref array[j, i]);
                }


            Console.WriteLine();
            Console.WriteLine("Перевернутый массива");
            PrintArray<double>(ref array);
        }
        static void DeleteSpaces()
        {
            /*3.7. Составить программу, 
        * которая будет вводить строку в переменную String. 
        * Удалить из нее все лишние пробелы, оставив между словами не более одного. Результат поместить в новую строку.*/
            string str;
            Console.WriteLine("Введите строку:");
            str = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(str);
            str = DeleteSpace(str);
            Console.WriteLine("Без пробелов");
            Console.WriteLine(str);

        }

        static void FindText()
        {
            /*4.7. Задан текст. Определить сколько предложений начинается со слова “Информатика”.*/
            string str, strpat;
            Console.WriteLine("Поиск по образцу");

            using (TextReader fs = new StreamReader(@"1.txt", Encoding.Default))
            {
                str = fs.ReadToEnd();
            }
            int amount = 0;
            strpat = "Информатика";
            Console.WriteLine(str);
            amount = FindMatchAmount(str, strpat);
            Console.WriteLine("");
            Console.WriteLine("Количество предложений = {0}", amount);
        }

        static void Main(string[] args)
        {
            ArrayMirror();
            FindText();
          //  DeleteSpaces();
        }
}
}
