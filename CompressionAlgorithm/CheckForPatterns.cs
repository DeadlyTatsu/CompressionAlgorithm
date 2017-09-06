using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CompressionAlgorithm
{
    class CheckForPatterns
    {
        public static string[] Start(string input)
        {
            Console.WriteLine("[Pattern Recognition Started]");

            input = input.Replace(' ', '_');
            // how many char-patterns to look for
            int num = 3;

            List<List<string>> NCharList = new List<List<string>>() ;
            List<Pattern> Patterns = new List<Pattern>();

            // First check 2-char patterns, then go to 3 ect...
            for (int a = 2; a < num + 1; a++)
            {
                // Create a list for every char patter type (2chars, 3chars, 4chars etc.)
                List<string> list = new List<string>();
                NCharList.Add(list);

                // Loop through all pattern combinations
                for (int i = 0; i < input.Length - a; i++)
                {
                    string pattern = "";

                    // Add the selected chars together to make a string
                    for (int x = 0; x < a; x++)
                    {
                        pattern += input[i + x];
                    }

                    // Add the string to a list
                    NCharList[a - 2].Add(pattern);                    
                }

                Console.WriteLine("Amount of {0}-char patterns found: {1}", a, NCharList[a - 2].Count);
            }

            foreach (var patternList in NCharList)
            {
                patternList.Sort();

                while (patternList.Count != 0)
                {
                    int index = patternList.FindLastIndex(x => x == patternList[0]);
                    int occurances = index + 1;
                    Pattern p = new Pattern(patternList[0], occurances);
                    Patterns.Add(p);
                    patternList.RemoveRange(0, occurances);
                }

                Console.WriteLine("Uniqe patterns found: {0},", Patterns.Count
                    );
            }

            Patterns = Patterns.OrderBy(x => -x.occurrences).ToList();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("'" + Regex.Escape(Patterns[i].characters) + "' : " + Patterns[i].occurrences);
            }

            return null;
        }
    }
}
