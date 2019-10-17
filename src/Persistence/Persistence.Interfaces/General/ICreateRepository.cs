namespace Persistence.Interfaces.General
{
    public interface ICreateRepository<T> where T : class
    {
        void Create(T t);
    }
}
