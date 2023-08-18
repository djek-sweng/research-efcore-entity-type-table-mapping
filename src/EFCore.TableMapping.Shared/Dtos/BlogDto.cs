namespace EFCore.TableMapping.Shared.Dtos;

public class BlogDto
{
    public int? Id { get; set; }

    [Required]
    public string Url { get; set; } = string.Empty;
}
