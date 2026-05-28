using ProjectFlow.Application.Interfaces;
using ProjectFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Domain.Interfaces
{
    public interface IUserProjectRepository : IRepository<UserProject>
    {
        Task<List<UserProject>> GetByProjectId(Guid projectId);
    }
}
