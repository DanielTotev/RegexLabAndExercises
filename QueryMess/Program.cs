using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QueryMess
{
    public class Program
    {
        public static void Main()
        {
            var regex = new Regex(@"(?<field>[^&=?]*)=(?<value>[^&=]*)");
            var lines = new Dictionary<string, List<string>>();
            var input = Console.ReadLine();
            while (input != "END")
            {
                var matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    string pattern = @"((%20|\+)+)";
                    var field = match.Groups["field"].Value;
                    field = Regex.Replace(field, pattern, " ").Trim();
                    var value = match.Groups["value"].Value;
                    value = Regex.Replace(value, pattern, " ").Trim();
                    if (!lines.ContainsKey(field))
                    {
                        lines[field] = new List<string>();
                    }
                    lines[field].Add(value);
                }

                foreach (var kvp in lines)
                {
                    var key = kvp.Key;
                    var values = kvp.Value;
                    Console.Write($"{key}=[{string.Join(", ", values)}]");
                }
                Console.WriteLine();
                lines = new Dictionary<string, List<string>>();
                input = Console.ReadLine();
            }
            foreach (var kvp in lines)
            {
                var key = kvp.Key;
                var values = kvp.Value;
                Console.WriteLine($"{key}=[{string.Join(", ", values)}]");
            }
        }
    }
}
