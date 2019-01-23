using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CaveBase.MVC.Helpers
{
    public static class WebApiHelper
    {
        public const string baseUrl = "https://localhost:5001/api/caves";
        public const string apiUrl = "https://localhost:44334/api/";

        public static T GetApiResult<T>(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(url);

                //Generic T represents the object ((List of) Cave, Caver, Club, ...) we want to send back
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response.Result)).Result;
            }
        }

        private static async Task<ApiDelivery> CallApi<ApiDelivery, Receive>(string url, Receive entity, HttpMethod method)
        {
            ApiDelivery result = default(ApiDelivery);

            using(HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response;

                if(method == HttpMethod.Post) { response = await httpClient.PostAsJsonAsync(url, entity); }
                else if(method == HttpMethod.Put) { response = await httpClient.PutAsJsonAsync(url, entity); }
                else { response = await httpClient.DeleteAsync(url); }

                result = await response.Content.ReadAsAsync<ApiDelivery>();
            }
            return result;
        }

        public static async Task<ApiDelivery> PutCallApi<ApiDelivery, Receive>(string url, Receive entity)
        {
            return await CallApi<ApiDelivery, Receive>(url, entity, HttpMethod.Put);
        }

        public static async Task<ApiDelivery> PostCallApi<ApiDelivery, Receive>(string url, Receive entity)
        {
            return await CallApi<ApiDelivery, Receive>(url, entity, HttpMethod.Post);
        }

        public static async Task<ApiDelivery> DeleteCallApi<ApiDelivery>(string url)
        {
            return await CallApi<ApiDelivery, object>(url, null, HttpMethod.Delete);
        }
    }
}
