using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.WheatherInfo.Accuweather.Interface.Models;

namespace Weather.WheatherInfo.Interface
{
    public interface IAccWheatherServices
    {
        Task<WheatherResultsModel> GetWeatherResults(string lang, string locationId);
    }
}