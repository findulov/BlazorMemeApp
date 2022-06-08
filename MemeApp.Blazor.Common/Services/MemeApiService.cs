using MemeApp.Shared.Models;
using System.Text.Json;

namespace MemeApp.Blazor.Common.Services
{
    public class MemeApiService : IMemeApiService
    {
        private readonly HttpClient httpClient;

        public MemeApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<MemeModel>?> GetAllMemesAsync()
        {
            HttpResponseMessage memesHttpResponse = await httpClient.GetAsync($"{Constants.ApiBaseUrl}/memes/all");

            if (!memesHttpResponse.IsSuccessStatusCode)
            {
                return null;
            }

            string memesJsonResponse = await memesHttpResponse.Content.ReadAsStringAsync();
            IEnumerable<MemeModel>? memes = JsonSerializer.Deserialize<IEnumerable<MemeModel>?>(memesJsonResponse);

            return memes;
        }

        public async Task CreateMemeAsync(CreateMemeModel meme)
        {
            var httpResponse = await httpClient.PostAsync(
                $"{Constants.ApiBaseUrl}/memes/create",
                new StringContent(JsonSerializer.Serialize(meme)));

            // TODO: do something with the response
        }
    }
}
