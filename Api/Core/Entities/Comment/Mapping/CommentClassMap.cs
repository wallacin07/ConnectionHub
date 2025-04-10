using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Core.Mapping;

public class CommentClassMap : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(_comment => _comment.Id).HasName("PK____Comment");

        builder.ToTable("comment");

        builder.Property(_comment => _comment.Descrição).HasColumnName("description");
        builder.Property(_comment => _comment.DataComentario).HasColumnName("comment_date");

        builder.HasOne(_comment => _comment.Creator)
        .WithMany(_user => _user.Comments)
        .HasForeignKey("user_id")
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(_comment => _comment.Post)
        .WithMany(_post => _post.Comments)
        .HasForeignKey("post_id")
        .OnDelete(DeleteBehavior.Cascade);
    }


}
