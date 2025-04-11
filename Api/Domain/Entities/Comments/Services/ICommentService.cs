using Api.Domain.Models;


namespace Api.Domain.Services;

public interface ICommentService
{
    public Task<AppResponse<CommentDTO>> CreateComment(CommentCreatePayload payload);
    public Task DeleteComment(int Id);
    public Task<AppResponse<CommentDTO>> UpdateComment(int Id, CommentUpdatePayload payload);
}