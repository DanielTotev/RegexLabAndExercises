using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UseYourChainsBuddy
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var paragraphRegex = new Regex(@"<p>(?<message>.*?)<\/p>");
            var paragraphs = paragraphRegex.Matches(input).Cast<Match>().Select(m =>m.Groups["message"].Value).Select(a => Regex.Replace(a, @"[^a-zA-Z0-9]", " ")).Select(a => Regex.Replace(a, @"\s+"," " )).ToArray();
            for (int i = 0; i < paragraphs.Length; i++)
            {
                paragraphs[i] = Rotate13String(paragraphs[i]);
            }
            var result = new StringBuilder();
            foreach (var paragraph in paragraphs)
            {
                result.Append(paragraph);
            }
            Console.WriteLine(result.ToString());
        }

        public static string Rotate13String(string str)
        {
            var result = new StringBuilder();
            foreach (var letter in str)
            {
                result.Append(Rotate13(letter));
            }
            return result.ToString();
        }

        public static char Rotate13(char letter)
        {
            if (!char.IsLetter(letter))
            {
                return letter;
            }
            var offset = char.IsUpper(letter) ? 'A' : 'a';
            var rotatedLetter = (char)(((letter - offset) + 13) % 26 + offset);
            return rotatedLetter;
        }
    }
}
