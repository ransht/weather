using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Weather.Common.Extentions
{
    public static class HttpClientExtentions
    {
        public static async Task<T> GetObjectAsync<T>(this HttpClient httpClient, string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var str = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(str);
            return result;
        }
    }
}
