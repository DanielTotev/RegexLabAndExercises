using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace CameraView
{
    public class Program
    {
        public static void Main()
        {
            var inputParams = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var skipCount = inputParams[0];
            var takeCount = inputParams[1];
            var input = Console.ReadLine();
            var pictures = Regex.Matches(input, $@"(?<=\|<.{{{skipCount}}})[^|]{{0,{takeCount}}}").Cast<Match>().Select(a => a.Value).ToArray();
            //var result = new List<string>();
            //foreach (var picture in pictures)
            //{
            //    var processedPicture = string.Empty;
            //    if (picture.Length > skipCount + takeCount)
            //    {
            //        processedPicture = picture.Substring(skipCount, takeCount);

            //    }
            //    else
            //    {
            //        processedPicture = picture.Substring(skipCount);
            //    }
            //    result.Add(processedPicture);
            //}
            Console.WriteLine(string.Join(", ", pictures));
        }
    }
}
