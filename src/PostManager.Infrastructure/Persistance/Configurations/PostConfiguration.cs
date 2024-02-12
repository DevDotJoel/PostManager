using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostManager.Domain.Aggregates.PostAggregate;
using PostManager.Domain.Aggregates.PostAggregate.ValueObjects;
using PostManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Infrastructure.Persistance.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).HasConversion(v=>v.Value,src => PostId.Create(src)).ValueGeneratedNever();
            builder.Property(x => x.UserId).HasConversion(v => v.Value, src => UserId.Create(src));
            ConfigurePostCommentIdsTable(builder);
        }
        private static void ConfigurePostCommentIdsTable(EntityTypeBuilder<Post> builder)
        {
            builder.OwnsMany(m => m.CommentIds, dib =>
            {
                dib.ToTable("PostCommentIds");

                dib.WithOwner().HasForeignKey("PostId");

                dib.HasKey("Id");

                dib.Property(d => d.Value)
                    .HasColumnName("CommentId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Post.CommentIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}
