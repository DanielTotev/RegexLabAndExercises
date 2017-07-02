using System;
using System.Text.RegularExpressions;

namespace MatchNumbers
{
    public class NumbersMatcher
    {
        public static void Main()
        {
            var pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            var input = Console.ReadLine();
            var matches = Regex.Matches(input, pattern);
            foreach (Match numberMatch in matches)
            {
                Console.Write(numberMatch.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
