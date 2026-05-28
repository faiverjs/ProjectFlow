using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Infrastructure.Persistence
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.HasKey(c => c.Id);

            builder.Property(x => x.Description)
                .HasMaxLength(500)      // ❗ NO required (en SQL es NULL)
                .IsRequired(false);

            builder.Property(x => x.DateCreation)
                .IsRequired();

            builder.Property(x => x.DateUpdate)
                .IsRequired(false);

            builder.HasOne(c => c.Issue)
            .WithMany(i => i.Comments)
            .HasForeignKey(x => x.IssueId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
