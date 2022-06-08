using MediatR;
using MemeApp.Domain.Entities;
using MemeApp.Infrastructure.Database;
using MemeApp.Shared.Models;

namespace MemeApp.Infrastructure.Commands
{
    public class CreateMemeCommandHandler : AsyncRequestHandler<CreateMemeCommand>
    {
        private readonly MemeDbContext db;

        public CreateMemeCommandHandler(MemeDbContext db)
        {
            this.db = db;
        }

        protected override async Task Handle(CreateMemeCommand request, CancellationToken cancellationToken)
        {
            db.Memes.Add(new Meme(request.Meme.Title, null, request.Meme.Url, request.Meme.Author, request.Meme.IsNotSafeForWork,
                new List<MemePreviewLink>
                {
                    new MemePreviewLink(request.Meme.Url)
                }));

            await db.SaveChangesAsync(cancellationToken);
        }
    }

    public class CreateMemeCommand : IRequest
    {
        public CreateMemeCommand(CreateMemeModel meme)
        {
            Meme = meme;
        }

        public CreateMemeModel Meme { get; }
    }
}
