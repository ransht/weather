using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.Common.DTOs;
using Weather.WheatherInfo.Interface;
using Wheather.Dal.Entities;
using Wheather.Dal.Interface;

namespace Weather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesRepo _favoritesRepo;
        private readonly IAccWheatherServices _accWheatherServices;

        public FavoritesController(IFavoritesRepo favoritesRepo, IAccWheatherServices accWheatherServices)
        {
            _favoritesRepo = favoritesRepo;
            _accWheatherServices = accWheatherServices;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddLocationAsync([FromBody] FavoriteInputDTO input, [FromQuery] string lang)
        {
            //validation if exists and error handling missing, didnt have time
            var externalResult = await _accWheatherServices.GetWeatherResults(lang, input.LocationId);
            var fav = new Favorite
            {
                WeatherText = externalResult.WeatherText,
                LocationId = input.LocationId,
                TempInCelsius = externalResult.Temperature.Metric.Value,
                 LocalizedName = input.LocalizedName
            };
            await _favoritesRepo.AddFavoriteAsync(fav);
            return Ok();
        }

        [HttpDelete("{locationId}")]
        public async Task<IActionResult> DeleteLocationAsync([FromRoute] string locationId)
        {
            await _favoritesRepo.DeleteFavoriteAsync(locationId);
            return Ok();
        }
    }
}
