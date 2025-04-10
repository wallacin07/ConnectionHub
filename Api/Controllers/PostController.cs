using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("ConnectHub/api/post")]
public class PostController : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult> CreatePost(
        [FromServices] IPostService service, [FromBody] PostCreatePayload payload
    )
    {
        var result = await service.CreatePost(payload);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeletePost(
        [FromServices] IPostService service, int id
    )
    {
        await service.DeletePost(id);
        return Ok("Post deleted");
    }
}