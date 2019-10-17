using Models.Dao;
using Persistence.Interfaces.General;

namespace Persistence.Interfaces.Repositories
{
    public interface IMecanicoRepository : ICreateRepository<Mecanico>, IUpdateRepository<Mecanico>, IRemoveRepository<Mecanico>, IReadRepository<Mecanico, Mecanico>
    {
    }

}
