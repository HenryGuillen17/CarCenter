using System.Data.SqlClient;
using Persistence.Interfaces.Repositories;
using Persistence.SqlServer.Repositories;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        // Adapters Base de datos
        private readonly SqlConnection _context;
        private readonly SqlTransaction _transaction;


        // Repositorios privados
        private MecanicoRepository _mecanicoRepository;


        // Repositorios Públicos
        public IMecanicoRepository MecanicoRepository => _mecanicoRepository ?? (_mecanicoRepository = new MecanicoRepository(_context, _transaction));



        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
    }
}
