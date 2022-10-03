using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static ConsumingWeatherAPI.JsonData;

namespace ConsumingWeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<WeatherForecast>> GetWeather(string City)
        {
            // here paste api key you received after account creation to external API
            string apiKey = "";

            var httpClientFactory = _httpClientFactory.CreateClient("ApiWeatherFloydMayWeather");

            var response = await httpClientFactory.GetAsync($"current.json?key={apiKey}&q={City}&aqi=no");

            if(response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var weatherDetails = await JsonSerializer.DeserializeAsync<ResponseBody>(responseStream);

                var weatherForecast = new WeatherForecast
                {
                    city = weatherDetails.location.name,
                    region = weatherDetails.location.region,
                    country = weatherDetails.location.country,
                    tempCelsius = weatherDetails.current.temp_c,
                    tempFarenheit = weatherDetails.current.temp_f,
                    conditionText = weatherDetails.current.condition.text,
                    windMph = weatherDetails.current.wind_mph,
                    windKph = weatherDetails.current.wind_kph,
                    feelsLikeCelsius = weatherDetails.current.feelslike_c,
                    feelsLikeFarenheit = weatherDetails.current.feelslike_f,
                    localTime = weatherDetails.location.localtime,
                    lastUpdated = weatherDetails.current.last_updated,
                };

                return Ok(weatherForecast);

               // return Ok(weatherDetails);
            }
            return BadRequest();
        }
    }
}