using Api.Core.Errors;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Domain.Services;
using Genesis.Core.Repositories;
using Genesis.Core.Services;
using Microsoft.EntityFrameworkCore;

public class CommentService(BaseRepository<Comment> repository, IPostRepository postRepository, 
IUserRepository userRepository) : BaseService<Comment>(repository), ICommentService
{
    private readonly BaseRepository<Comment> _repo = repository;
    private readonly IPostRepository _postRepo = postRepository;
    private readonly IUserRepository _userRepo = userRepository;
    public async Task<AppResponse<CommentDTO>> CreateComment(CommentCreatePayload payload)
    {
        var User = await _userRepo.Get()
        .SingleOrDefaultAsync(_user => _user.Id == payload.UserId)
        ?? throw new NotFoundException("User not found!");

        var Post = await _postRepo.Get()
        .SingleOrDefaultAsync(_post => _post.Id == payload.PostId)
        ?? throw new NotFoundException("Post not found!");

        var newComment = new Comment(){
            Descrição = payload.Description,
            Creator = User,
            Post = Post,
            DataComentario = DateTime.Now
        };

        _repo.Add(newComment);

        await _repo.SaveAsync();
                return new AppResponse<CommentDTO>(
            CommentDTO.Map(newComment,User),
            "Comment created successfully!"
        );
    }

    public async Task DeleteComment(int Id)
    {
        var Comment = await _repo.Get()
            .SingleOrDefaultAsync(_comment => _comment.Id == Id)
         ?? throw new NotFoundException("Comment not found!");
         
         _repo.Remove(Comment);

         await _repo.SaveAsync();
    }

    public async Task<AppResponse<CommentDTO>> UpdateComment(int Id, CommentUpdatePayload payload)
    {
        var Comment = await _repo.Get()
          .Include(c => c.Creator)
            .SingleOrDefaultAsync(_comment => _comment.Id == Id)
         ?? throw new NotFoundException("Comment not found!");

         Comment.Descrição = payload.Description;

         var updateComment = _repo.Update(Comment);

        
        await _repo.SaveAsync();
        return new AppResponse<CommentDTO>(
            CommentDTO.Map(Comment, Comment.Creator),
            "Comment updated successfully!"
        );
    }
}
