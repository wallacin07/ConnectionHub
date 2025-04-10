using Genesis.Core.Repositories;
using Api.Domain.Repositories;
using Api.Domain.Models;

namespace Api.Core.Repositories;

public class UserFollowRepository(ConnectionHubContext context) 
    : BaseRepository<UserFollow>(context), IUserFollowRepository
{

}