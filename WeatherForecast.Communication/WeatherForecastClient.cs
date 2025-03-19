using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecast.Communication
{
    public class WeatherForecastClient
    {
        private readonly IConfiguration _configuration;

        public WeatherForecastClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<WeatherForecast>> GetWeatherForecast(HttpClient httpClient, string baseAddress = "https://localhost:7287", string path = "/WeatherForecast/GetWeatherForecast")
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, baseAddress + path);
            var response = await httpClient.SendAsync(message);
            var text = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(text.Result);
        }
    }
}
