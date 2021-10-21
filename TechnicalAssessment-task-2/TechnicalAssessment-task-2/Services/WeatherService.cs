using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TechnicalAssessment_task_2.Services
{
    public class WeatherService
    {
        private static HttpClient _httpClient;
        
        public WeatherService()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "ACOSAS");
                _httpClient.BaseAddress = new Uri("https://api.met.no/weatherapi/locationforecast/2.0/");
            }

        }


        public string GetWeatherForecast(string location)
        {
            var coordinates = GetLocationCoordinates(location);

            var response = _httpClient.GetAsync($"compact?lat={coordinates.X}&lon={coordinates.Y}")
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult()
                .Content;

            var result = response
                .ReadAsStringAsync()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            return result;
        }


        private Coordinates GetLocationCoordinates(string locationName)
        {
            switch (locationName)
            {
                case "Bergen":
                    return new Coordinates(60.3913, 5.3221);
                case "Stavanger":
                    return new Coordinates(58.9700, 5.7331);
                case "Oslo":
                    return new Coordinates(59.9139, 10.7522);
                default:
                    throw new Exception();
            }


            
        }

    }


    public class Coordinates
    {
        public Coordinates(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; private set; }
        public double Y { get; private set; }
    }
}
