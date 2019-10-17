namespace Persistence.Interfaces.General
{
    public interface IUpdateRepository<T> where T : class
    {
        void Update(T t);
    }
}
