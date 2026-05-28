using Microsoft.EntityFrameworkCore;
using ProjectFlow.Domain.Entities;
using ProjectFlow.Domain.Interfaces;
using ProjectFlow.Infrastructure.Persistence;

namespace ProjectFlow.Infrastructure.Repositories
{
    public class CommentRepository : Repository<Comment> , ICommentRepository
    {
        private readonly ProjectFlowContext _context;

        public CommentRepository(ProjectFlowContext context) : base(context) 
        {
        }
    }
}