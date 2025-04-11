using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;
public class CommentCreatePayload
{
    [Required]
    public required string Description { get; set; }
    [Required]
    public required int UserId { get; set; }
    [Required]
    public required int PostId { get; set; }
    [Required]
    public required DateTime CommentDate { get; set; }
}

public class CommentUpdatePayload
{
    [Required]
    public required string Description { get; set; }
}

