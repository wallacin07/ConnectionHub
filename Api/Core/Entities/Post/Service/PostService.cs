using Api.Core.Errors;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Domain.Services;
using Genesis.Core.Repositories;
using Genesis.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Core.Services;

public class PostService(BaseRepository<Post> repository, IUserRepository userRepository
 ) : BaseService<Post>(repository), IPostService
{
    private readonly BaseRepository<Post> _repo = repository;
    private readonly IUserRepository _userRepo = userRepository;

    public async Task<AppResponse<PostDTO>> CreatePost(PostCreatePayload payload)
    {

        var User = await _userRepo.Get()
        .SingleOrDefaultAsync(_user => _user.Id == payload.UserId)
        ?? throw new NotFoundException("User not found!");

        var newPost = new Post(){
            Descrição = payload.Description,
            Img = payload.Img,
            Creator = User,
            DataPostagem = DateTime.Now
        };

        _repo.Add(newPost);

        await _repo.SaveAsync();
                return new AppResponse<PostDTO>(
            PostDTO.Map(newPost),
            "Post created successfully!"
        );
    }

      public async Task DeletePost(int Id)
    {
        var Post = await _repo.Get()
            .SingleOrDefaultAsync(_post => _post.Id == Id)
         ?? throw new NotFoundException("Post not found!");
         
         _repo.Remove(Post);

         await _repo.SaveAsync();
    }

    
}
