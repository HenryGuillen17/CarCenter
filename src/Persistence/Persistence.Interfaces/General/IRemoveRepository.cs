namespace Persistence.Interfaces.General
{
    public interface IRemoveRepository<K>
    {
        void Remove(K id);
    }
}
