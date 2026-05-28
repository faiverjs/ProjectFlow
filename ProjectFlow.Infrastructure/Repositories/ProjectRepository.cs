using Microsoft.EntityFrameworkCore;
using ProjectFlow.Domain.Entities;
using ProjectFlow.Domain.Interfaces;
using ProjectFlow.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    
    {
        private readonly ProjectFlowContext _context;

        public ProjectRepository(ProjectFlowContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetProjectsByUserId(Guid userId)
        {
            return await _context.UserProjects
            .Where(up => up.UserId == userId)
            .Select(up => up.Project)
            .ToListAsync();
        }
    }
}
