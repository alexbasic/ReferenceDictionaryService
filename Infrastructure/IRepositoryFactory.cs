namespace Infrastructure
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : Entity, new();
    }
}
