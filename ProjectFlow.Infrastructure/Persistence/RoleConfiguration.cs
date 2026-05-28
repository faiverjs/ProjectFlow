using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFlow.Domain.Entities;


namespace ProjectFlow.Infrastructure.Persistence
{
    public class RoleConfiguration: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
            new Role(Guid.Parse("11111111-1111-1111-1111-111111111111"), "ADMIN"),
            new Role(Guid.Parse("22222222-2222-2222-2222-222222222222"), "PROJECT_MANAGER"),
            new Role(Guid.Parse("33333333-3333-3333-3333-333333333333"), "DEVELOPER"),
            new Role(Guid.Parse("44444444-4444-4444-4444-444444444444"), "TESTER"),
            new Role(Guid.Parse("55555555-5555-5555-5555-555555555555"), "REPORTER"),
            new Role(Guid.Parse("66666666-6666-6666-6666-666666666666"), "VIEWER")
            );
        }
    }
}
