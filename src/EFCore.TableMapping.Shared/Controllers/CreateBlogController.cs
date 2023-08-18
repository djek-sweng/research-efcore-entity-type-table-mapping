namespace EFCore.TableMapping.Shared.Controllers;

[ApiController]
[Route("api/blogs")]
public class CreateBlogController : ControllerBase
{
    private readonly CreateBlogUseCase _createBlogUseCase;

    public CreateBlogController(CreateBlogUseCase createBlogUseCase)
    {
        _createBlogUseCase = createBlogUseCase;
    }

    [HttpPost("create")]
    public async Task<IActionResult> ExecuteAsync([FromBody] BlogDto blogDto, CancellationToken cancellationToken)
    {
        var blog = await _createBlogUseCase.ExecuteAsync(blogDto.Url, cancellationToken);

        var response = new { blog.Id, blog.Url };

        return CreatedAtRoute(null, response);
    }
}
