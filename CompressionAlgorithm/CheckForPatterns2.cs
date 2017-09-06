using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CompressionAlgorithm
{
    class CheckForPatterns2
    {
        // Lists
        static Pattern[] patternList1;
        static List<Pattern> patternList2;

        public static string[] Start(string input)
        {
            Console.WriteLine("[Pattern Recognition Started]");

            int stringLenght = input.Length;

            patternList1 = new Pattern[stringLenght - 1];
            patternList2 = new List<Pattern>(stringLenght - 1);

            // CHANGE THESE VALUES
            var maxPatternLenght = 2;

            var compleatePatternList = new List<Pattern>(input.Length * maxPatternLenght);

            for (int patternLenght = 0; patternLenght <= maxPatternLenght; patternLenght++)
            {
                var patternList = patternList2;

                if (patternLenght < 2)
                {
                    continue;
                }

                // Loop through all pattern combinations
                for (int i = 0; i < input.Length + 1 - patternLenght; i++)
                {
                    string patternString = input.Substring(i, patternLenght);

                    // Check if list contains pattern
                    int index = patternList.FindIndex(x => x.characters == patternString);

                    if (index != -1)
                    {
                        // Add occurence to pattern
                        patternList[index].AddOccurence();
                    }
                    else
                    {
                        // Add pattern to list
                        Pattern pattern = new Pattern(patternString);
                        patternList.Add(pattern);
                    }
                }

                patternList.RemoveAll(x => x.occurrences == 1 || x.score <= 0);
                compleatePatternList.AddRange(patternList);
            }
           
            Console.WriteLine("[Pattern Recognition Ended]\n");

            compleatePatternList = compleatePatternList.OrderBy(x => x.score).ToList();

            Console.WriteLine("Unique Patterns Found: " + compleatePatternList.Count());

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Pattern: '" + Regex.Escape(compleatePatternList[i].characters) + "'    Occu: '" + compleatePatternList[i].occurrences + "'   Score: '" + compleatePatternList[i].score + "'");
            }

            return null;
        }
    }
}
