using ExperianCode.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExperianCode.API
{
    public class Photos: IPhotos
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Photos(IHttpClientFactory httpClientFactory)
        { 
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Photo>> Get()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://jsonplaceholder.typicode.com/photos");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            //TODO - Create a public method to handle to Http Errors such as BadRequest, Unavailable Service, etc
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync<IEnumerable<Photo>>(contentStream);
            }
            else
            {
                return null;
            }

        }

    }
}
