using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Api
{
    [Route("api/trips")]
    public class TripsController : Controller
    {
        private IWorldRepository _repository;
        private ILogger<TripsController> _logger;

        public TripsController(IWorldRepository reposit,
            ILogger<TripsController> logger)
        {
            _repository = reposit;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllTrips();

                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get all trips: {ex}");
                return BadRequest(ex);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] TripViewModel theTrip)
        {
            if (ModelState.IsValid)
            {
                // save to database
                var newTrip = Mapper.Map<Trip>(theTrip);
                _repository.AddTrip(newTrip);

                if(await _repository.SaveChangeAsync())
                {
                    return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
                }
                else
                {
                    return BadRequest("Failed to save changes to the database");
                }

                // return Created($"api/trips/{theTrip.Name}", newTrip);
            }
            return BadRequest(ModelState);
        }
    }
}
