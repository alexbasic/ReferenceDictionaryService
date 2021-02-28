namespace Infrastructure
{
    public abstract class Entity : IEntity<long>
    {
        public long Id { get; set; }
    }
}
