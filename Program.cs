using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3savarankiškas
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "..\\..\\Duomenys.txt";
            char[] punctuation = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            Console.WriteLine("Sutampančių žodžių {0, 3:d}", TaskUtils.Process(CFd, punctuation));
        }
    }

    class TaskUtils
    {
        public static int Process(string fin, char[] punctuation)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            int equal = 0;
            foreach (string line in lines)
                if (line.Length > 0)
                    equal += WordsPolindromes(line, punctuation);
            return equal;
        }
        private static int WordsPolindromes(string line, char[] punctuation)
        {
            string[] parts = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            int equal = 0;
            int length = 0;
            bool poli = true;
            foreach (string word in parts)
            {
                if (word.Length > 0)
                {
                    length = word.Length;
                    for (int i = 0; i < length / 2; i++)
                    {
                        if (word[i] != word[length - i-1])
                        {
                            poli = false;
                        }
                        if (poli)
                        {
                            equal++;
                        }
                    }

                    
                }
            }
            return equal;
        }
    }
}
