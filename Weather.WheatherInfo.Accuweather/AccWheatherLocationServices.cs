using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Weather.Common.Extentions;
using Weather.WheatherInfo.Accuweather.Interface.Models;
using Weather.WheatherInfo.Interface;

namespace Weather.WheatherInfo.Accuweather
{
    public class AccWheatherLocationServices : IAccWheatherLocationServices
    {
        //both Should have been in config and injected into this class (didnt have time)
        public static string GET_LOCATIONS_URL = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete";
        public readonly string _apiKey = "eDbqD6ZJAkUvHANugEyT4aj2QgTy71d2";

        public async Task<IEnumerable<AutocompleteCityResultsModel>> GetCitiesAutocomplete(string lang, string key)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uriBuilder = new UriBuilder(GET_LOCATIONS_URL);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);

                query["apikey"] = _apiKey;
                query["q"] = key;
                query["language"] = lang;

                uriBuilder.Query = query.ToString();
                var fullUrl = uriBuilder.ToString();
                var result = await httpClient.GetObjectAsync<IEnumerable<AutocompleteCityResultsModel>>(fullUrl);
                return result;
            }
        }
    }
}
