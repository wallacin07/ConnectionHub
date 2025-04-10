using Genesis.Domain.Models;

namespace Api.Domain.Models;

public class Comment : IEntity
{
    public string? Descrição { get; set; }
    public required User Creator { get; set; }
    public required Post Post{ get; set; }
    public required DateTime DataComentario { get; set; }
}

