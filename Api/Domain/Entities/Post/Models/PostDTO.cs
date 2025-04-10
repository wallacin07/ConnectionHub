using Api.Domain.Models;



public record PostDTO(
    string? Description,
    string? Img,
    int UserCreator_id,
    DateTime DatePosted
){
    public static PostDTO Map(Post obj)
    {
        return new PostDTO(
            obj.Descrição,
            obj.Img,
            obj.Creator.Id,
            obj.DataPostagem
        );
    }
}

