using System;
using System.Text.RegularExpressions;
using System.Linq;
namespace ValidUsernames
{
    class UsernamesValidation
    {
        static void Main()
        {
            //“ ”, “/”, “\”, “(“, “)”
            var input = Console.ReadLine().Split(new char[] { ' ', '/', '\\', '(', ')' });
            var regex = new Regex(@"^[A-Za-z][A-Za-z0-9_]{2,24}$");
            var validUserNames = input.Where(u => regex.IsMatch(u)).ToArray();
            var biggestSum = int.MinValue;
            var firstWordToPrint = string.Empty;
            var secondWordToPrint = string.Empty;
            for (int i = 0; i < validUserNames.Length - 1; i++)
            {
                var currentSum = validUserNames[i].Length + validUserNames[i + 1].Length;
                if (currentSum > biggestSum)
                {
                    biggestSum = currentSum;
                    firstWordToPrint = validUserNames[i];
                    secondWordToPrint = validUserNames[i + 1];
                }
            }
            Console.WriteLine(firstWordToPrint);
            Console.WriteLine(secondWordToPrint);
        }
    }
}
