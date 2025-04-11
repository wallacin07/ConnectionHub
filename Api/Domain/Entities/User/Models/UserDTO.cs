namespace Api.Domain.Models;

public record UserDTO(
    string Username,
    string Password,
    string? PerfilPhoto
){
    public static UserDTO Map(User obj)
    {
        return new UserDTO(
            obj.Name,
            obj.Password,
            obj.PerfilPhoto
        );
    }
}

public record UserInfoDTO(
    int Id,
    string Name
){
    public static UserInfoDTO Map(User obj)
    {
        return new UserInfoDTO(
            obj.Id,
            obj.Name
        );
    }
}