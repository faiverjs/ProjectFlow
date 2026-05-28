using Microsoft.EntityFrameworkCore;
using ProjectFlow.Application.Interfaces;
using ProjectFlow.Domain.Entities;
using ProjectFlow.Infrastructure.Persistence;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    
{
    protected readonly ProjectFlowContext _context;

    protected Repository(ProjectFlowContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TEntity>> GetAll()
        => await _context.Set<TEntity>().ToListAsync();

    public async Task<TEntity?> GetById(Guid id)
        => await _context.Set<TEntity>().FindAsync(id);

    public async Task Add(TEntity entity)
        => await _context.Set<TEntity>().AddAsync(entity);


    public Task Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task SaveChanges()
        => await _context.SaveChangesAsync();

    public async Task<TEntity?> upDate(TEntity entity)
    {
        
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
} 