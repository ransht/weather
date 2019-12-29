using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.Common.DTOs;
using Weather.WheatherInfo.Interface;
using Wheather.Dal.Interface;

namespace Weather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IFavoritesRepo _favoritesRepo;
        private readonly IAccWheatherServices _accWheatherServices;

        public WeatherController(IFavoritesRepo favoritesRepo, IAccWheatherServices accWheatherServices)
        {
            _favoritesRepo = favoritesRepo;
            _accWheatherServices = accWheatherServices;
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetAsync([FromRoute]string locationId,[FromQuery]string lang)
        {
            //Should build another layer of services - didnt have time for it, so i write some logic in controller
            var result = new WeatherResultsDTO();
            var fav = await _favoritesRepo.GetFavoriteAsync(locationId);
            if (fav == null)
            {
                var externalResult = await _accWheatherServices.GetWeatherResults(lang, locationId);
                result = new WeatherResultsDTO
                {
                    Temperature = externalResult.Temperature.Metric.Value,
                    WeatherText = externalResult.WeatherText
                };
            }
            else
            {
                result = new WeatherResultsDTO
                {
                    Temperature = fav.TempInCelsius,
                    WeatherText = fav.WeatherText
                };
            }

            return Ok(result);
        }
    }
}
