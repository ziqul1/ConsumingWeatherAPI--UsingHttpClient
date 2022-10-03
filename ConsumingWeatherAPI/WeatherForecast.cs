namespace ConsumingWeatherAPI
{
    public class WeatherForecast
    {
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string localTime { get; set; }
        public string lastUpdated { get; set; }
        public double tempCelsius { get; set; }
        public double tempFarenheit { get; set; }
        public string conditionText { get; set; }
        public double windMph { get; set; }
        public double windKph { get; set; }
        public double feelsLikeCelsius { get; set; }
        public double feelsLikeFarenheit { get; set; }
    }
}