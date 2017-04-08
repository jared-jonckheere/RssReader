using Microsoft.EntityFrameworkCore;
using RssReaderModel.Interfaces;
using RssReaderModel.RssFeed.Interfaces;
using System.Collections.Generic;

namespace RssReaderModel.RssFeed
{
    public class RssFeedContext : DbContext, IRssFeedContext
    {
        public DbSet<RssFeed> Feeds { get; set; }
        public DbSet<RssArticle> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RssReader;Trusted_Connection=True;");
        }
    }


}