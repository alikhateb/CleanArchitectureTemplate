namespace Domain.Entity.Common
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
        }

        protected BaseEntity(Guid id) => Id = id;

        public Guid Id { get; protected set; }
    }
}
