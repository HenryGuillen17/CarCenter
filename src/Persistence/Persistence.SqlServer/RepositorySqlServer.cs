using System.Data.SqlClient;

namespace Persistence.SqlServer
{
    public abstract class RepositorySqlServer
    {
        private readonly SqlConnection _context;
        private readonly SqlTransaction _transaction;


        protected RepositorySqlServer(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        protected SqlCommand CreateCommand(string query)
        {
            return _transaction != null ? new SqlCommand(query, _context, _transaction) : new SqlCommand(query, _context);
        }
    }
}
