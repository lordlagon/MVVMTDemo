using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestClient
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

        public async Task<ObservableCollection<T>> Get()
        {
            var result = new ObservableCollection<T>();

            Http.DefaultRequestHeaders.Accept.Clear();
            Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await Http.GetAsync(BaseUrl).ConfigureAwait(false);
            Debug.Write(response);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!string.IsNullOrEmpty(json))
                {
                    return await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
                    }).ConfigureAwait(false);
                }
            }
            return result;
        }
        public async Task<ObservableCollection<T>> Get(string resource)
        {
            var result = new ObservableCollection<T>();

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
                        return JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
                    }).ConfigureAwait(false);
                }
            }
            return result;
        }
        public async Task<T> Post(string path, object obj)
        {

            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var response = await Http.PostAsync(FromUrl(BaseUrl, path), content).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var res = JsonConvert.DeserializeObject<T>(json);
                return res;
            }
            else
            {
                return null;
            }
        }

        protected string FromUrl(string baseUrl, string resource)
        {
            return string.Join("", baseUrl, resource);
        }

    }
}
