using Api.Core.Mapping;
using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Core;

public partial class ConnectionHubContext : DbContext
{
    public ConnectionHubContext(){}

      public ConnectionHubContext(DbContextOptions<ConnectionHubContext> options)
         : base(options)
         {}

    public DbSet<User> UserList { get; set; }
    public DbSet<UserFollow> UserFollowList { get; set; }
    public DbSet<Post> PostList { get; set; }

    public DbSet<Comment> CommentList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserClassMap());
        modelBuilder.ApplyConfiguration(new UserFollowClassMap());
        modelBuilder.ApplyConfiguration(new PostClassMap());
        modelBuilder.ApplyConfiguration(new CommentClassMap());
    }
}