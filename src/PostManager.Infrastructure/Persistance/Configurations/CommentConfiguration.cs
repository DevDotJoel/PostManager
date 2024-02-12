using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostManager.Domain.Aggregates.CommentAggregate;
using PostManager.Domain.Aggregates.CommentAggregate.ValueObjects;
using PostManager.Domain.Aggregates.PostAggregate.ValueObjects;
using PostManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Infrastructure.Persistance.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(v => v.Value, src => CommentId.Create(src)).ValueGeneratedNever();
            builder.Property(x => x.PostId).HasConversion(v => v.Value, src => PostId.Create(src));
            builder.Property(x => x.UserId).HasConversion(v => v.Value, src => UserId.Create(src));
        }
    }
}
