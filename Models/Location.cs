using System;
using System.Collections.Generic;

namespace _2704.Models
{
    public partial class Location
    {
        public Location()
        {
            SearchHistories = new HashSet<SearchHistory>();
            WeatherForecasts = new HashSet<WeatherForecast>();
        }

        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public virtual ICollection<SearchHistory> SearchHistories { get; set; }
        public virtual ICollection<WeatherForecast> WeatherForecasts { get; set; }
    }
}
