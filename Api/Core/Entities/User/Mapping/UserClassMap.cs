using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class UserClassMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(_user => _user.Id).HasName("PK____User");

        builder.ToTable("user");

        builder.Property(_user => _user.Name).HasColumnName("name");
        builder.Property(_user => _user.Email).HasColumnName("email");
        builder.Property(_user => _user.Password).HasColumnName("password");
        builder.Property(_user => _user.PerfilPhoto).HasColumnName("perfil_photo");

        builder.HasMany(_user => _user.Posts)
        .WithOne(_post => _post.Creator)
        .HasForeignKey("post_id")
        .OnDelete(DeleteBehavior.Cascade);
    }


}
