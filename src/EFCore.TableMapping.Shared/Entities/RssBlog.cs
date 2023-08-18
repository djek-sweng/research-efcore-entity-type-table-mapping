namespace EFCore.TableMapping.Shared.Entities;

public class RssBlog : Blog
{
    public string RssUrl { get; set; }

    private RssBlog(Guid id, string url, string rssUrl) : base(id, url)
    {
        RssUrl = rssUrl;
    }

    public static RssBlog Create(string url, string rssUrl)
    {
        return new RssBlog(Guid.NewGuid(), url, rssUrl);
    }
}
