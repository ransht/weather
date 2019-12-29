using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.WheatherInfo.Accuweather.Interface.Models;

namespace Weather.WheatherInfo.Interface
{
    public interface IAccWheatherLocationServices
    {
        Task<IEnumerable<AutocompleteCityResultsModel>> GetCitiesAutocomplete(string lang, string key);
    }
}