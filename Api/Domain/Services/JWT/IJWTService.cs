using Api.Domain.Models;

namespace Api.Domain.Services;
public interface IJwtService
{
    public OutboundToken GenerateToken(UserInfoDTO user);
    public void ValidateToken(string jwt);
}