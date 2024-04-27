using System;
using System.Collections.Generic;

namespace _2704.Models
{
    public partial class WeatherForecast
    {
        public int Id { get; set; }
        public int? LocationId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? TemperatureC { get; set; }
        public decimal? TemperatureF { get; set; }
        public string? Weather { get; set; }
        public decimal? WindSpeed { get; set; }
        public decimal? Humidity { get; set; }

        public virtual Location? Location { get; set; }
    }
}
