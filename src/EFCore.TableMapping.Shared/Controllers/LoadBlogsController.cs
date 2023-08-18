namespace EFCore.TableMapping.Shared.Controllers;

[ApiController]
[Route("api/blogs")]
public class LoadBlogsController : ControllerBase
{
    private readonly LoadBlogsUseCase _loadBlogsUseCase;

    public LoadBlogsController(LoadBlogsUseCase loadBlogsUseCase)
    {
        _loadBlogsUseCase = loadBlogsUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> ExecuteAsync(CancellationToken cancellationToken)
    {
        var blogs = await _loadBlogsUseCase.ExecuteAsync(cancellationToken);

        var response = blogs.Select(b => new { b.Id, b.Url }).ToList();

        return Ok(response);
    }
}
