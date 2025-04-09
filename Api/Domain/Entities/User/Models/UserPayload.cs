using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;
public class UserCreatePayload
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
    public string? PerfilPhoto { get; set; }
}

public class UserUpdatePayload
{
    public  string? Name { get; set; }
    public string? PerfilPhoto { get; set; }
}

