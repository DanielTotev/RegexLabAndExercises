using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    public class DatesMatcher
    {
        public static void Main()
        {
            var pattern = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            var datesAsString = Console.ReadLine();
            var matchedDates = Regex.Matches(datesAsString, pattern);
            foreach (Match date in matchedDates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
