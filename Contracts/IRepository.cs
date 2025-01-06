namespace juridical_api.Contracts
{
    public interface IRepository<T, F> : IDisposable where T : class
        where F : class
    {
        List<F> GetAll();
        F? Get(Guid id);
        void Create(T item);
        void Update(Guid id, T item);
        void Delete(Guid id);
        bool StatusDispose();
    }
}
