using MediatR;
using MemeApp.Infrastructure.Database;
using MemeApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MemeApp.Infrastructure.Queries
{
    public class GetAllMemesQueryHandler : IRequestHandler<GetAllMemesQuery, IEnumerable<MemeModel>>
    {
        private readonly MemeDbContext db;

        public GetAllMemesQueryHandler(MemeDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<MemeModel>> Handle(GetAllMemesQuery request, CancellationToken cancellationToken)
        {
            var memes = await db.Memes
                .OrderByDescending(x => x.CreatedTimestamp)
                .Select(x => new MemeModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    PostLink = x.PostLink,
                    Url = x.Url,
                    RedditPostLikes = x.RedditPostLikes,
                    IsNotSafeForWork = x.IsNotSafeForWork,
                    IsSpoiler = x.IsSpoiler,
                    PreviewLinks = x.PreviewLinks.Select(x => new MemePreviewLinkModel { Url = x.Url }).ToList()
                }).ToListAsync(cancellationToken);

            foreach (var meme in memes)
            {
                foreach (MemePreviewLinkModel previewLink in meme.PreviewLinks)
                {
                    Match match = Regex.Match(previewLink.Url, @"\width=(.*?)&");
                    if (match.Success)
                    {
                        string widthValue = match.Value.Replace("width=", string.Empty).Replace("&", string.Empty);
                        if (int.TryParse(widthValue, out int width))
                        {
                            previewLink.Width = width;
                        }
                    }
                }
            }

            return memes;
        }
    }

    public class GetAllMemesQuery : IRequest<IEnumerable<MemeModel>>
    {
    }
}
