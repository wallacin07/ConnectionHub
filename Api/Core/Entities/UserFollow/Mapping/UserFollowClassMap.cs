using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class UserFollowClassMap : IEntityTypeConfiguration<UserFollow>
{
    public void Configure(EntityTypeBuilder<UserFollow> builder)
    {
     builder
        .HasOne(uf => uf.Follower)
        .WithMany(u => u.Following)
        .HasForeignKey(uf => uf.FollowerId)
        .OnDelete(DeleteBehavior.Restrict);

    builder
        .HasOne(uf => uf.Followee)
        .WithMany(u => u.Followers)
        .HasForeignKey(uf => uf.FolloweeId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
