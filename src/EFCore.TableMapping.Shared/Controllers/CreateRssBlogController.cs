namespace EFCore.TableMapping.Shared.Controllers;

[ApiController]
[Route("api/rss-blogs")]
public class CreateRssBlogController : ControllerBase
{
    private readonly CreateRssBlogUseCase _createRssBlogUseCase;

    public CreateRssBlogController(CreateRssBlogUseCase createRssBlogUseCase)
    {
        _createRssBlogUseCase = createRssBlogUseCase;
    }

    [HttpPost("create")]
    public async Task<IActionResult> ExecuteAsync([FromBody] RssBlogDto blogDto, CancellationToken cancellationToken)
    {
        var blog = await _createRssBlogUseCase.ExecuteAsync(blogDto.Url, blogDto.RssUrl, cancellationToken);

        var response = new { blog.Id, blog.Url, blog.RssUrl };

        return CreatedAtRoute(null, response);
    }
}
