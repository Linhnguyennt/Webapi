using _2704.Dto;
using _2704.Interfaces;
using _2704.Models;
using _2704.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2704.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public LocationController(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Location>))]

        public IActionResult GetLocation()
        {
            var locations = _locationRepository.GetLocations();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(locations); }


      

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult GetLocation(int id)
        {
            if (!_locationRepository.LocationExists(id))
                return NotFound();

            var location = _locationRepository.GetLocationById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(location);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLocation([FromBody] LocationDto locationCreate)
        {
            if (locationCreate == null)
                return BadRequest(ModelState);

            var category = _locationRepository.GetLocations()
                .Where(c => c.City.Trim().ToUpper() == locationCreate.City.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var locationMap = _mapper.Map<Location>(locationCreate);

            if (!_locationRepository.CreateLocation(locationMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{LocationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRole(int LocationId, [FromBody] LocationDto updatedLocation)
        {
            if (updatedLocation == null)
                return BadRequest(ModelState);

            if (LocationId != updatedLocation.Id)
                return BadRequest(ModelState);

            if (!_locationRepository.LocationExists(LocationId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var roleMap = _mapper.Map<Location>(updatedLocation);

            if (!_locationRepository.UpdateLocation(roleMap))
            {
                ModelState.AddModelError("", "Something went wrong updating role");
                return StatusCode(500, ModelState);
            }

            return Ok("Update successfully");
        }
    }
}
