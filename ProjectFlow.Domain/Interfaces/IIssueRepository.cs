using ProjectFlow.Application.Interfaces;
using ProjectFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Domain.Interfaces
{
    public interface IIssueRepository : IRepository<Issue>
    {
        Task<Issue?> GetById(Guid id);
        Task<IEnumerable<Issue>> GetAll();
        
    }
}
