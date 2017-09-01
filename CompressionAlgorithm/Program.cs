using System;
using System.Diagnostics;
using System.IO;

namespace CompressionAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); 

            // 1. Load file to a string (return string)
            string readText = File.ReadAllText("C:\\Users\\torbe\\Desktop\\Camellia_-_Danger_Drug_Nakano_Yuko_Compulsion [0.9x].osu");

            // 2. Check for patterns (return string[] with most reoccuring patterns first)
            string[] patterns = CheckForPatterns.Start(readText);

            // 3. Create a dicctionary and apprehend it to the string (return string)

            // 4. Compress string (return string)

            // 5. Send string back to a file

            stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + "ms");

            Console.ReadKey();

        }
    }
}
