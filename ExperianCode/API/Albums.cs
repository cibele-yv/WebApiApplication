using ExperianCode.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExperianCode.API
{
    public class Albums : IAlbums
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Albums(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Album>> Get()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://jsonplaceholder.typicode.com/albums");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            //TODO - Create a public method to handle to Http Errors such as BadRequest, Unavailable Service, etc
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync<IEnumerable<Album>>(contentStream);
            }
            else
            {
                return null;
            }

        }

    }
}
