using ProjectFlow.Application.Interfaces;
using ProjectFlow.Application.Services;
using ProjectFlow.Domain.Interfaces;
using ProjectFlow.Infrastructure.Repositories;


namespace ProjectFlow.API.DependencyInjection
{
    public class Repository
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIssueRepository,IssueRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserProjectRepository, UserProjectRepository>();

        }
    }
}
