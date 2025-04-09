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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserClassMap());
    }
}