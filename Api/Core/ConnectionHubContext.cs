using Microsoft.EntityFrameworkCore;

namespace Api.Core;

public partial class ConnectionHubContext : DbContext
{
    public ConnectionHubContext(){}

      public ConnectionHubContext(DbContextOptions<ConnectionHubContext> options)
         : base(options)
         {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}