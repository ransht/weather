using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.WheatherInfo.Interface;

namespace Weather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IAccWheatherLocationServices _accWheatherLocationServices;

        public LocationController(IAccWheatherLocationServices accWheatherLocationServices)
        {
            _accWheatherLocationServices = accWheatherLocationServices;
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCitiesAsync([FromQuery] string lang, [FromQuery] string key)
        {
            
            var result = await _accWheatherLocationServices.GetCitiesAutocomplete(lang, key);
            return Ok(result);
        }
    }
}
