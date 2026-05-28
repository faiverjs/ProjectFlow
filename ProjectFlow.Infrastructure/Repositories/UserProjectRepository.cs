using Microsoft.EntityFrameworkCore;
using ProjectFlow.Domain.Entities;
using ProjectFlow.Domain.Interfaces; // ← esta línea faltaba
using ProjectFlow.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Infrastructure.Repositories
{
    public class UserProjectRepository : Repository<UserProject>, IUserProjectRepository
    {
        public UserProjectRepository(ProjectFlowContext context) : base(context)
        {
        }

        public async Task<List<UserProject>> GetByProjectId(Guid projectId)
        {
            return await _context.UserProjects
                .Where(up => up.ProjectId == projectId)
                .ToListAsync();
        }
    }
}