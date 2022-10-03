namespace ConsumingWeatherAPI
{
    public class JsonData
    {
        public class Condition
        {
            public string text { get; set; }
        }

        public class Current
        {
            public string last_updated { get; set; }
            public double temp_c { get; set; }
            public double temp_f { get; set; }
            public double wind_mph { get; set; }
            public double wind_kph { get; set; }
            public double feelslike_c { get; set; }
            public double feelslike_f { get; set; }
            public Condition condition { get; set; }
        }

        public class Location
        {
            public string name { get; set; }
            public string region { get; set; }
            public string country { get; set; }
            public string localtime { get; set; }
        }

        public class ResponseBody
        {
            public Location location { get; set; }
            public Current current { get; set; }
        }
    }
}
