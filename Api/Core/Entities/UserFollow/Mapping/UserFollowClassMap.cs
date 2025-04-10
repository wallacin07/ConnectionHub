using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class UserFollowClassMap : IEntityTypeConfiguration<UserFollow>
{
    public void Configure(EntityTypeBuilder<UserFollow> builder)
    {

        builder.ToTable("userFollow");
        builder
            .HasOne(_user => _user.Follower)
            .WithMany(_user => _user.Following)
            .HasForeignKey(_user => _user.FollowerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(_userFollow => _userFollow.Followee)
            .WithMany(_user => _user.Followers)
            .HasForeignKey(_userFollow => _userFollow.FolloweeId)
            .OnDelete(DeleteBehavior.NoAction);
            
    }
}
  