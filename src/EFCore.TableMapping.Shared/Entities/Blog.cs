namespace EFCore.TableMapping.Shared.Entities;

public class Blog
{
    public Guid Id { get; set; }
    public string Url { get; set; }

    protected Blog(Guid id, string url)
    {
        Id = id;
        Url = url;
    }

    public static Blog Create(string url)
    {
        return new Blog(Guid.NewGuid(), url);
    }
}
