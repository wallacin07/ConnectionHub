using Api.Core.Errors;
using Api.Domain.Models;
using Api.Domain.Services;
using Genesis.Core.Repositories;
using Genesis.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Core.Services;

public class UserService(BaseRepository<User> repository,
   PasswordHasher<User> hasher ) : BaseService<User>(repository), IUserService
{

    private readonly PasswordHasher<User> _hasher = hasher;
    private readonly BaseRepository<User> _repo = repository;
    public async Task<AppResponse<UserDTO>> CreateUser(UserCreatePayload payload)
    {
        var newUser = new User(){
            Name= payload.Name,
            Email = payload.Email,
            Password = payload.Password,
            PerfilPhoto = payload.PerfilPhoto
        };

        newUser.Password = _hasher.HashPassword(newUser, newUser.Password);

        var createdUser = _repo.Add(newUser)
            ?? throw new UpsertFailException("Event could not be inserted!");


        await _repo.SaveAsync();
        return new AppResponse<UserDTO>(
            UserDTO.Map(newUser),
            "User created successfully!"
        );
    }

    public async Task DeleteUser(int Id)
    {
            var User = await _repo.Get()
            .SingleOrDefaultAsync(_user => _user.Id == Id)
         ?? throw new NotFoundException("User not found!");
         
         _repo.Remove(User);

         await _repo.SaveAsync();
    }

    public async Task<AppResponse<UserDTO>> UpdateUser(int Id, UserUpdatePayload payload)
    {
        var User = await _repo.Get()
            .SingleOrDefaultAsync(_user => _user.Id == Id)
         ?? throw new NotFoundException("User not found!");

         User.Name = payload.Name ?? User.Name;
         User.PerfilPhoto = payload.PerfilPhoto ?? User.PerfilPhoto;

         var updateUser = _repo.Update(User);
        
        await _repo.SaveAsync();
        return new AppResponse<UserDTO>(
            UserDTO.Map(User),
            "User updated successfully!"
        );
    }
}
