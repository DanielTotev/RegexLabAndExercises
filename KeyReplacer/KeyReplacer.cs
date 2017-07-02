using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace KeyReplacer
{
    public class KeyReplacer
    {
        public static void Main()
        {
            var regex = new Regex(@"(?<start>[a-zA-Z]+[\|<\\])([\w\|<\\]+)(?<end>[\|<\\][a-zA-Z]+)");
            var keys = regex.Match(Console.ReadLine());
            var start = keys.Groups["start"].Value.ToString().TrimEnd(new char[] { '|', '<', '\\'});
            var end = keys.Groups["end"].Value.ToString().TrimStart(new char[] { '|', '<', '\\' });
            var input = Console.ReadLine();
            var pattern = $@"{start}(?<message>.*?){end}";
            var matches = Regex.Matches(input, pattern).Cast<Match>().Select(a => a.Groups["message"].Value.ToString()).ToArray();
            var isEmpty = EmptyCheck(matches);
            if (isEmpty)
            {
                Console.WriteLine("Empty result");
            }
            else
            {
                Console.WriteLine(string.Join("", matches));
            }

        }

        public static bool EmptyCheck(string[] matches)
        {
            var isEmpty = true;
            for (int i = 0; i < matches.Length; i++)
            {
                if (matches[i] == string.Empty)
                {
                    isEmpty = true;
                }
                else
                {
                    isEmpty = false;
                    break;
                }
            }

            return isEmpty;
        }
    }
}
