using System;
using System.Collections.Generic;
using System.Text;

namespace RssReaderModel.Interfaces
{
    public interface IFeed
    {
        int Id { get; set; }
        string Title { get; set; }
        string Url { get; set; }

        IEnumerable<IArticle> GetArticles();
    }
}
