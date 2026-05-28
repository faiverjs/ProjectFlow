using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFlow.Domain.Entities;

namespace ProjectFlow.Infrastructure.Persistence
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("Issue");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.DateCreation)
                .IsRequired();

            builder.Property(x => x.DateUpdate)
                .IsRequired(false);

            builder.Property(x => x.DueDate)
                .IsRequired();

            // ================= PROJECT
            builder.HasOne(i => i.Project)
                .WithMany()
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            // ================= CREATOR
            builder.HasOne(i => i.Creator)
                .WithMany(u => u.CreatedIssues)   // 👈 agregar esto
                .HasForeignKey(i => i.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            // ================= ASSIGNED TO
            builder.HasOne(i => i.AssignedTo)
                .WithMany(u => u.AssignedIssues)  // 👈 agregar esto
                .HasForeignKey(i => i.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);

            // ================= STATE
            builder.HasOne(i => i.State)
                .WithMany(s => s.Issues)
                .HasForeignKey(i => i.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            // ================= PRIORITY
            builder.HasOne(i => i.Priority)
                .WithMany(p => p.Issues)
                .HasForeignKey(i => i.PriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            // ================= COMMENTS
            builder.HasMany(i => i.Comments)
                .WithOne(c => c.Issue)
                .HasForeignKey(c => c.IssueId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}