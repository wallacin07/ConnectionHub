using Genesis.Domain.Models;

namespace Api.Domain.Models;

public class User : IEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PerfilPhoto { get; set; }
    public ICollection<Post> Posts { get; set; } = [];
}

