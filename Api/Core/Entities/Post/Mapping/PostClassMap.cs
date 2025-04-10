using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class PostClassMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(_post => _post.Id).HasName("PK____Post");

        builder.ToTable("post");

        builder.Property(_post => _post.Descrição).HasColumnName("description");
        builder.Property(_post => _post.DataPostagem).HasColumnName("post_date");
        builder.Property(_post => _post.Img).HasColumnName("image");

        builder.HasOne(_post => _post.Creator)
        .WithMany(_user => _user.Posts)
        .HasForeignKey("user_id")
        .OnDelete(DeleteBehavior.Cascade);
    }


}
