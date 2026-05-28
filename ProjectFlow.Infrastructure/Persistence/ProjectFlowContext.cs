using Microsoft.EntityFrameworkCore;
using ProjectFlow.Domain.Entities;

namespace ProjectFlow.Infrastructure.Persistence
{
    public class ProjectFlowContext : DbContext
    {
        public ProjectFlowContext(DbContextOptions<ProjectFlowContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Issue> Issues => Set<Issue>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<State> TaskStates => Set<State>();
        public DbSet<Priority> TaskPriorities => Set<Priority>();
        public DbSet<UserProject> UserProjects => Set<UserProject>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectFlowContext).Assembly);
            /*// USER - ROLE
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

            // PROJECT - LEADER (FALTABA)
            modelBuilder.Entity<Project>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.LeaderId)
                .OnDelete(DeleteBehavior.Restrict);

            // USERPROJECT (N:N)
            modelBuilder.Entity<UserProject>()
                .HasKey(up => new { up.UserId, up.ProjectId });

            modelBuilder.Entity<UserProject>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProjects)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProject>()
                .HasOne(up => up.Project)
                .WithMany(p => p.UserProjects)
                .HasForeignKey(up => up.ProjectId);

            

            // ISSUE - COMMENT
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Issue)
                .WithMany()
                .HasForeignKey(c => c.IssueId);

            

            // ISSUE - STATE
            modelBuilder.Entity<Issue>()
                .HasOne<State>()
                .WithMany()
                .HasForeignKey(i => i.StateId);

            // ISSUE - PRIORITY
            modelBuilder.Entity<Issue>()
                .HasOne<Priority>()
                .WithMany()
                .HasForeignKey(i => i.PriorityId);*/
        }
    }
}