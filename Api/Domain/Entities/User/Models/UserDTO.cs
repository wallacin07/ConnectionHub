using Api.Domain.Models;



public record UserDTO(
    string PerfilPhoto,
    string Username,
    string Password
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