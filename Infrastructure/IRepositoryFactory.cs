namespace Infrastructure
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>();
    }
}
