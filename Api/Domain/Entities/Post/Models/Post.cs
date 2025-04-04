using Genesis.Domain.Models;

namespace Api.Domain.Models;

public class Post : IEntity
{
    public string? Descrição { get; set; }
    public string? Img { get; set; }
    public required DateTime DataPostagem { get; set; }
    public required User Creator { get; set; }
}

