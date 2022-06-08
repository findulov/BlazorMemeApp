using MemeApp.Shared.Models;

namespace MemeApp.Blazor.Common.Services
{
    public interface IMemeApiService
    {
        Task<IEnumerable<MemeModel>?> GetAllMemesAsync();

        Task CreateMemeAsync(CreateMemeModel meme);
    }
}
