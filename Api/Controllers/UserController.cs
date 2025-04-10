using Api.Domain.Models;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("ConnectHub/api/user")]
public class UserController : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult> CreateUser(
        [FromServices] IUserService service, [FromBody] UserCreatePayload payload
    )
    {
        var result = await service.CreateUser(payload);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteUser(
        [FromServices] IUserService service,int id
    )
    {
        await service.DeleteUser(id);
        return Ok("User Deleted");
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateUser(
        [FromServices] IUserService service,[FromBody] UserUpdatePayload payload, int id
    )
    {
        var Result = await service.UpdateUser(id, payload);
        return Ok(Result);
    }
}