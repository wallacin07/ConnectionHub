using Api.Core.Errors.Login;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Core.Services;
public class LoginService(
    IUserRepository userRepository, PasswordHasher<User> hasher, JwtService jwtService
) : ILoginService
{

    private readonly IUserRepository _userRepository = userRepository;
    private readonly PasswordHasher<User> _hasher = hasher;
    
    private readonly JwtService _jwtService = jwtService;
    public Task ResetPassword(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<AppResponse<LoginResponse>> TryLogin(LoginPayload payload)
    {
        var user = await _userRepository.Get()
            .FirstOrDefaultAsync(u => u.Email == payload.Identification) 
            ??  throw new UserNotRegisteredException("Identification number not registered!");

        var passwordMatches = _hasher.VerifyHashedPassword(
            user,
            user.Password,
            payload.Password
        );

        if(passwordMatches == PasswordVerificationResult.Failed)
            throw new WrongPasswordException("Wrong password!");

        var userInfoDto = UserInfoDTO.Map(user);
        var token = _jwtService.GenerateToken(userInfoDto);

        return new AppResponse<LoginResponse>(
            new LoginResponse(false, UserDTO.Map(user), token),
            "User logged in successfully!"
        );
    }
}
