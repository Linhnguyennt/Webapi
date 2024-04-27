using _2704.Interfaces;
using _2704.Models;
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
        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
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


    }
}
