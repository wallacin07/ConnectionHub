using Api.Domain.Models;


namespace Api.Domain.Services;

public interface IUserService
{
    public Task<AppResponse<UserDTO>> CreateUser(UserCreatePayload payload);
    public Task DeleteUser(int Id);
    public Task UpdateUser(int Id, UserUpdatePayload payload);
}