using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumbers
{
    public class MatchPhoneNumbers
    {
        public static void Main()
        {
            var pattern = @"\+359([ -])2\1\d{3}\1\d{4}\b";
            var numbers = Console.ReadLine();
            var phoneMatches = Regex.Matches(numbers, pattern);
            var matchedNumbers = phoneMatches.Cast<Match>().Select(a => a.Value.Trim()).ToArray();
            Console.WriteLine(string.Join(", ", matchedNumbers));
        }
    }
}
