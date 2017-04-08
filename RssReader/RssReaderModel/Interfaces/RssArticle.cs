using RssReaderModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RssReaderModel.RssFeed
{
    public class RssArticle : IArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string BodyHtml { get; set; }
    }
}
