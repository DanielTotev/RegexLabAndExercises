using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace ExtractSentencesbyKeyword
{
    public class Program
    {
        public static void Main()
        {
            //var specialWord = Console.ReadLine();
            //var text = Console.ReadLine();
            //var pattern = $@"\b[a-zA-z\w\-, ]+ {specialWord} ([a-zA-z\w\- ]+)*[!\.?]\b";
            //var regex = new Regex(pattern);
            //var matches = regex.Matches(text);
            //var sentancesWithoutBannedCharacters = matches.Cast<Match>().Select(a => a.Value.TrimStart().TrimEnd(new[] { '.', '!', '?' })).ToArray();
            //Console.WriteLine(string.Join($"{Environment.NewLine}", sentancesWithoutBannedCharacters));
            string keyWord = Console.ReadLine();
            string[] sentences = Console.ReadLine().Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"\W"; // All non-letter chars
            List<string> results = new List<string>();

            foreach (string sentence in sentences)
            {
                string[] words = Regex.Split(sentence, pattern);
                if (words.Any(w => w.Equals(keyWord)))
                {
                    results.Add(sentence);
                }
            }

            foreach (string keySentence in results)
            {
                Console.WriteLine(keySentence.Trim());
            }
        }
    }
}
