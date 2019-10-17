using System.Data.SqlClient;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerAdapter : IUnitOfWorkAdapter
    {
        private readonly SqlConnection _context;
        private readonly SqlTransaction _transaction;
        private UnitOfWorkSqlServerRepository _repositories;


        public IUnitOfWorkRepository Repositories => _repositories ?? (_repositories = new UnitOfWorkSqlServerRepository(_context, _transaction));


        public UnitOfWorkSqlServerAdapter(string connectionString, bool hasTransaction)
        {
            _context = new SqlConnection(connectionString);
            _context.Open();

            if (hasTransaction)
                _transaction = _context.BeginTransaction();

        }

        public void Dispose()
        {
            _transaction?.Dispose();

            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }

            _repositories = null;
        }

        public void SaveChanges()
        {
            _transaction?.Commit();
        }
    }
}
