using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchHexadecimalNumbers
{
    public class MatchHexadecimalNumbers
    {
        public static void Main()
        {
            var pattern = @"\b(?:0x)?[0-9A-F]+\b";
            var numbers = Console.ReadLine();
            var matches = Regex.Matches(numbers, pattern);
            var matchedNumbers = matches.Cast<Match>().Select(a => a.Value.Trim()).ToArray();
            Console.WriteLine(string.Join(" ", matchedNumbers));
        }
    }
}
