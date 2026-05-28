
using Microsoft.EntityFrameworkCore;
using ProjectFlow.Application.Interfaces;
using ProjectFlow.Domain.Entities;
using ProjectFlow.Domain.Interfaces;
using ProjectFlow.Infrastructure.Persistence;


public class UserRepository : Repository<User> , IUserRepository
{
    public UserRepository(ProjectFlowContext context) : base(context)
    {
    }
     public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}