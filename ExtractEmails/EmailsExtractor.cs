using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    public class EmailsExtractor
    {
        public static void Main()
        {
            var pattern = @"(?<=\s)[a-z0-9]+([-.]\w*)*@[a-z]+([-.]\w*)*(\.[a-z]+)";
            var text = Console.ReadLine();
            var matches = Regex.Matches(text, pattern);
            foreach (Match mail in matches)
            {
                Console.WriteLine(mail.Value);
            }
        }
    }
}
