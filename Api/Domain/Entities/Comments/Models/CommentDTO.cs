namespace Api.Domain.Models;

public record CommentDTO(
    string Description,
    DateTime CreateAt,
    UserInfoCommentDTO User
){

    public static CommentDTO Map(Comment obj, User user){
        return new CommentDTO(
            obj.Descrição,
            obj.DataComentario,
            UserInfoCommentDTO.Map(user)
            );
    }
}

public record UserInfoCommentDTO(
    string Name,
    string? PerfilPhoto
){

    public static UserInfoCommentDTO Map(User obj){
        return new UserInfoCommentDTO(
            obj.Name,
            obj.PerfilPhoto
        );
    }
}