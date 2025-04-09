using Api.Domain.Models;


namespace Api.Domain.Services;

public interface IUserService
{
    public Task<AppResponse<UserDTO>> CreateUser(UserCreatePayload payload);
    public Task DeleteUser(int Id);
    public Task<AppResponse<UserDTO>> UpdateUser(int Id, UserUpdatePayload payload);
}