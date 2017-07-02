using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    public class MatchNames
    {
        public static void Main()
        {
            string pattern = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b";
            string names = Console.ReadLine();
            MatchCollection matchedNames = Regex.Matches(names, pattern);
            foreach (Match name in matchedNames)
            {
                Console.Write(name.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
