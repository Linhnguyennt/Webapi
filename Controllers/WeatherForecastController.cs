using _2704.Dto;
using _2704.Interfaces;
using _2704.Models;
using _2704.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _2704.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastRepository _weatherforecastRepository;
        private readonly IMapper _mapper;
        public WeatherForecastController(IWeatherForecastRepository weatherforecastRepository, IMapper mapper)
        {
            _weatherforecastRepository = weatherforecastRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WeatherForecast>))]

        public IActionResult GetWeatherForecasts()
        {
            var locations = _mapper.Map < List < WeatherForecastDto >>(_weatherforecastRepository.GetWeatherForecasts());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(locations);
        }


        //[HttpGet("{id}")]
        //[Microsoft.AspNetCore.Mvc.Route("GetLocationById/{id}")]
        //public bool GetLocationById(int id)
        //{
        //    var location = _locationRepository.GetLocationById(id);
        //    if (location != null)
        //    {

        //        return true;
        //    }
        //    return false;
        //}

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult GetWeatherForecast(int id)
        {
            if (!_weatherforecastRepository.WeatherForecastExists(id))
                return NotFound();

            var location = _mapper.Map<List<WeatherForecastDto>>(_weatherforecastRepository.GetWeatherForecast(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(location);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromQuery] int locationId, [FromBody] WeatherForecastDto weatherCreate)
        {
            if (weatherCreate == null)
                return BadRequest(ModelState);

            var category = _weatherforecastRepository.GetWeatherForecasts()
                .Where(c => c.Weather.Trim().ToUpper() == weatherCreate.Weather.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<WeatherForecast>(weatherCreate);

            if (!_weatherforecastRepository.CreateWeatherForecast(locationId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{weatherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateWeather(int weatherId,
        
         [FromBody] WeatherForecastDto updatedweather)
        {
            if (updatedweather == null)
                return BadRequest(ModelState);

            if (weatherId != updatedweather.Id)
                return BadRequest(ModelState);

            if (!_weatherforecastRepository.WeatherForecastExists(weatherId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var pokemonMap = _mapper.Map<WeatherForecast>(updatedweather);

            if (!_weatherforecastRepository.UpdateWeatherForecast(weatherId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return Ok("Updated successfully");
        }
    }

}
