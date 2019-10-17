using Microsoft.Extensions.Configuration;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWorkSqlServer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IUnitOfWorkAdapter Create(bool hasTransaction = false)
        {
            var connectionString = _configuration.GetValue<string>("SqlConnectionString");

            return new UnitOfWorkSqlServerAdapter(connectionString, hasTransaction);
        }
    }
}
