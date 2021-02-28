namespace Infrastructure
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : Entity;
        IRepository<T> GetReadOnlyRepository<T>() where T : Entity;
    }
}
