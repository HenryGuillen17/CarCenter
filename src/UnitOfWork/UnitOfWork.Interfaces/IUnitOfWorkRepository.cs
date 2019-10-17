
using Persistence.Interfaces.Repositories;

namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        // Incluir Repositorios
        IMecanicoRepository MecanicoRepository { get; }

    }
}
