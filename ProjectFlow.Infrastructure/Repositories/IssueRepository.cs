using Microsoft.EntityFrameworkCore;
using ProjectFlow.Domain.Entities;
using ProjectFlow.Domain.Interfaces;
using ProjectFlow.Infrastructure.Persistence;


namespace ProjectFlow.Infrastructure.Repositories
{
    public class IssueRepository : Repository<Issue> , IIssueRepository
    {
        private readonly ProjectFlowContext _context;

        public IssueRepository(ProjectFlowContext context) : base(context) 
        {
            _context = context;
        }

    }
}
