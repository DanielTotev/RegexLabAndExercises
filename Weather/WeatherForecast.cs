using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Weather
{
    public class City
    {
        public string Name { get; set; }
        public double Temperature { get; set; }
        public string Weather { get; set; }
    }

    public class WeatherForecast
    {
        public static void Main()
        {
            var regex = new Regex(@"(?<city>[A-Z]{2})(?<temperatures>\d+\.+\d+)(?<weather>[A-Za-z]+)\|");
            var cities = ReadCities(regex);
            PrintCities(cities);
        }

        public static void PrintCities(List<City> cities)
        {
            foreach (var city in cities.OrderBy(city => city.Temperature))
            {
                var name = city.Name;
                var temp = city.Temperature;
                var weatherType = city.Weather;
                Console.WriteLine($"{name} => {temp:f2} => {weatherType}");
            }
        }

        public static List<City> ReadCities(Regex regex)
        {
            var input = Console.ReadLine();
            var cities = new List<City>();
            while (input != "end")
            {
                if (!regex.IsMatch(input))
                {
                    input = Console.ReadLine();
                    continue;
                }
                var match = regex.Match(input);
                var cityName = match.Groups["city"].Value;
                var cityTemperatures = double.Parse(match.Groups["temperatures"].Value);
                var weather = match.Groups["weather"].Value;
                if (!cities.Any(c => c.Name == cityName))
                {
                    cities.Add(new City { Name = cityName, Temperature = cityTemperatures, Weather = weather });
                }
                else
                {
                    var duplicateCity = cities.Find(c => c.Name == cityName);
                    duplicateCity.Temperature = cityTemperatures;
                    duplicateCity.Weather = weather;
                }

                input = Console.ReadLine();
            }
            return cities;
        }
    }
}
