namespace ProjectFlow.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(Guid id);
        Task Add(TEntity entity);

        Task<TEntity?> upDate(TEntity entity);
        Task Delete(TEntity entity);
        Task SaveChanges();
    }
}