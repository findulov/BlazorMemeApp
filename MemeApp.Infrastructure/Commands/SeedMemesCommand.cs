using MediatR;
using MemeApp.Domain.Entities;
using MemeApp.Domain.Models;
using MemeApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MemeApp.Infrastructure.Commands
{
    public class SeedMemesCommandHandler : AsyncRequestHandler<SeedMemesCommand>
    {
        private readonly MemeDbContext db;

        public SeedMemesCommandHandler(MemeDbContext db)
        {
            this.db = db;
        }

        protected override async Task Handle(SeedMemesCommand request, CancellationToken cancellationToken)
        {
            using HttpClient httpClient = new();

            var response = await httpClient.GetAsync(
                $"https://meme-api.herokuapp.com/gimme/{request.NumberOfMemesToSeed}", 
                cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Unable to fetch memes from API");
            }

            string memesJsonResponse = await response.Content.ReadAsStringAsync(cancellationToken);
            MemesApiResponseModel? memesApiResponse = JsonSerializer.Deserialize<MemesApiResponseModel?>(memesJsonResponse);

            if (memesJsonResponse == null)
            {
                throw new Exception("Invalid API response");
            }

            List<Meme>? existingDbMemes = await db.Memes.ToListAsync(cancellationToken: cancellationToken);

            foreach (MemeApiResponseModel meme in memesApiResponse.Memes)
            {
                if (!existingDbMemes.Any(x => x.Title == meme.Title && x.Url == meme.Url))
                {
                    Meme memeEntity = meme.ToEntity();
                    db.Memes.Add(memeEntity);
                }
            }

            await db.SaveChangesAsync(cancellationToken);
        }
    }

    public class SeedMemesCommand : IRequest
    {
        public SeedMemesCommand(int numberOfMemesToSeed)
        {
            NumberOfMemesToSeed = numberOfMemesToSeed;
        }

        public int NumberOfMemesToSeed { get; }
    }
}
