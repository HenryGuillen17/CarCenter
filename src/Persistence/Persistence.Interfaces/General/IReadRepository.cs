using System.Collections.Generic;

namespace Persistence.Interfaces.General
{
    public interface IReadRepository<T, K> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(K id);
    }
}
