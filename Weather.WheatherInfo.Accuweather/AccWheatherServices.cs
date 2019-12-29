using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Weather.Common.Extentions;
using Weather.WheatherInfo.Accuweather.Interface.Models;
using Weather.WheatherInfo.Interface;

namespace Weather.WheatherInfo.Accuweather
{
    public class AccWheatherServices : IAccWheatherServices
    {
        //both Should have been in config and injected into this class (didnt have time)
        public static string GET_WEATHER_RESULTS_URL = "http://dataservice.accuweather.com/currentconditions/v1/{0}";
        public readonly string _apiKey = "eDbqD6ZJAkUvHANugEyT4aj2QgTy71d2";


        public async Task<WheatherResultsModel> GetWeatherResults(string lang, string locationId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var url = string.Format(GET_WEATHER_RESULTS_URL, locationId);
                var uriBuilder = new UriBuilder(url);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["apikey"] = _apiKey;
                query["language"] = lang;

                uriBuilder.Query = query.ToString();
                var fullUrl = uriBuilder.ToString();
                var result = await httpClient.GetObjectAsync<IEnumerable<WheatherResultsModel>>(fullUrl);
                return result?.FirstOrDefault();
            }
        }
    }
}
