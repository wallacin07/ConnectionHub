using System.ComponentModel.DataAnnotations;

public class PostCreatePayload
{
    [Required]
    public string? Img { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public required int UserId { get; set; }
    [Required]
    public required DateTime PostDate { get; set; }
}