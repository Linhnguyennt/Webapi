namespace _2704.Dto
{
    public class WeatherForecastDto
    {
        public int Id { get; set; }
        public int? LocationId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? TemperatureC { get; set; }
        public decimal? TemperatureF { get; set; }
        public string? Weather { get; set; }
        public decimal? WindSpeed { get; set; }
        public decimal? Humidity { get; set; }

    }
}
