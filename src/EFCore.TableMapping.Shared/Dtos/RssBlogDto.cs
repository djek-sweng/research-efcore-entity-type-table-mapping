namespace EFCore.TableMapping.Shared.Dtos;

public class RssBlogDto : BlogDto
{
    [Required]
    public string RssUrl { get; set; } = string.Empty;
}
