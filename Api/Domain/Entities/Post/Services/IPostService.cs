using Api.Domain.Models;


namespace Api.Domain.Services;

public interface IPostService
{
    public Task<AppResponse<PostDTO>> CreatePost(PostCreatePayload payload);
    public Task DeletePost(int Id);
}