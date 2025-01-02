namespace juridical_api.Contracts
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> Get(Guid id);
        Task Create(T item);
        Task Update(Guid id, T item);
        Task Delete(Guid id);
        bool StatusDispose();
    }
}
