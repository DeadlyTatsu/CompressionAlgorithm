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
            // how many char-patterns to look for
            int num = 3;

            List<List<Pattern>> AllPatternLists = new List<List<Pattern>>() ;
            int amoutPatterns = 0;

            // First check 2-char patterns, then go to 3 ect...
            for (int a = 2; a < num + 1; a++)
            {
                // Create a list for every char patter type (2chars, 3chars, 4chars etc.)
                List<Pattern> list = new List<Pattern>();
                AllPatternLists.Add(list);

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
                    Pattern p = new Pattern(pattern);
                    AllPatternLists[a - 2].Add(p);                    
                }

                // TODO: COUNT THE OCCURANCES OF THE STRINGS

                AllPatternLists[a - 2] = AllPatternLists[a - 2].OrderBy(x => -x._occurances).ToList();
                amoutPatterns += AllPatternLists[a - 2].Count;
            }

            List<Pattern> mergedPatternList = new List<Pattern>(amoutPatterns);

            for (int i = 0; i < AllPatternLists.Count; i++)
            {
                mergedPatternList.AddRange(AllPatternLists[i]);
            }

            mergedPatternList = mergedPatternList.OrderBy(x => -x._occurances).ToList();


            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("'" + Regex.Escape(mergedPatternList[i]._characters) + "' : " + mergedPatternList[i]._occurances);
            }

            return null;
        }
    }
}
