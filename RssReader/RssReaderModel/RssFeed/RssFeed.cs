using RssReaderModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RssReaderModel.RssFeed
{
    public class RssFeed : IFeed
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Url { get; set; }
        public List<RssArticle> Articles { get; set; }
        public IEnumerable<IArticle> GetArticles() { return Articles; }
    }
}
