using Genesis.Domain.Models;
namespace Api.Domain.Models;
public class UserFollow : IEntity
{
    public int FollowerId { get; set; }
    public required User Follower { get; set; }

    public int FolloweeId { get; set; }
    public required User Followee { get; set; }
}
