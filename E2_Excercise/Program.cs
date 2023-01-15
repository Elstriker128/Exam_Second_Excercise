using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E2_Excercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count;
            Console.Write("Input word: ");
            string word = Console.ReadLine();
            string fin = "Duomenys.txt";
            string punctuation = "[ ,.;:!?()]+";
            count = FindCount(fin, punctuation, word);
            Console.WriteLine(count);
        }
        public static int FindCount(string fin, string punctuation, string word)
        {
            int count = 0;
            using (StreamReader sr = new StreamReader(fin))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = Regex.Split(line, punctuation);
                    foreach (string value in values)
                    {
                        Match match = Regex.Match(value, $"(^|[{punctuation}]+)({word})([{punctuation}]+|$)");
                        if (match.Groups[2].Value == word)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }
    }
}
