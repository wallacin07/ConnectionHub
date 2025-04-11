using Api.Domain.Models;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("ConnectHub/api/comment")]
public class CommentController : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult> CreateComment(
        [FromServices] ICommentService service, [FromBody] CommentCreatePayload payload
    )
    {
        var result = await service.CreateComment(payload);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteComment(
        [FromServices] ICommentService service,int id
    )
    {
        await service.DeleteComment(id);
        return Ok("User Deleted");
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateComment(
        [FromServices] ICommentService service,[FromBody] CommentUpdatePayload payload, int id
    )
    {
        var Result = await service.UpdateComment(id, payload);
        return Ok(Result);
    }
}