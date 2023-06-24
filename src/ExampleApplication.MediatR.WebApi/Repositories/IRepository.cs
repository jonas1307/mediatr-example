namespace ExampleApplication.MediatR.WebApi.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(Guid id);
        Task Insert(T item);
        Task Update(T item);
        Task Delete(Guid id);
    }
}
