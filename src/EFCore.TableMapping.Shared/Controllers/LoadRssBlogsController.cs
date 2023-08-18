namespace EFCore.TableMapping.Shared.Controllers;

[ApiController]
[Route("api/rss-blogs")]
public class LoadRssBlogsController : ControllerBase
{
    private readonly LoadRssBlogsUseCase _loadRssBlogsUseCase;

    public LoadRssBlogsController(LoadRssBlogsUseCase loadRssBlogsUseCase)
    {
        _loadRssBlogsUseCase = loadRssBlogsUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> ExecuteAsync(CancellationToken cancellationToken)
    {
        var blogs = await _loadRssBlogsUseCase.ExecuteAsync(cancellationToken);

        var response = blogs.Select(b => new { b.Id, b.Url, b.RssUrl }).ToList();

        return Ok(response);
    }
}
