using Genesis.Core.Repositories;
using Api.Domain.Repositories;
using Api.Domain.Models;

namespace Api.Core.Repositories;

public class CommentRepository(ConnectionHubContext context) 
    : BaseRepository<Comment>(context), ICommentRepository
{

}