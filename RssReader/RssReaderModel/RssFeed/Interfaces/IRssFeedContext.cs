using Microsoft.EntityFrameworkCore;
using RssReaderModel.RssFeed;

namespace RssReaderModel.RssFeed.Interfaces
{
    public interface IRssFeedContext
    {
        DbSet<RssFeed> Feeds { get; set; }
        DbSet<RssArticle> Articles { get; set; }
    }
}