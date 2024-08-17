using System.Data;
using Microsoft.Data.SqlClient;
using Sanctuary.Data.Repositories.RepositoriesContracts;

namespace Sanctuary.Data.Control.ControlContracts
{
    public interface ITransactionalManagementUoW<out TRepository, TEntity> where TRepository : IBaseRepository<TEntity> where TEntity : class
    {
        TRepository Repository { get; }
        void CreateTransaction(SqlCommand command, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
        void Save();
    }
}
