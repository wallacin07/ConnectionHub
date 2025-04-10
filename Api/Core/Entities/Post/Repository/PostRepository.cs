using Genesis.Core.Repositories;
using Api.Domain.Repositories;
using Api.Domain.Models;

namespace Api.Core.Repositories;

public class PostRepository(ConnectionHubContext context) 
    : BaseRepository<Post>(context), IPostRepository
{

}