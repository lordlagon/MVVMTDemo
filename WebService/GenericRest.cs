using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MockedWebService
{
    public class GenericRest<T> where T : class
    {
        protected string BaseUrl { get; set; }
        protected HttpClient Http { get; set; }
        public GenericRest(string baseUrl, HttpClient http)
        {
            BaseUrl = baseUrl;
            Http = http;
        }

        public async Task<T> GetOne(string resource)
        {
            Http.DefaultRequestHeaders.Accept.Clear();
            Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await Http.GetAsync(FromUrl(BaseUrl, resource)).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!string.IsNullOrEmpty(json))
                {
                    return await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<T>(json);
                    }).ConfigureAwait(false);
                }
            }
            return null;
        }

        public async Task<IEnumerable<T>> Get()
        {
            var result = Enumerable.Empty<T>();

            Http.DefaultRequestHeaders.Accept.Clear();
            Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await Http.GetAsync(BaseUrl).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!string.IsNullOrEmpty(json))
                {
                    return await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                    }).ConfigureAwait(false);
                }
            }
            return result;
        }

        protected string FromUrl(string baseUrl, string resource)
        {
            return string.Join("", baseUrl, resource);
        }

    }
}
