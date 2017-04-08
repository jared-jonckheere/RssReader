using System;
using System.Collections.Generic;
using System.Text;

namespace RssReaderModel.Interfaces
{
    public interface IArticle
    {
        int Id { get; set; }
        string Title { get; set; }
        string Url { get; set; }
        string BodyHtml { get; set; }
    }
}
